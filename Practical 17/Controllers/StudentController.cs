using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Practical_17.Interfaces;
using Practical_17.Models;
using System.Diagnostics;

namespace Practical_17.Controllers
{
    [Authorize]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class StudentController : Controller
    {
        private readonly IStudent _student;

        public StudentController(IStudent student)
        {
            _student = student;
        }

        [HttpGet]
        public IActionResult Dashboard()
        {          
           return View();   
        }

        [HttpGet]
        public IActionResult List()
        {
            var studentList = _student.GetAllStudent();
            return View(studentList);
        }

        [HttpGet]
        [Authorize(Roles ="Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(Student student)
        {
            if(ModelState.IsValid)
            {
                bool status = _student.AddStudent(student);
                if(status)
                {
                    return RedirectToAction("List", "Student");
                }
                else
                {
                    ModelState.AddModelError("", "Cannot add the student details.");
                    return View(student);
                }
            }
            return View(student);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var student = _student.GetStudent(id);
            return View(student);
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(Student student)
        {
            bool status = _student.UpdateStudent(student);
            if (status)
            {
                return RedirectToAction("List", "Student");
            }
            else
            {
                ModelState.AddModelError("", "Cannot add the student details.");
            }
            return View(student);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Details(int id)
        {
            var student = _student.GetStudent(id);
            return View(student); 
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            bool status = _student.DeleteStudent(id);
            if(status)
            {
                return RedirectToAction("List", "Student");
            }
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
