namespace FeuersoftwareApiHandler.Services
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using FeuersoftwareApiHandler.Models;

    public partial class ApiService
    {
        /// <summary>
        /// Ruft alle News des Standorts von der Schnittstelle ab.
        /// </summary>
        /// <returns>Die Liste der News</returns>
        public async Task<IEnumerable<News>> GetNews()
        {
            IEnumerable<News> news = new List<News>();
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

        /// <summary>
        /// Sendet News an die Schnittstelle
        /// </summary>
        /// <param name="news">Die News als <see cref="News"/></param>
        /// <returns>Nichts</returns>
        public async Task PostNews(News news)
        {
            if (news == null)
            {
                throw new ArgumentNullException(nameof(news));
            }

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "interfaces/public/news")
            {
                Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(news), Encoding.UTF8, "application/json")
            };

            await client.SendAsync(request);
        }

        /// <summary>
        /// Löscht eine News mit einer ID in Connect
        /// </summary>
        /// <param name="id">Die ID der zu löschenden Nachricht</param>
        /// <returns>Nichts</returns>
        public async Task DeleteNews(int id)
        {
            await client.DeleteAsync("interfaces/public/news/" + id);
        }

        /// <summary>
        /// Aktualisiert eine vorhandene Nachricht in Connect
        /// </summary>
        /// <param name="news">Die zu aktualisierende Nachricht mit ID</param>
        /// <returns>Nichts</returns>
        public async Task PutNews(News news)
        {
            if (news == null || news.Id < 0)
            {
                throw new ArgumentNullException(nameof(news));
            }

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, "interfaces/public/news/" + news.Id)
            {
                Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(news), Encoding.UTF8, "application/json")
            };

            await client.SendAsync(request);
        }
    }
}