namespace DTO.Addresses
{
    public class AddressUpdateDTO : AddressBaseDTO
    {
        public int ID { get; }

        public AddressUpdateDTO(int ID, int ID_Country, int ID_City, string municipality, string postalCode, string placeName, string landmark)
            : base(ID_Country, ID_City, municipality, postalCode, placeName, landmark)
        {
            this.ID = ID;
        }
    }
}
