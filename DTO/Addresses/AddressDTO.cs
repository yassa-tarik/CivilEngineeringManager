namespace DTO.Addresses
{
    public class AddressDTO : AddressBaseDTO
    {
        public AddressDTO(int country_ID, int city_ID, string municipality, string postalCode, string placeName, string landmark) : base(country_ID, city_ID, municipality, postalCode, placeName, landmark)
        {
        }
    }
}
