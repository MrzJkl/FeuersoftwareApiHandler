namespace FeuersoftwareApiHandler.Models
{
    /// <summary>
    /// Die Rückmeldung einer Einsatzkraft zu einem Einsatz
    /// </summary>
    public class UserStatus
    {
        /// <summary>
        /// Die ID des Einsatzes
        /// </summary>
        public int OperationId { get; set; }

        /// <summary>
        /// Der Benutzername der Einsatzkraft (E-Mail-Adresse)
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Die Rückmeldung als Status
        /// </summary>
        public Status Status { get; set; }
    }
}
