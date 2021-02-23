using System;
using System.Collections.Generic;
using System.Text;

namespace FeuersoftwareApiHandler.Models
{
    /// <summary>
    /// Benutzer Verfügbarkeit
    /// </summary>
    public class UserAvailability
    {
        /// <summary>
        /// Die Verfügbarkeit des Benutzers
        /// </summary>
        public Availability Status { get; set; }

        /// <summary>
        /// Status gültig bis
        /// </summary>
        public DateTime Until { get; set; }
 
        /// <summary>
        /// Verfügbarkeit Quelle
        /// </summary>
        public AvailabilitySource Source { get; set; }
    }
}
