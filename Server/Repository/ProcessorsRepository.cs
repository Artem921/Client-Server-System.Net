using Entities.Entities;
using Server.Repository.Abstract;
using System.Text.Json;

namespace Server.Repository
{
    public class ProcessorsRepository : IProcessorsServices
    {
        public async Task<IEnumerable<Processor>> GetAll()
        {
            var listProcessors = Helper.Load<Processor>();
            
            return listProcessors;
        }
    }
}
