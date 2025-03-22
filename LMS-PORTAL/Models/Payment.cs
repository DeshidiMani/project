using System;
using System.ComponentModel.DataAnnotations;

namespace LMSCapstone.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        
        [Required]
        public decimal Amount { get; set; }
        
        public string PaymentStatus { get; set; } // Status like "Completed", "Pending"
        public DateTime PaymentDate { get; set; } // Date of payment
    }
}
