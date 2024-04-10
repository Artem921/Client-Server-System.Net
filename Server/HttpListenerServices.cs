using Newtonsoft.Json;
using Server.Repository.Abstract;
using System.Net;
using System.Text;

namespace Server
{

    public class HttpListenerServices
    { 
        private readonly HttpListener server;

        private readonly  IProcessorsServices services;

        private const string connection = "http://127.0.0.1:8888/";

        public HttpListenerServices(IProcessorsServices services)
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

        public async Task GetContext()
        {  
           
            byte[] buffer;

            while (true)
            {
                var context = await server.GetContextAsync();
              
                var response = context.Response;

                if (context.Request.HttpMethod=="GET")
                {
                   GetAll(buffer, response);

                   
                }
                response.Close();
            }  

        }

        private async Task GetAll(byte[]? buffer,HttpListenerResponse response)
        {
            buffer = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(await services.GetAll()));
            using (var stream = response.OutputStream)
            {
                await stream.WriteAsync(buffer);
                await stream.FlushAsync();
            }
        }

    }
}
