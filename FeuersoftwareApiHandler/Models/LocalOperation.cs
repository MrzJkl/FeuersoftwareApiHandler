using Newtonsoft.Json;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace FeuersoftwareApiHandler.Models
{
    public class LocalOperation
    {
        public int Id { get; set; }

        public DateTimeOffset Start { get; set; }

        public DateTimeOffset End { get; set; }

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
