using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RapidPayApi.Models
{
    public class CardTransaction
    {
        [Key]
        public int CardTransactionId { get; set; }
        [ForeignKey("Card")]
        public string CardNumber { get; set; } = string.Empty;
        public Card Card { get; set; }
        public double TransactionAmount { get; set; }
        [Precision(10,2)]
        public double TransactionFee { get; set; }

        public double TransactionTotal { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
