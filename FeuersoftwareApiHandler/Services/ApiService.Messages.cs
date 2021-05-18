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
        /// Ruft alle Lagemeldungen eines Einsatzes von der Schnittstelle ab
        /// </summary>
        /// <param name="operationIdOrNumber">ID oder Einsatznummer des Einsatzes</param>
        /// <returns>Die Liste der Lagemeldungen des Einsatzes</returns>
        public async Task<IEnumerable<Message>> GetMessage(string operationIdOrNumber)
        {
            if (String.IsNullOrWhiteSpace(operationIdOrNumber))
            {
                throw new ArgumentNullException(nameof(operationIdOrNumber));
            }

            IEnumerable<Message> news = new List<Message>();
            HttpResponseMessage response = await client.GetAsync($"interfaces/public/operation/{operationIdOrNumber}/message");
            if (response.IsSuccessStatusCode)
            {
                news = await response.Content.ReadAsAsync<List<Message>>();
            }
            else
            {
                throw new HttpRequestException();
            }

            return news;
        }

        /// <summary>
        /// Sendet eine Message zu einem Einsatz an die Schnittstelle
        /// </summary>
        /// <param name="message">Die Lagemeldung</param>
        /// <param name="operationIdOrNumber">Die ID oder Einsatznummer des Einsatzes</param>
        /// <returns></returns>
        public async Task PostMessage(Message message, string operationIdOrNumber)
        {
            if (message == null || String.IsNullOrWhiteSpace(operationIdOrNumber))
            {
                throw new ArgumentNullException();
            }

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, $"interfaces/public/operation/{operationIdOrNumber}/message")
            {
                Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(message), Encoding.UTF8, "application/json")
            };

            await client.SendAsync(request);
        }
    }
}