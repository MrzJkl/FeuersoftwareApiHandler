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
    public partial class ApiService
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
        /// Die Basisadresse der Feuersoftware-API (Standard: https://connectapi.feuersoftware.com)
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
    }
}
