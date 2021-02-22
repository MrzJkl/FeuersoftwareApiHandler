using System;

namespace FeuersoftwareApiHandler.Models
{
    /// <summary>
    /// Ein Fahrzeug Status
    /// </summary>
    public class VehicleStatus
    {
        /// <summary>
        /// Der Status des Fahrzeuges
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// Dies Position des Fahrzeuges
        /// </summary>
        public Position Position { get; set; }

        /// <summary>
        /// Der Timestamp des Status
        /// </summary>
        public DateTime StatusTimestamp { get; set; }

        /// <summary>
        /// Der Timestamp der Position
        /// </summary>
        public DateTime PositionTimestamp { get; set; }
    }
}
