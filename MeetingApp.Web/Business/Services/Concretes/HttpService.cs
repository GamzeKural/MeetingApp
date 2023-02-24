using MeetingApp.Web.Business.Services.Abstracts;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace MeetingApp.Web.Business.Services.Concretes
{
    public class HttpService : IHttpService
    {
        private readonly IConfiguration configuration;
        private static string ApiBaseUrl;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpService(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            try
            {
                this.configuration = configuration;
                ApiBaseUrl = configuration.GetValue<string>("WebAPIBaseUrl");
                _httpContextAccessor = httpContextAccessor;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<T> Get<T>(string uri, bool withToken = true)
        {
            HttpClientHandler handler = new HttpClientHandler();

            var result = Activator.CreateInstance(typeof(T));
            var client = new HttpClient(handler);

            if (withToken == true)
            {
                string token = _httpContextAccessor.HttpContext.Session.GetString("Token");
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            }

            var response = client.GetAsync(ApiBaseUrl + uri).Result;

            if (response.IsSuccessStatusCode)
            {
                var jsonContent = response.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<T>(jsonContent);
            }

            return await Task.FromResult((T)result);
        }



        public async Task<T> Post<T>(string uri, object value, bool withToken = true)
        {
            HttpClientHandler handler = new HttpClientHandler();

            var result = Activator.CreateInstance(typeof(T));
            StringContent Content = null;
            var client = new HttpClient(handler);

            if (withToken == true)
            {
                string token = _httpContextAccessor.HttpContext.Session.GetString("Token");
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            }

            try
            {
                HttpResponseMessage response = new HttpResponseMessage();
                if (value != null)
                {
                    var options = new JsonSerializerOptions
                    {
                        ReferenceHandler = ReferenceHandler.Preserve,
                        MaxDepth = 64 
                    };

                    Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(value, options), Encoding.UTF8, "application/json");
                    response = client.PostAsync(ApiBaseUrl + uri, Content).Result;
                }

                if (response.IsSuccessStatusCode)
                {
                    var jsonContent = response.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<T>(jsonContent);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return (T)result;
        }

        public async Task<T> Put<T>(string uri, object value)
        {
            HttpClientHandler handler = new HttpClientHandler();

            var result = Activator.CreateInstance(typeof(T));
            StringContent Content = null;
            var client = new HttpClient(handler);

            string token = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            try
            {
                HttpResponseMessage response = new HttpResponseMessage();
                if (value != null)
                {
                    var options = new JsonSerializerOptions
                    {
                        ReferenceHandler = ReferenceHandler.Preserve,
                        MaxDepth = 64 
                    };

                    Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(value, options), Encoding.UTF8, "application/json");
                    response = client.PutAsync(ApiBaseUrl + uri, Content).Result;
                }

                if (response.IsSuccessStatusCode)
                {
                    var jsonContent = response.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<T>(jsonContent);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return (T)result;
        }

        public async Task<T> Delete<T>(string uri)
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            var result = Activator.CreateInstance(typeof(T));
            var client = new HttpClient(handler);

            string token = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            try
            {
                HttpResponseMessage response = new HttpResponseMessage();

                response = await client.DeleteAsync(ApiBaseUrl + uri);

                if (response.IsSuccessStatusCode)
                {
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                }
                await Task.FromResult(result);

            }
            catch (Exception)
            {
                throw;
            }

            handler.Dispose();
            client.Dispose();

            return (T)result;
        }
    }

}
