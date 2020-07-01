namespace FeuersoftwareApiHandler.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Ein Einsatz, der lokal erstellt wurde und zum Server gesendet werden soll
    /// </summary>
    public class LocalOperation
    {
        /// <summary>
        /// Der Konstruktor für einen lokal erstellten Einsatz mit allen benötigten Parametern. Andere können später noch gesetzt werden.
        /// </summary>
        /// <param name="start">Der Startzeitpunkt</param>
        /// <param name="keyword">Das Stichwort</param>
        /// <param name="facts">Der Sachverhalt</param>
        /// <param name="ric">Die RIC</param>
        /// <param name="address">Die Adresse</param>
        public LocalOperation(string keyword, string facts, string ric, string address)
        {
            this.Id = 0;
            this.Keyword = keyword;
            this.Facts = facts;
            this.Ric = ric;
            this.Address = address;
            this.Start = DateTimeOffset.Now;
            this.Properties = new List<OperationProperty>();
            this.AlarmedVehicles = new List<Vehicle>();
        }

        /// <summary>
        /// Die ID des Einsatzes in Connect
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Der Startzeitpunkt
        /// </summary>
        public DateTimeOffset Start { get; set; }

        /// <summary>
        /// Der Endzeitpunkt
        /// </summary>
        public DateTimeOffset? End { get; set; }

        /// <summary>
        /// Der Status des Einsatzes
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gibt an, ob der Einsatz alarmiert werden soll
        /// </summary>
        public bool AlarmEnabled { get; set; }

        /// <summary>
        /// Das Stichwort
        /// </summary>
        public string Keyword { get; set; }

        /// <summary>
        /// Der Sachverhalt
        /// </summary>
        public string Facts { get; set; }

        /// <summary>
        /// Die RIC
        /// </summary>
        public string Ric { get; set; }

        /// <summary>
        /// Die Adresse
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Die Einsatznummer
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Die benutzerdefinierten Felder zum Einsatz
        /// </summary>
        public List<OperationProperty> Properties { get; set; }

        /// <summary>
        /// Die alarmierten Fahrzeuge
        /// </summary>
        public List<Vehicle> AlarmedVehicles { get; set; }

        /// <summary>
        /// Die Positionsdaten
        /// </summary>
        public Position Position { get; set; }
    }
}
