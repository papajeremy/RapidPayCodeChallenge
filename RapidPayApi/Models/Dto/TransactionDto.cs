using System.ComponentModel.DataAnnotations;

namespace RapidPayApi.Models.Dto
{
    public class TransactionDto
    {
        public int TransactionId { get; set; }
        public int Id { get; set; }
        [Required]        
        public double Amount { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.Now;
    }
}
