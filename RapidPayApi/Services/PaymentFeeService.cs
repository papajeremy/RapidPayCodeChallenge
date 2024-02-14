namespace RapidPayApi.Services
{
    public class PaymentFeeService
    {
        public double RandomFee( double lastFeeAmount, DateTime lastFeeDateTime )
        {
            if ( lastFeeAmount <= 0 )
            {
                throw new ArgumentOutOfRangeException( "lastFee", "parameter is out of range. must be greater than 0" );
            }
            if ( !DateTimeLastFeeAmount( lastFeeDateTime ) ) return lastFeeAmount;
            double numRandom = 0;
            Random rnd = new Random();
            while(numRandom == 0 )
            {
                numRandom = rnd.NextDouble();
            }
            var newFeeAmount = numRandom * 2 * lastFeeAmount;
            return newFeeAmount;
        }

        private bool DateTimeLastFeeAmount( DateTime lastFeeDateTime )
        {
            if ( (DateTime.UtcNow - lastFeeDateTime).TotalHours >= 1 ) return true;
            else return false;
        }
    }
}
