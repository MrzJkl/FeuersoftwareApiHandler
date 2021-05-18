namespace FeuersoftwareApiHandler.Services
{
    using System;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using FeuersoftwareApiHandler.Models;

    public partial class ApiService
    {
        /// <summary>
        /// Sendet einen Fahrzeug Status an Connect mit der Funkgeräte Kennung
        /// </summary>
        /// <param name="radioId">Die radioId des Fahrzeuges</param>
        /// <param name="vehicleStatus">Den Fahrzeugstatus <see cref="VehicleStatus"/></param>
        /// <returns>Nichts</returns>
        public async Task PostVehicleStatusByRadioId(string radioId, VehicleStatus vehicleStatus)
        {
            if (vehicleStatus == null)
            {
                throw new ArgumentNullException(nameof(vehicleStatus));
            }

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "interfaces/public/vehicle/" + radioId + "/status")
            {
                Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(vehicleStatus), Encoding.UTF8, "application/json")
            };

            await client.SendAsync(request);
        }

        /// <summary>
        /// Sendet einen Fahrzeug Status an Connect mit der Id
        /// </summary>
        /// <param name="id">Die Connect Id des Fahrzeuges</param>
        /// <param name="vehicleStatus">Den Fahrzeugstatus <see cref="VehicleStatus"/></param>
        /// <returns>Nichts</returns>
        public async Task PostVehicleStatus(int id, VehicleStatus vehicleStatus)
        {
            if (vehicleStatus == null)
            {
                throw new ArgumentNullException(nameof(vehicleStatus));
            }

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "interfaces/public/vehicle/" + id + "/status")
            {
                Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(vehicleStatus), Encoding.UTF8, "application/json")
            };

            await client.SendAsync(request);
        }

        /// <summary>
        /// Gibt den Fahrzeug Status einer bestimmten Id
        /// </summary>
        /// <param name="id">Die Connect Id des Fahrzeuges</param>
        /// <returns>Fahrzeug Status</returns>
        public async Task<VehicleStatus> GetVehicleStatusById(int id)
        {
            VehicleStatus vehicleStatus = new VehicleStatus();
            HttpResponseMessage response = await client.GetAsync("interfaces/public/vehicle/" + id + "/status");
            if (response.IsSuccessStatusCode)
            {
                vehicleStatus = await response.Content.ReadAsAsync<VehicleStatus>();
            }
            else
            {
                throw new HttpRequestException();
            }

            return vehicleStatus;
        }

        /// <summary>
        /// Gibt den Fahrzeug Status einer bestimmten RadioId
        /// </summary>
        /// <param name="radioId">Die radioId des Fahrzeuges</param>
        /// <returns>Fahrzeug Status</returns>
        public async Task<VehicleStatus> GetVehicleStatusByRadioId(string radioId)
        {
            VehicleStatus vehicleStatus = new VehicleStatus();
            HttpResponseMessage response = await client.GetAsync("interfaces/public/vehicle/" + radioId + "/status");
            if (response.IsSuccessStatusCode)
            {
                vehicleStatus = await response.Content.ReadAsAsync<VehicleStatus>();
            }
            else
            {
                throw new HttpRequestException(response.StatusCode.ToString());
            }

            return vehicleStatus;
        }
    }
}