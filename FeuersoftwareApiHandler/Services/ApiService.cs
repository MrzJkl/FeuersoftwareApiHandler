namespace FeuersoftwareApiHandler.Services
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;
    using FeuersoftwareApiHandler.Models;

    public class ApiService
    {
        static HttpClient client = new HttpClient();

        private string ApiToken { get; set; }

        private string BaseAddress { get; set; }

        public ApiService(string baseAddress, string apiToken)
        {
            this.BaseAddress = baseAddress;
            this.ApiToken = apiToken;

            client.BaseAddress = new Uri(this.BaseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", this.ApiToken);
        }

        public async Task<IEnumerable<Operation>> GetOperations()
        {
            IEnumerable<Operation> operations = null;
            HttpResponseMessage response = await client.GetAsync("interfaces/public/operation");
            if (response.IsSuccessStatusCode)
            {
                operations = await response.Content.ReadAsAsync<List<Operation>>();            
            }
            else
            {
                throw new HttpRequestException();
            }

            return operations;
        }

        public async Task PostOperation(LocalOperation operation)
        {
            if (operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "interfaces/public/operation");
            request.Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(operation), Encoding.UTF8, "application/json");

            await client.SendAsync(request);
        }

        public async Task<IEnumerable<News>> GetNews()
        {
            IEnumerable<News> news = null;
            HttpResponseMessage response = await client.GetAsync("interfaces/public/news");
            if (response.IsSuccessStatusCode)
            {
                news = await response.Content.ReadAsAsync<List<News>>();
            }
            else
            {
                throw new HttpRequestException();
            }

            return news;
        }

        public async Task PostNews(News news)
        {
            if (news == null)
            {
                throw new ArgumentNullException(nameof(news));
            }

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "interfaces/public/news");
            request.Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(news), Encoding.UTF8, "application/json");

            await client.SendAsync(request);
        }

        public async Task DeleteNews(int id)
        {
            await client.DeleteAsync("interfaces/public/news/" + id);
        }
    }
}
