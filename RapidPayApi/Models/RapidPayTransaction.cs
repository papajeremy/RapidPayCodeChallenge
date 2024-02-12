namespace RapidPayApi.Models
{
    public class RapidPayTransaction
    {
        public int TransactionId { get; set; }
        public int Id { get; set; }
        public double Amount { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
