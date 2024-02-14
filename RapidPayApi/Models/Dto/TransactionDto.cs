using System.ComponentModel.DataAnnotations;

namespace RapidPayApi.Models.Dto
{
    public class TransactionDto
    {
        public int TransactionId { get; set; }
        public int Id { get; set; }
        [Required]        
        public double TransactionAmount { get; set; }
        public double TransactionFee { get; set; }
        public double TransactionTotal { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.Now;
    }
}
