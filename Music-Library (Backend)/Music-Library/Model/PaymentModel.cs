namespace Music_Library.Model
{
    public class PaymentModel
    {
        public string cardnumber { get; set; }
        public int month { get; set; }
        public int year { get; set; }
        public string cvc { get; set; }
        public int value { get; set; }
    }
}
