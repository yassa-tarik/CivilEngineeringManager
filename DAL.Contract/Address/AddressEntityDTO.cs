namespace DAL.Contract.Address
{
    public class AddressEntityDTO
    {
        public int ID { get; }
        public int ID_Country { get; }
        public int ID_City { get; }
        public string APC { get; }
        public string Street { get; }
        public string PostalCode { get; }
        public string PlaceName { get; }
        public string Landmark { get; }

        public AddressEntityDTO(int id, int idCountry, int idCity, string apc, string street, string postalCode, string placeName, string landmark)
        {
            ID = id;
            ID_Country = idCountry;
            ID_City = idCity;
            APC = apc;
            Street = street;
            PostalCode = postalCode;
            PlaceName = placeName;
            Landmark = landmark;
        }
    }
}
