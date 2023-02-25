using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDb_Sample.Models;
using MongoDb_Sample.Repositories.ProducerRepository;

namespace MongoDb_Sample.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        private readonly IProducerRepository _producerRepository;
        public ProducerController(IProducerRepository producerRepository)
        {
            _producerRepository = producerRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProducre([FromBody]Producer producer)
        {
            var res = await _producerRepository.CreateAsync(producer);
            return Ok(res);
        }
    }
}
