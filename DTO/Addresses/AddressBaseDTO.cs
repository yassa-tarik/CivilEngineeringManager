namespace DTO.Addresses
{
    public class AddressBaseDTO
    {
        public int ID_Country { get; }
        public int ID_City { get;  }
        public string Municipality { get; }
        public string PostalCode { get; }
        public string PlaceName { get; }
        public string Landmark { get; }

        public AddressBaseDTO(int ID_Country, int ID_City, string municipality, string postalCode, string placeName, string landmark)
        {
            this.ID_Country = ID_Country;
            this.ID_City = ID_City;
            this.Municipality = municipality;
            this.PostalCode = postalCode;
            this.PlaceName = placeName;
            this.Landmark = landmark;
        }
    }
}
