using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDb_Sample.Models;
using MongoDb_Sample.Repositories;
using MongoDb_Sample.Repositories.CustomerRepository;

namespace MongoDb_Sample.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CusrtomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        public CusrtomerController(ICustomerRepository customerRepository )
        {
            _customerRepository = customerRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody]Customer customer)
        {
            await _customerRepository.CreateAsync(customer);
            return Ok(); 
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById([FromRoute]int id)
        {
            var res = await _customerRepository.GetByCondition(x=> x.Id == id);
            return Ok(res); 
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteCustomer([FromRoute]int id)
        {
            await _customerRepository.DeleteAsync(x=> x.Id == id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> EditCustomer([FromBody]Customer customer)
        {
            await _customerRepository.UpdateAsync(x=> x.Id == customer.Id , customer);
            return Ok();
        }


    }
}
