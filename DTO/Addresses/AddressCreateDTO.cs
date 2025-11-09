namespace DTO.Addresses
{
    public class AddressCreateDTO : AddressBaseDTO
    {
        public AddressCreateDTO(int ID_Country, int ID_City, string municipality, string postalCode, string placeName, string landmark) : base(ID_Country, ID_City, municipality, postalCode, placeName, landmark)
        {
        }
    }
}
