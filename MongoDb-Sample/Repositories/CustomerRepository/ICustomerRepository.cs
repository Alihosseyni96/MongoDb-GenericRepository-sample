using MongoDb_Sample.Models;
using MongoDb_Sample.Repositories.BaseRepository;

namespace MongoDb_Sample.Repositories.CustomerRepository
{
    public interface ICustomerRepository  : IBaseRepository<Customer>
    {

    }
}
