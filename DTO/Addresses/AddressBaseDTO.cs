namespace DTO.Addresses
{
    public class AddressBaseDTO
    {
        public int Country_ID { get; }
        public int City_ID { get; }
        public string Municipality { get; }
        public string PostalCode { get; }
        public string PlaceName { get; }
        public string Landmark { get; }

        public AddressBaseDTO(int country_ID, int city_ID, string municipality, string postalCode, string placeName, string landmark)
        {
            this.Country_ID = country_ID;
            this.City_ID = city_ID;
            this.Municipality = municipality;
            this.PostalCode = postalCode;
            this.PlaceName = placeName;
            this.Landmark = landmark;
        }
    }
}
