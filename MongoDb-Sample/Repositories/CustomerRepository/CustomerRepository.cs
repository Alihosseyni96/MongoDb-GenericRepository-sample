using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDb_Sample.Models;
using MongoDb_Sample.Repositories.BaseRepository;
using System.Runtime;

namespace MongoDb_Sample.Repositories.CustomerRepository
{
    public class CustomerRepository : BaseRepository<Customer> , ICustomerRepository
    {

        public CustomerRepository(IOptions<DbConfiguration> settings ) : base(settings  )
        {
        }
    }
}
