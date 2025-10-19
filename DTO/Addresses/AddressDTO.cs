namespace DTO.Addresses
{
    public class AddressDTO : AddressBaseDTO
    {
        public AddressDTO(int id, int ID_Country, int ID_City, string APC, string street, string postalCode, string placeName, string landmark) : base(ID_Country, ID_City, APC, street, postalCode, placeName, landmark)
        {
            this.ID = id;
        }

        internal int ID { get; private set; }
    }
}
