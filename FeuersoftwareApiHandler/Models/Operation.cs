namespace FeuersoftwareApiHandler.Models
{
    using System;
    using System.Collections.Generic;

    public class Operation
    {
        public int Id { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public string Keyword { get; set; }

        public string Category { get; set; }

        public string Facts { get; set; }

        public string Ric { get; set; }

        public AddressModel Address { get; set; }

        public string Number { get; set; }

        public List<OperationProperty> Properties { get; set; }

        public int SiteId { get; set; }

        public List<Vehicle> AlarmedVehicles { get; set; }
    }
}
