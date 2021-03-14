using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Web.Repository.Abstract;

namespace Web.Repository.Concrete
{
    public class BaseRepo<T> : IBaseRepo<T> where T : class
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BaseRepo(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<bool> Create(string url, T entity)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            if (entity != null)
            {
                request.Content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
            }
            else
            {
                return false;
            }
            var client = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            return false;

        }

        public async Task<bool> Delete(string url, int Id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, url + Id);
            var client = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }

        public async Task<IList<T>> GetAll(string url)
        {

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var client = _httpClientFactory.CreateClient();

            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonstr = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IList<T>>(jsonstr);
            }

            return null;


        }

        public async Task<T> GetbyId(string url, int Id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url + Id);
            var client = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(jsonString);
            }

            return null;
        }

        public async Task<bool> Update(string url, T entity)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            if (entity != null)
            {
                request.Content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");

            }
            return false;
            var client = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
