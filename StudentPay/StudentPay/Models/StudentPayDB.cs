using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentPay.Models;

namespace Customer.Models
{
    public class StudentPayDB:DbContext
    {
        public StudentPayDB(DbContextOptions<StudentPayDB> options)
               : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}
