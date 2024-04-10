using Entities.Entities;

namespace Server.Repository.Abstract
{
    public interface IProcessorsServices
    {
        public  Task<IEnumerable<Processor>> GetAll();
    }
}
