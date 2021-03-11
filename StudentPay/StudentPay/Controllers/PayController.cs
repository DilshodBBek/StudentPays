using Customer.Models;
using Microsoft.AspNetCore.Mvc;
using StudentPay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPay.Controllers
{
    public class PayController : Controller
    {
        private readonly IPaymentRepo payRepo;
        private readonly IStudentRepo student_repo;

        public PayController(IPaymentRepo repo, IStudentRepo studentrepo)
        {
            payRepo = repo;
            student_repo = studentrepo;
        }
        public IActionResult Index(int? StudentId)
        {
            ViewBag.studentid = StudentId;
            ViewBag.StudentName = student_repo.GetStudent(StudentId);
            List<Payment> _payment= payRepo.GetAllStudentPayments(StudentId);
            return View(_payment);
        }
        [HttpGet]
        public IActionResult Create(int studentId)
        {            
            ViewBag.studentId = studentId;
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("_Student,Pay_Name,PayDate,PayAmount")] Payment payment)
        {
            try
            {
                payment = payRepo.AddPayment(payment);
                return RedirectToAction("Index", new
                {
                    StudentId = payment._Student.Id
                });
            }
            catch (Exception)
            {
                return View(payment);
            }        
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Payment payment = payRepo.GetPayment(id);
            if (payment == null)
            {
                return NotFound();
            }
            return View(payment);
        }

        [HttpPost]
        public IActionResult Edit([Bind("Pay_ID,Pay_Name,PayDate,PayAmount")] Payment payment)
        {
            payment = payRepo.UpdatePayment(payment);
            if (payment == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", new
                {
                    StudentId = payment._Student.Id
                });
            }
            return View(payment);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Payment pay = payRepo.GetPayment(id);
            if (pay == null)
            {
                return NotFound();
            }

            return View(pay);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Payment pay = payRepo.GetPayment(id);
            payRepo.RemovePayment(id);
            return RedirectToAction("Index", "Pay", new
            {
                StudentId = pay._Student.Id
            });
        }

    }
}
