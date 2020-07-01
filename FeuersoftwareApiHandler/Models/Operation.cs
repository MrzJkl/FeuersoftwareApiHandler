namespace FeuersoftwareApiHandler.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Ein Einsatz, der in Connect existiert
    /// </summary>
    public class Operation
    {
        /// <summary>
        /// Die ID des Einsatzes von Connect
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Der Startzeitpunkt
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        /// Der Endzeitpunkt
        /// </summary>
        public DateTime? End { get; set; }

        /// <summary>
        /// Das Stichwort
        /// </summary>
        public string Keyword { get; set; }

        /// <summary>
        /// Die Einsatzkategorie
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Der Sachverhalt
        /// </summary>
        public string Facts { get; set; }

        /// <summary>
        /// Die RIC
        /// </summary>
        public string Ric { get; set; }

        /// <summary>
        /// Die Adresse des Einsatzes als Model
        /// </summary>
        public AddressModel Address { get; set; }

        /// <summary>
        /// Die Einsatznummer
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Die benutzerdefinierten Felder des Einsatzes
        /// </summary>
        public List<OperationProperty> Properties { get; set; }

        /// <summary>
        /// Die ID des Standorts, zu dem der Einsatz gehört
        /// </summary>
        public int SiteId { get; set; }

        /// <summary>
        /// Die alarmierten Fahrzeuge
        /// </summary>
        public List<Vehicle> AlarmedVehicles { get; set; }
    }
}
