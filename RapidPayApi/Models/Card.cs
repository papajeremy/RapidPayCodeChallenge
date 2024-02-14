using System.ComponentModel.DataAnnotations;

namespace RapidPayApi.Models
{
    public class Card
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(15)]
        public string CardNumber { get; set; } = string.Empty;
        public DateTime ExpirationDate { get; set; }
        public double CardLimit { get; set; }
        public double Balance { get; set; }
        public string CardHolderFirstName { get; set; } = string.Empty;
        public string CardHolderLastName { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool Active { get; set; }

        public ICollection<CardTransaction>? CardTransactions { get; set; }
    }
}
