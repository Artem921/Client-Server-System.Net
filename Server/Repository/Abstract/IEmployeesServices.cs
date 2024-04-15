using Entities.Entities;

namespace Server.Repository.Abstract
{
    public interface IEmployeesServices
    {
        public  Task<IEnumerable<Employee>> GetAll();
    }
}
