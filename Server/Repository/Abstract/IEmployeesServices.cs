using Entities.Entities;

namespace Server.Repository.Abstract
{
    public interface IEmployeesServices
    {
        public  Task<List<Employee>> GetAll();

        public Task<Employee> GetById(int id);

        public Task Add(Employee employee);

        public Task Update(Employee employee);

        public Task Delete(int id);
    }
}
