using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace mkr1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Task1Controller : ControllerBase
    {
        [HttpPost("task1")]

        public async Task<ActionResult<Double[]>> FindRadiuses(Task1 task1)
        {
            var a = task1.firstSide;
            var b = task1.secondSide;
            var c = task1.thirdSide;
            var p = (a + b + c) / 2;
            var rad_ops = (a * b * c) / (4 * Math.Sqrt(p * (p - a) * (p - b) * (p - c)));
            var rad_vps = Math.Sqrt(((p - a) * (p - b) * (p - c)) / p);
            double[] radiuses = { rad_ops, rad_vps };
            return radiuses;
        }
    }
}
