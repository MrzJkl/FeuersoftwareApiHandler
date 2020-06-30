namespace FeuersoftwareApiHandler.Models
{
    public class AddressModel
    {
        public string Address { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string CityWithDistrict { get; set; }
        public string CityWithDistrictAndZipCode { get; set; }
        public string StreetWithHouseNumber { get; set; }
        public decimal Lng { get; set; }
        public decimal Lat { get; set; }
    }
}
