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
    }
}