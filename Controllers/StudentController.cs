using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using App.Data;
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

            if (oid != loggedInUser)
            {
                return "login";
            }

            return Regex.Replace(oid, @"\s+", "") == "" ? "Self" : "Continue";
        }

        /*
         * HttpGet method to get all info of specific student id 
         */
        public async Task<IActionResult> Index(string sid)
        {
            var loggedInUser = GetUserId();
            var auth = AuthenticateUser(sid);
            switch (auth)
            {
                case "login":
                    return RedirectToAction("Signin", "Account");
                case "Self":
                    await Index(loggedInUser);
                    break;
                case "Continue":
                {
                    var student = await _context.Student
                        .Include(stu => stu.Registration)
                        .SingleOrDefaultAsync(cat => cat.Registration.RegistrationId == sid);

                    var sName = await _context.Semester.ToListAsync();
                    ViewBag.semesterName = sName.Last().SemesterName;

                    var batchList = await _context.Batch.OrderByDescending(b => b.BatchName).ToListAsync();
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
            }

            return RedirectToAction("Logout", "Account");
        }

        /*
         * HttpGet method to get the course information of the selected semester from the dropdown list 
         */
        public async Task<JsonResult> GetCourseOfSemester(string semester)
        {
            var courses = await _context.Course.Where(cat => cat.SemesterNumber == semester).ToListAsync();
            return Json(courses);
        }

        /*
         * HttpPost method to save student form data
         */
        [HttpPost]
        public async Task<JsonResult> SaveStudentInfo(StudentForm studentForm)
        {
            //enrollment check for that seection
            // Count
            // > 35
            // section = new Section
            // get ascil of last semester
            // ascii ++
            // again convert to letter
            // push in section table

            try
            {
                var student =
                    _context.Student.SingleOrDefault(ss => ss.Registration.StudentVarsityId == studentForm.StudentId);
                var selectedSemester =
                    _context.Semester.SingleOrDefault(ss => ss.SemesterName == studentForm.SemesterName);
                var batch = _context.Batch.SingleOrDefault(b => b.BatchName == studentForm.Batch);
                var section = _context.Section.SingleOrDefault(s => s.SectionName == studentForm.Section);
                var courses = new List<Course>();
                if (!string.IsNullOrEmpty(studentForm.Course01))
                {
                    var course1 = _context.Course.SingleOrDefaultAsync(c => c.CourseCode == studentForm.Course01);
                    courses.Add(await course1);
                }

                if (!string.IsNullOrEmpty(studentForm.Course02))
                {
                    var course2 = _context.Course.SingleOrDefaultAsync(c => c.CourseCode == studentForm.Course02);
                    courses.Add(await course2);
                }

                if (!string.IsNullOrEmpty(studentForm.Course03))
                {
                    var course3 = _context.Course.SingleOrDefaultAsync(c => c.CourseCode == studentForm.Course03);
                    courses.Add(await course3);
                }

                if (!string.IsNullOrEmpty(studentForm.Course04))
                {
                    var course4 = _context.Course.SingleOrDefaultAsync(c => c.CourseCode == studentForm.Course04);
                    courses.Add(await course4);
                }

                if (!string.IsNullOrEmpty(studentForm.Course05))
                {
                    var course5 = _context.Course.SingleOrDefaultAsync(c => c.CourseCode == studentForm.Course05);
                    courses.Add(await course5);
                }

                foreach (var eachCourse in courses)
                {
                    if (student != null)
                    {
                        var enrollment = new Enrollment
                        {
                            EnrollCourses = eachCourse,
                            EnrolledBatch = batch,
                            EnrolledSection = section,
                            EnrolledSemester = selectedSemester,
                            EnrollStudents = student,
                            EnrollCourseId = eachCourse.CourseId,
                            EnrollStudentId = student.StudentId,
                            IsRetakeCourse = false
                        };
                        _context.Add(enrollment);
                    }
                }
                await _context.SaveChangesAsync();
                return Json("success");
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }
    }
}