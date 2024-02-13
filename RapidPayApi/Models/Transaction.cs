namespace RapidPayApi.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int Id { get; set; }
        public double Amount { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
