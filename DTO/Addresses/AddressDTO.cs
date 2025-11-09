namespace DTO.Addresses
{
    public class AddressDTO : AddressBaseDTO
    {
        public AddressDTO(int id, int ID_Country, int ID_City, string municipality, string postalCode, string placeName, string landmark) : base(ID_Country, ID_City, municipality, postalCode, placeName, landmark)
        {
            this.ID = id;
        }

        public int ID { get; private set; }
    }
}
