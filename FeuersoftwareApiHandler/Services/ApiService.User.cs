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

        /// <summary>
        /// Aktualisiert die Benutzer Verfügbarkeit
        /// </summary>
        /// <param name="id">Die Benutzer Id oder radioId</param>
        /// <param name="userAvailability">Die Benutzer Verfügbarkeit</param>
        /// <returns>Nichts</returns>
        public async Task PutUserAvailability(string id, UserAvailability userAvailability)
        {
            if (userAvailability == null)
            {
                throw new ArgumentNullException(nameof(userAvailability));
            }

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, "interfaces/public/user/"+id+"/availability/current")
            {
                Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(userAvailability), Encoding.UTF8, "application/json")
            };
            System.Text.Json.JsonSerializer.Serialize(userAvailability);
            await client.SendAsync(request);
        }
    }
}