using Customer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPay.Models
{
    public class PaymentService : IPaymentRepo
    {
        private readonly StudentPayDB payDb;

        public PaymentService(StudentPayDB studentPay)
        {
            payDb = studentPay;
        }
        public Payment AddPayment(Payment payment)
        {
            try
            {
                payment._Student = payDb.Students.FirstOrDefault(x => x.Id == payment._Student.Id);
                payDb.Add(payment);
                payDb.SaveChanges();
                return payDb.Payments.FirstOrDefault(x => x.Pay_ID == payment.Pay_ID);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Payment> GetAllStudentPayments(int? StudentId)
        {
            try
            {
                
                if (StudentId == null)
                {
                    return (from p in payDb.Payments
                            select new Payment
                            {
                                Pay_ID = p.Pay_ID,
                                PayAmount = p.PayAmount,
                                PayDate = p.PayDate,
                                Pay_Name = p.Pay_Name,
                                _Student = p._Student
                            }).ToList();
                }
                var payment = (from p in payDb.Payments
                                   where p._Student.Id == StudentId
                                   select new Payment
                                   {
                                       Pay_ID = p.Pay_ID,
                                       PayAmount = p.PayAmount,
                                       PayDate = p.PayDate,
                                       Pay_Name = p.Pay_Name,
                                       _Student = p._Student
                                   }).ToList();
                return payment;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Payment GetPayment(int payment_Id)
        {
            try
            {
                Payment payment = (from p in payDb.Payments
                               where p.Pay_ID == payment_Id
                               join s in payDb.Students
                               on p._Student.Id equals s.Id
                               select new Payment
                               {
                                   Pay_ID = payment_Id,
                                   PayAmount = p.PayAmount,
                                   PayDate = p.PayDate,
                                   Pay_Name = p.Pay_Name,
                                   _Student = p._Student
                               }).ToList()[0] as Payment;

                return payment;
            }
            catch (Exception)
            {
                return null;
            }
        }


        public void RemovePayment(int? payment_Id)
        {
            try
            {
                if (payment_Id != null)
                {
                    Payment fee = payDb.Payments.FirstOrDefault(x => x.Pay_ID == payment_Id);
                    payDb.Remove(fee);
                    payDb.SaveChanges();
                }
            }
            catch (Exception){}
           
        }

        public Payment UpdatePayment(Payment payment)
        {
            try
            {
                Payment payment1 = (from p in payDb.Payments
                                   where p.Pay_ID == payment.Pay_ID
                                   join s in payDb.Students
                                   on p._Student.Id equals s.Id
                                   select new Payment
                                   {
                                       Pay_ID = payment.Pay_ID,
                                       PayAmount = payment.PayAmount,
                                       PayDate = payment.PayDate,
                                       Pay_Name = payment.Pay_Name,
                                       _Student = p._Student
                                   }).ToList()[0] as Payment;

                payDb.Update(payment1);
                payDb.SaveChanges();
                return payment1;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
