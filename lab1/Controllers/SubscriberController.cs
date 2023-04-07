using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace lab1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriberController : ControllerBase
    {
        private static List<Subscriber> subscribers = new List<Subscriber>
        {
            new Subscriber {
                Id = 1,
                PhoneNumber = "+380991234567",
                Address = "Mukachevo",
                Name = "Ivan",
                CallDuration = 100
            },
            new Subscriber {
                Id = 2,
                PhoneNumber = "+380661344437",
                Address = "Uzhhorod",
                Name = "Andrii",
                CallDuration = 294
            }
        };

        [HttpGet]
        public async Task<ActionResult<List<Subscriber>>> Get()
        {
            return Ok(subscribers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Subscriber>>> Get(int id)
        {
            var subscriber = subscribers.Find(subscriber => subscriber.Id == id);
            if(subscriber == null)
                return BadRequest("Subscriber not found");
            return Ok(subscriber);
        }

        [HttpPost]
        public async Task<ActionResult<List<Subscriber>>> AddSubscriber(Subscriber subscriber)
        {
            subscribers.Add(subscriber);
            return Ok(subscribers);
        }

        [HttpPut]
        public async Task<ActionResult<List<Subscriber>>> UpdateSubscriber(Subscriber request)
        {
            var subscriber = subscribers.Find(subscriber => subscriber.Id == request.Id);
            if (subscriber == null)
                return BadRequest("Subscriber not found");

            subscriber.PhoneNumber = request.PhoneNumber;
            subscriber.Name = request.Name;
            subscriber.Address = request.Address;
            subscriber.CallDuration = request.CallDuration;

            return Ok(subscribers);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Subscriber>>> Delete(int id)
        {
            var subscriber = subscribers.Find(subscriber => subscriber.Id == id);
            if (subscriber == null)
                return BadRequest("Subscriber not found");

            subscribers.Remove(subscriber);

            return Ok(subscribers);
        }
    }
}
