using System;
using System.Linq;
using System.Threading.Tasks;
using App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers
{
    public class StudentController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        public StudentController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // get currently logged in user
        public string GetUserId()
        {
            return _userManager.GetUserId(HttpContext.User);
        }
        
        /*
         * HttpGet method to get all info of specific student id 
         */
         
        public async Task<IActionResult> Index(string sid)
        {
            var student = await _context.Student
                .Include(stu => stu.Registration)
                .SingleOrDefaultAsync(cat => cat.Registration.RegistrationId == sid);
            
            var batchList = await _context.Batch.ToListAsync();
            foreach (var batch in batchList)
            {
                student.Batches.Add(new SelectListItem
                {
                    Value = batch.BatchId,
                    Text = batch.BatchName
                });
            }

            var sectionList = await _context.Section.ToListAsync();
            foreach (var section in sectionList)
            {
                student.Sections.Add(new SelectListItem
                {
                    Value = section.SectionId,
                    Text = section.SectionName
                });
            }
            return View(student);
        }
        /*
         * HttpGet method to get the course information of the selected semester from the dropdown list 
         */
        public async Task<JsonResult> GetCourseOfSemester(string semester)
        {
            var courses = await _context.Course.Where(cat => cat.SemesterNumber == semester).ToListAsync();
            return Json(courses);
        } 
    }
}