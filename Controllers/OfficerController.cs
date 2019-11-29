using System;
using System.Linq;
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

        public string getUserId()
        {
            return _userManager.GetUserId(HttpContext.User);
        }

        public string getUserRole(string userId)
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

        public IActionResult Semester()
        {
            return View();
        }


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