using Microsoft.QueryStringDotNET;
using System.Net.Http.Json;

namespace Client_Server_HTTP_C_.Client
{
    public class EmployeeClient
    {

        protected readonly HttpClient httpClient;

        protected readonly string connection;
        public EmployeeClient(string connection)
        {
            this.connection = connection;
            httpClient = new HttpClient();
        }
        public T GetAll<T>() where T : new() => GeAlltAsync<T>().Result;

        protected async Task<T> GeAlltAsync<T>() where T : new()
        {
            try
            {
                var response = await httpClient.GetAsync(connection);

                if (response.IsSuccessStatusCode)
                {
                    return await System.Text.Json.JsonSerializer.DeserializeAsync<T>(await response.Content.ReadAsStreamAsync());
                }
            }
            catch { }
            {
                Console.WriteLine("Нет соединения с сервером!");
            }

                return new T();

            
        }

        public T Get<T>(string id) where T : new() => GetAsync<T>(id).Result;

        protected async Task<T> GetAsync<T>(string id) where T : new()
        {
            var queryString = new QueryString
            {
                { "id", id.ToString() }
            };
            try
            {
                var response = await httpClient.GetAsync($"{connection}/?{queryString}");


                if (response.IsSuccessStatusCode)
                {
                    return await System.Text.Json.JsonSerializer.DeserializeAsync<T>(await response.Content.ReadAsStreamAsync());
                }
            }
            catch { }
            {
                Console.WriteLine("Нет соединения с сервером!");
            }

            return new T();
            
        }

        public HttpResponseMessage Post<T>( T item) => PostAsync( item).Result;
        protected async Task<HttpResponseMessage> PostAsync<T>( T item)
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync(connection, item);

                return response.EnsureSuccessStatusCode();
            }
            catch { }
            {
                Console.WriteLine("Нет соединения с сервером!");
            }
            return new();
        }


        public HttpResponseMessage Put<T>( T item) => PutAsync( item).Result;
        protected async Task<HttpResponseMessage> PutAsync<T>( T item, CancellationToken cancel = default)
        {
            try
            {
                var response = await httpClient.PutAsJsonAsync(connection, item);

                return response.EnsureSuccessStatusCode();
            }
            catch { }
            {
                Console.WriteLine("Нет соединения с сервером!");
            }

            return new();
        }


        public HttpResponseMessage Delete<T>(T id) => DeleteAsync(id).Result;
        protected async Task<HttpResponseMessage> DeleteAsync<T>(T id, CancellationToken cancel = default)
        {
            var queryString = new QueryString
            {
                { "id", id.ToString() }
            };


            try
            {
                var response = await httpClient.DeleteAsync($"{connection}/?{queryString}");

                return response.EnsureSuccessStatusCode();
            }
            catch { }
            {
                Console.WriteLine("Нет соединения с сервером!");
            }
            return new();

        }

        #region IDisposable
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed || !disposing) return;
            _disposed = true;
            httpClient.Dispose();
        }
        #endregion
    }
}

