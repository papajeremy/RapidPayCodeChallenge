namespace RapidPayApi.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int Id { get; set; }
        public double TransactionAmount { get; set; }
        public double TransactionFee { get; set; }
        public double TransactionTotal { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
