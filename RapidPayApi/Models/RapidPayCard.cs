using System.ComponentModel.DataAnnotations;

namespace RapidPayApi.Models
{
    public class RapidPayCard
    {
        public int Id { get; set; }
        public string CardNumber { get; set; } = string.Empty;
        public DateOnly ExpirationDate { get; set; } = new DateOnly();
        public double CardLimit { get; set; }
        public double Balance { get; set; }
        public string CardHolderFirstName { get; set; } = string.Empty;
        public string CardHolderLastName { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool Active { get; set; } = true;
    }
}
