using StudentPay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Models
{
    public interface IPaymentRepo
    {
        List<Payment> GetAllStudentPayments(int? StudentId);

        Payment GetPayment(int payment_Id);

        Payment AddPayment(Payment payment);

        void RemovePayment(int? payment_Id);

        Payment UpdatePayment(Payment payment);
    }
}
