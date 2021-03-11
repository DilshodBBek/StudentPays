using Customer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPay.Models
{
    public class StudentService : IStudentRepo
    {
        private readonly StudentPayDB student_PayDb;

        public StudentService(StudentPayDB StudentPayDB)
        {
            student_PayDb = StudentPayDB;
        }

        public Student AddStudent(Student student)
        {
            try
            {
                student_PayDb.Students.Add(student);
                student_PayDb.SaveChanges();
                return student;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void DeleteStudent(int id)
        {
            try
            {
                var payments = (from p in student_PayDb.Payments
                                where p._Student.Id == id
                                select new Payment
                                {
                                    PayAmount = p.PayAmount,
                                    PayDate = p.PayDate,
                                    Pay_Name = p.Pay_Name,
                                    Pay_ID = p.Pay_ID,
                                    _Student = p._Student
                                }).ToList();

                foreach (var item in payments)
                {
                    student_PayDb.Payments.Remove(item as Payment);
                }

                student_PayDb.Students.Remove(this.GetStudent(id));
                student_PayDb.SaveChanges();
            }
            catch (Exception)
            {

            }
        }

        public List<Student> GetAll()
        {
            try
            {
                return student_PayDb.Students.ToList();
            }
            catch (Exception)
            {
                return null;
            }
             
        }

        public Student GetStudent(int? id)
        {
            try
            {
                return student_PayDb.Students.FirstOrDefault(x => x.Id.Equals(id));
            }
            catch (Exception)
            {
                return null;
            }            
        }

        public Student UpdateStudent(int id, Student student)
        {
            try
            {
                if (id.Equals(student.Id))
                {
                    student_PayDb.Update(student);
                    student_PayDb.SaveChanges();
                    return student_PayDb.Students.FirstOrDefault(x => x.Id.Equals(student.Id));
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
