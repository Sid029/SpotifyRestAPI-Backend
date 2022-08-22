using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Music_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        [HttpPost("pay")]
        public async Task<string> Pay(Model.PaymentModel pm)
        {
            return await MakePayment.PayAsync(pm.cardnumber, pm.month, pm.year, pm.cvc, pm.value);
        }
    }
}
