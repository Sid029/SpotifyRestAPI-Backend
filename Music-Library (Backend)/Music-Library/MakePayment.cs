using Stripe;
using System.Web;

namespace Music_Library
{
    public class MakePayment
    {
        public static async Task<string> PayAsync(string cardnumber, int month, int year, string cvc, int value)
        {
            try
            {
                StripeConfiguration.ApiKey= "sk_test_51LNxdhDzYiibUURw56ojudbzuFTsvDVeC3zSF4heW4oatCW8vrm6hQJZ8FAp5OR9khM5c6QyDQBoYsQRdzovbixy00dxkyLJ1t";
                var optionstoken = new TokenCreateOptions
                {
                    Card = new TokenCardOptions
                    {
                        Number = cardnumber,
                        ExpMonth = month,
                        ExpYear = year,
                        Cvc = cvc
                    }
                };
                var servicetoken = new TokenService();
                Token stripetoken = await servicetoken.CreateAsync(optionstoken);
                var options = new ChargeCreateOptions
                {
                    Amount = value,
                    Currency = "eur",
                    Description = "Testing description to check backend",
                    Source = stripetoken.Id
                };
                var service = new ChargeService();
                Charge charge = await service.CreateAsync(options);

                if (charge.Paid)
                {
                    var x = "success";
                    return x;
                }
                else
                {
                    return "Failure";
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
