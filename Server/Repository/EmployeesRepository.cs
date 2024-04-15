using Entities.Entities;
using Server.Repository.Abstract;
using System.Text.Json;

namespace Server.Repository
{
    public class EmployeesRepository : IEmployeesServices
    {
        public async Task<IEnumerable<Employee>> GetAll()
        {
            var listProcessors = Helper.Load<Employee>();
            
            return listProcessors;
        }

        public async Task Add(Employee employee)
        {
            Helper.Save(employee);
        }
    }
}
