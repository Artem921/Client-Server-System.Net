using Entities.Entities;
using Newtonsoft.Json;
using Server.Repository.Abstract;
using System.Net;
using System.Text;

namespace Server
{

    public class HttpListenerServices
    { 
        private readonly HttpListener server;

        private readonly  IEmployeesServices repository;

        private const string connection = "http://127.0.0.1:8888/";

        public HttpListenerServices(IEmployeesServices services)
        {
            this.server = new HttpListener();
            this.repository = services;
            Start();
           
        }

        private void Start()
        {
            Console.WriteLine("Сервер запущен");

            server.Prefixes.Add(connection);

            server.Start();
        } 


        public async Task ListenerRequest()
        {  

            while (true)
            {
                var context = await server.GetContextAsync();
              
                var response = context.Response;

                var request = context.Request;

                byte[] buffer;

                switch (request.HttpMethod)
                {
                    case "GET":
                        if (request.QueryString.Count == 0)
                        {
                            buffer = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(await repository.GetAll()));
                        }

                        else buffer = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(await repository.GetById(Convert.ToInt32(request.QueryString["id"]))));

                        using (var stream = response.OutputStream)
                        {
                            await stream.WriteAsync(buffer);
                            await stream.FlushAsync();
                        }

                        break;

                    case "POST":
                        using (Stream body = request.InputStream)
                        {
                            using (var reader = new StreamReader(body, request.ContentEncoding))
                            {

                                Employee employee = JsonConvert.DeserializeObject<Employee>(reader.ReadToEnd());
                                
                                repository.Add(employee);
                            }
                        }
                        break;

                    case "PUT":
                        using (Stream body = request.InputStream)
                        {
                            using (var reader = new StreamReader(body, request.ContentEncoding))
                            {
                                Employee employee = JsonConvert.DeserializeObject<Employee>(reader.ReadToEnd());

                                repository.Update(employee);
                            }
                        }
                        break;

                    case "DELETE":
                        int id = Convert.ToInt32(request.QueryString["id"]);
                        await repository.Delete(id);
                        break;
                }

                response.Close();
            }  

        }



    }
}
