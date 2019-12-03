using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using App.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace App.Controllers
{
    public class OfficerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public OfficerController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        /*
         * Get user id from the user manager
         */
        public string GetUserId()
        {
            return _userManager.GetUserId(HttpContext.User);
        }
        
        /*
         * Get user role from the user id
         */
        public string GetUserRole(string userId)
        {
            try
            {
                var role = _context.OfficerReg.Find(userId);
                return role.Role;
            }
            catch (Exception)
            
            {
                return null;
            }
        }
        
        /*
         * Method to authenticate user.
         * if the user id is null then user should login / register first
         * if the logged in user role is not officer then route to student page
         * if the logged in user id and passing id doesn't match then return check role and route
         * at last return the user id and route'
         */
        public string AuthenticateUser(string oid)
        {
            var loggedInUser = GetUserId();
            if (string.IsNullOrEmpty(loggedInUser))
            {
                return "login";
            }
            if (GetUserRole(oid) != "Officer")
            {
                return "student";
            }
            if (oid != loggedInUser)
            {
                return GetUserRole(loggedInUser) == "Student" ? "Student" : "Self";
            }

            return Regex.Replace(oid, @"\s+", "") == "" ? "Self" : "Continue";
        }
        
        /*
         * Method to authenticate user from user id and user role
         * and view the page
         */
        public async Task<IActionResult> Semester(string oid)
        {
            var loggedInUser = GetUserId();
            var auth = AuthenticateUser(oid);
            switch (auth)
            {
                case "login":
                    return RedirectToAction("Signin", "Account");
                case "student":
                    return RedirectToAction("index", "Student", new {sid = loggedInUser});
                case "Self":
                    await Semester(loggedInUser);
                    break;
                case "Continue":
                {
                    return View();
                }
                default:
                    await Semester(loggedInUser);
                    break;
            }
            return RedirectToAction("Logout", "Account");
        }

        /*
         * HttpPost method which pass semester as a string and
         * check if the semester is already exists or not. IF the
         * semester is not already exists then create a semester
         * and return success.
         */
        [HttpPost]
        public async Task<JsonResult> CreateSemester(string sName)
        {
            var isExistsSemester = _context.Semester.FirstOrDefault(s => s.SemesterName == sName);
            try
            {
                if (isExistsSemester != null)
                {
                    return Json("semesterExists");
                }
                if (sName.Contains("Choose"))
                {
                    return Json("invalidSemester");
                }
                var semester = new Semester
                {
                    SemesterId = Guid.NewGuid().ToString().Replace("-", ""),
                    SemesterName = sName
                };
                _context.Add(semester);
                await _context.SaveChangesAsync();
                return Json("success");
            }
            catch (Exception)
            {
                return Json("fail");
            }
        }

        /*
         * HttpGet method to fetch all the semesters
         * from the database and show on the page
         */
        public async Task<JsonResult> FetchSemesters()
        { 
            try
            {
                var semesters = await _context.Semester.ToListAsync();
                return Json(semesters);
            }
            catch (Exception)
            {
                return Json("Fail"); 
            }
        }
    }
}