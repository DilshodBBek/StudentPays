using Customer.Models;
using Microsoft.AspNetCore.Mvc;
using StudentPay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPay.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepo studentService;

        public StudentController(IStudentRepo studentRepo)
        {
            studentService = studentRepo;
        }
        public IActionResult Index()
        {
            return View(studentService.GetAll());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create([Bind("Id,Name,Course,Address")] Student student)
        {
            studentService.AddStudent(student);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int studentid)
        {

            return View(studentService.GetStudent(studentid));
        }
        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id,Name,Course,Address")] Student student)
        {
            studentService.UpdateStudent(id, student);
            return RedirectToAction("Index");
        }

        
        public IActionResult Delete(int studentid)
        {
            return View(studentService.GetStudent(studentid));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            studentService.DeleteStudent(id);
            return RedirectToAction("Index");
        }
    }
}
