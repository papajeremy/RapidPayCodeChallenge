using System.ComponentModel.DataAnnotations;

namespace RapidPayApi.Models.Dto
{    
    public class CardDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength( 15 )]
        public string CardNumber { get; set; } = string.Empty;

        [Required]
        public DateTime ExpirationDate { get; set; }

        [Required]
        public double CardLimit { get; set; }

        public double Balance { get; set; }

        [Required]
        [MinLength( 2 )]
        [MaxLength( 25 )]
        public string CardHolderFirstName { get; set; } = string.Empty;

        [Required]
        [MinLength( 2 )]
        [MaxLength( 50 )]
        public string CardHolderLastName { get; set; } = string.Empty;

        [MinLength(5)]
        [MaxLength( 100 )]
        public string CompanyName { get; set; } = string.Empty;

        public bool Active { get; set; } = true;
    }
}
