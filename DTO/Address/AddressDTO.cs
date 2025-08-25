namespace DTO.Address
{
    public class AddressDTO
    {
        public int ID { get; }
        public int ID_Country { get; }
        public int ID_City { get; }
        public string APC { get; }
        public string Street { get; }
        public string PostalCode { get; }
        public string PlaceName { get; }
        public string Landmark { get; }

        public AddressDTO(int id, int Id_Country, int Id_City, string apc, string street, string postalCode, string placeName, string landmark)
        {
            ID = id;
            ID_Country = Id_Country;
            ID_City = Id_City;
            APC = apc;
            Street = street;
            PostalCode = postalCode;
            PlaceName = placeName;
            Landmark = landmark;
        }
    }
}
