namespace FeuersoftwareApiHandler.Services
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;
    using FeuersoftwareApiHandler.Models;

    /// <summary>
    /// Serviceklasse für die Interaktion mit der Feuersoftware.com-Schnittstelle
    /// </summary>
    public class ApiService
    {
        /// <summary>
        /// Der HTTP-Client zum Senden von Calls gegen den Server
        /// </summary>
        private static readonly HttpClient client = new HttpClient();

        /// <summary>
        /// Das Bearer-Token zur Authentifikation an der Schnittstelle
        /// </summary>
        private string ApiToken { get; set; }

        /// <summary>
        /// Die Basisadresse der Feuersoftware-API (Standardmäßig: https://connectapi.feuersoftware.com)
        /// </summary>
        private string BaseAddress { get; set; }

        /// <summary>
        /// Konstruktor zum Initialisieren der Serviceklasse.
        /// </summary>
        /// <param name="baseAddress">Die Basisadresse der API</param>
        /// <param name="apiToken">Das Bearer-Token zur Authentifikation an der Schnittstelle</param>
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

        /// <summary>
        /// Ruft alle aktiven Einsätze des Standorts ab.
        /// </summary>
        /// <returns>Die Liste der aktiven Einsätze</returns>
        public async Task<IEnumerable<Operation>> GetOperations()
        {
            IEnumerable<Operation> operations = new List<Operation>();
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

        /// <summary>
        /// Sendet einen lokal erstellten Einsatz an die Schnittstelle. Dort wird Alarm ausgelöst, falls das gewünscht ist.
        /// </summary>
        /// <param name="operation">Die lokal erstellte <see cref="LocalOperation"/></param>
        /// <returns>Nichts</returns>
        public async Task PostOperation(LocalOperation operation)
        {
            if (operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "interfaces/public/operation")
            {
                Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(operation), Encoding.UTF8, "application/json")
            };

            await client.SendAsync(request);
        }

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

        /// <summary>
        /// Ruft die Rückmeldungen der Einsatzkräfte zu einem Einsatz anhand der Einsatz-ID ab.
        /// </summary>
        /// <param name="operationId">Die ID des Einsatzes <see cref="Operation"/></param>
        /// <returns>Die Liste der Rückmeldungen der Einsatzkräfte</returns>
        public async Task<IEnumerable<UserStatus>> GetOperationUserStatus(int operationId)
        {
            IEnumerable<UserStatus> userStatus = new List<UserStatus>();
            HttpResponseMessage response = await client.GetAsync("interfaces/public/operation/" + operationId + "/userstatus");
            if (response.IsSuccessStatusCode)
            {
                userStatus = await response.Content.ReadAsAsync<List<UserStatus>>();
            }
            else
            {
                throw new HttpRequestException();
            }

            return userStatus;
        }

        /// <summary>
        /// Sendet eine Rückmeldung einer Einsatzkraft zu einem Einsatz an Connect
        /// </summary>
        /// <param name="userStatus">Die Rückmeldung <see cref="UserStatus"/> der Einsatzkraft</param>
        /// <returns>Nichts</returns>
        public async Task PostOperationUserStatus(UserStatus userStatus)
        {
            if (userStatus == null)
            {
                throw new ArgumentNullException(nameof(userStatus));
            }

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "interfaces/public/operation/userstatus")
            {
                Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(userStatus), Encoding.UTF8, "application/json")
            };

            await client.SendAsync(request);
        }
    }
}
