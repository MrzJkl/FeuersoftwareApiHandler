using System;
using System.Collections.Generic;
using System.Text;

namespace FeuersoftwareApiHandler.Models
{
    /// <summary>
    /// Enum für die Quelle einer Verfügbarkeit
    /// </summary>
    public enum AvailabilitySource
    {
        none = 0,
        manual = 1,
        pager = 2,
        auto = 3,
        scheduled = 4,
        scheduledRecurring = 5,
    }
}

