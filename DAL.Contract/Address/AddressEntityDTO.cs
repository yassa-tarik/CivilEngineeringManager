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
        public string LieuDit { get; }
        public string Reper { get; }

        public AddressEntityDTO(int id, int idCountry, int idCity, string apc, string street, string postalCode, string lieuDit, string reper)
        {
            ID = id;
            ID_Country = idCountry;
            ID_City = idCity;
            APC = apc;
            Street = street;
            PostalCode = postalCode;
            LieuDit = lieuDit;
            Reper = reper;
        }
    }
}
