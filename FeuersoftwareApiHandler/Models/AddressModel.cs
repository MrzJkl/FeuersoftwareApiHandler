namespace FeuersoftwareApiHandler.Models
{
    /// <summary>
    /// Model für eine vom Server verarbeitete Adresse.
    /// </summary>
    public class AddressModel
    {
        /// <summary>
        /// Die gesamte Adresse als String
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Die Straße
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Die Hausnummer
        /// </summary>
        public string HouseNumber { get; set; }

        /// <summary>
        /// Die Postleitzahl
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// Die Stadt
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Der Orts-/Stadtteil
        /// </summary>
        public string District { get; set; }

        /// <summary>
        /// Die Stadt mit Orts-/Stadtteil
        /// </summary>
        public string CityWithDistrict { get; set; }

        /// <summary>
        /// Die Stadt mit Orts-/Stadtteil und Postleitzahl
        /// </summary>
        public string CityWithDistrictAndZipCode { get; set; }

        /// <summary>
        /// Die Straße mit Hausnummer
        /// </summary>
        public string StreetWithHouseNumber { get; set; }

        /// <summary>
        /// Der Längengrad
        /// </summary>
        public decimal Lng { get; set; }

        /// <summary>
        /// Der Breitengrad
        /// </summary>
        public decimal Lat { get; set; }
    }
}
