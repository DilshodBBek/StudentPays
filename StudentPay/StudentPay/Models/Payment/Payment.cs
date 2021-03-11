using Customer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPay.Models
{
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Pay_ID { get; set; }

        [Display(Name = "Payment Name")]
        public string Pay_Name { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Pay Date")]
        public DateTime PayDate { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        
        [Display(Name = "Payment amount")]
        public double PayAmount { get; set; }

        public Student _Student { get; set; }
    }
}
