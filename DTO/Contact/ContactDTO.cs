using DTO.Address;

namespace DTO.Contact
{
    public class ContactDTO
    {
        // DTO for Getting Contact (without ID)
        public int ID { get; set; } = default;
        public int ID_Address { get; } = default;
        public string Telephone { get; }
        public string Mobile { get; }
        public string Telecopie { get; }
        public string Email { get; }
        public AddressDTO Address { get; }//TODO: refactor it later to Create Get and Create DTO's
        public ContactDTO(int ID, int ID_Address, string telephone, string mobile, string telecopie, string email, AddressDTO Address)
        {
            this.ID = ID;
            this.ID_Address = ID_Address;
            this.Telephone = telephone;
            this.Mobile = mobile;
            this.Telecopie = telecopie;
            this.Email = email;
            this.Address = Address;
        }
    }
}
