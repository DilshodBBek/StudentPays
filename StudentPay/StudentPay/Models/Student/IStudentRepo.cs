using Customer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPay.Models
{
    public interface IStudentRepo
    {
        List<Student> GetAll();
        Student GetStudent(int? id);
        Student AddStudent(Student student);
        Student UpdateStudent(int id, Student student);
        void DeleteStudent(int id);
    }
}
