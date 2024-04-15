using Entities.Entities;
using Newtonsoft.Json;
using Server.Repository.Abstract;
using System.Net;
using System.Text;
using System.Text.Json;

namespace Server
{

    public class HttpListenerServices
    { 
        private readonly HttpListener server;

        private readonly  IEmployeesServices services;

        private const string connection = "http://127.0.0.1:8888/";

        public HttpListenerServices(IEmployeesServices services)
        {
            this.server = new HttpListener();
            this.services = services;
            Start();
        }

        private void Start()
        {
            Console.WriteLine("Сервер запущен");

            server.Prefixes.Add(connection);

            server.Start();
        } 

        private async Task GetAll(HttpListenerResponse response)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(await services.GetAll()));
            using (var stream = response.OutputStream)
            {
                await stream.WriteAsync(buffer);
                await stream.FlushAsync();
            }
        }


        private async Task Add(HttpListenerContext context)
        {
            //var employees = await System.Text.Json.JsonSerializer.DeserializeAsync<Employee>(context.Request.);
        }

        public async Task GetContext()
        {  

            while (true)
            {
                var context = await server.GetContextAsync();
              
                var response = context.Response;

                if (context.Request.HttpMethod=="GET")
                {
                   GetAll(response);

                }

                if(context.Request.HttpMethod=="POST")
                {
                     var request = context.Request;

                   

                    using(Stream body = request.InputStream)
                    {
                        using(var reader = new StreamReader(body, request.ContentEncoding))
                        {
                          
                            Employee employee=JsonConvert.DeserializeObject<Employee>(reader.ReadToEnd());


                            Console.WriteLine(employee.Name);
                        }
                    }



                }

                response.Close();
            }  

        }



    }
}
