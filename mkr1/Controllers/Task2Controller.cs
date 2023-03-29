using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace mkr1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Task2Controller : ControllerBase
    {
        [HttpPost("task2")]

        public async Task<ActionResult<Int32>> FindProduct(Task2 task2)
        {
            int product = 1;
            int n = task2.n;

            while (n > 0)
            {
                int digit = n % 10;
                if (digit % 2 == 0)
                {
                    product *= digit;
                }
                n /= 10;
            }
            return Ok(product);
        }
    }
}
