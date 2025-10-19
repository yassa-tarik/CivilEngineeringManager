namespace DTO.Addresses
{
    public class AddressBaseDTO
    {
        public int ID_Country { get; }
        public int ID_City { get; }
        public string APC { get; }
        public string Street { get; }
        public string PostalCode { get; }
        public string PlaceName { get; }
        public string Landmark { get; }

        public AddressBaseDTO(int ID_Country, int ID_City, string APC, string street, string postalCode, string placeName, string landmark)
        {
            this.ID_Country = ID_Country;
            this.ID_City = ID_City;
            this.APC = APC;
            this.Street = street;
            this.PostalCode = postalCode;
            this.PlaceName = placeName;
            this.Landmark = landmark;
        }
    }
}
