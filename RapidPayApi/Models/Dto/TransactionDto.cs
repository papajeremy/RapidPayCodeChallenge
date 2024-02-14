using System.ComponentModel.DataAnnotations;

namespace RapidPayApi.Models.Dto
{
    public class TransactionDto
    {
        public int TransactionId { get; set; }
        [Required]
        [StringLength(15)]
        public string CardNumber { get; set; } = string.Empty;
        [Required]
        public double TransactionAmount { get; set; }
        public double TransactionFee { get; set; }
        public double TransactionTotal { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
