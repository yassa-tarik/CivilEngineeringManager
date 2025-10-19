namespace DTO.Addresses
{
    public class AddressUpdateDTO : AddressBaseDTO
    {
        public int ID { get; }

        public AddressUpdateDTO(int ID, int ID_Country, int ID_City, string APC, string street, string postalCode, string placeName, string landmark)
            : base(ID_Country, ID_City, APC, street, postalCode, placeName, landmark)
        {
            this.ID = ID;
        }
    }
}
