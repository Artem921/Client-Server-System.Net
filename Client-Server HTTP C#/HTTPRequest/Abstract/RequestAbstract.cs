using Client_Server_HTTP_C_.Client;
using Entities.Entities;

namespace Client_Server_HTTP_C_.HTTPRequest.Abstract
{
    public abstract class RequestAbstract
    {
        protected readonly EmployeeClient client;

        public RequestAbstract(EmployeeClient client)
        {
            this.client = client;
        }

        public void Request()
        {
            var employee = CreateEmployee();

            Request(employee);
        }

        public abstract Employee CreateEmployee();

        public abstract void Request(Employee employee);

    }
}
