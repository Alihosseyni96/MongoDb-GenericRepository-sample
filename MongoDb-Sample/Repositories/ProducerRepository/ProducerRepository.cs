using Microsoft.Extensions.Options;
using MongoDb_Sample.Models;
using MongoDb_Sample.Repositories.BaseRepository;

namespace MongoDb_Sample.Repositories.ProducerRepository
{
    public class ProducerRepository : BaseRepository<Producer> , IProducerRepository    
    {
        public ProducerRepository(IOptions<DbConfiguration> settings) : base(settings)
        {
        }
    }
}
