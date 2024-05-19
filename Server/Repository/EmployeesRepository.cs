using Entities.Entities;
using Server.Repository.Abstract;

namespace Server.Repository
{
    public class EmployeesRepository : IEmployeesServices
    {
        public async Task<List<Employee>> GetAll()
        {
            var employees = await Task.Run(() => Helper.Load<Employee>());
            
            return  employees;
        }

        public async Task Add(Employee employee)
        {
            var employees = await GetAll();

            employees.Add(employee);

           await Task.Run(()=> Helper.Save(employees));
        }

        public async Task<Employee> GetById(int id)
        {
            var employees = await Task.Run(() => Helper.Load<Employee>());

            return  await Task.Run(()=> employees.FirstOrDefault(p => p.Id == id));
        }

        public async Task Update(Employee updateEmployee)
        {
            var employees = await GetAll();
            foreach (var employee in employees)
            {
                if(employee.Id == updateEmployee.Id)
                {
                    employee.Age = updateEmployee.Age;

                    employee.Name = updateEmployee.Name;
                }
            }
   
            Helper.Save(employees);

        }

        public async Task Delete(int id)
        {
            var employees = await GetAll();
            var employee = employees.FirstOrDefault(x => x.Id == id);
            employees.Remove(employee);
            Helper.Save(employees);
        }
    }
}
