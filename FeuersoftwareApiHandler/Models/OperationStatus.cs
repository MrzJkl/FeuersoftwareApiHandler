namespace FeuersoftwareApiHandler.Models
{
    /// <summary>
    /// Eine Sammlung von konstanten Feldern für den Status eines Einsatzes
    /// </summary>
    public class OperationStatus
    {
        /// <summary>
        /// Neuer Einsatz
        /// </summary>
        public static readonly string New = "new";

        /// <summary>
        /// Einsatzupdate
        /// </summary>
        public static readonly string Update = "update";

        /// <summary>
        /// Einsatzabbruch
        /// </summary>
        public static readonly string Cancel = "cancel";

        /// <summary>
        /// Einsatzende
        /// </summary>
        public static readonly string Close = "close";
    }
}
