namespace FeuersoftwareApiHandler.Models
{
    using System;
    using System.Collections.Generic;

    public class LocalOperation
    {
        public LocalOperation(DateTimeOffset start, string keyword, string facts, string ric, string address)
        {
            this.Id = 0;
            this.Keyword = keyword;
            this.Facts = facts;
            this.Ric = ric;
            this.Address = address;
            this.Properties = new List<OperationProperty>();
            this.AlarmedVehicles = new List<Vehicle>();
        }

        public int Id { get; set; }

        public DateTimeOffset Start { get; set; }

        public DateTimeOffset? End { get; set; }

        public string Status { get; set; }

        public bool AlarmEnabled { get; set; }

        public string Keyword { get; set; }

        public string Facts { get; set; }

        public string Ric { get; set; }

        public string Address { get; set; }

        public string Number { get; set; }

        public List<OperationProperty> Properties { get; set; }

        public List<Vehicle> AlarmedVehicles { get; set; }

        public Position Position { get; set; }
    }
}
