using DTO.Addresses;

namespace DTO.Contacts
{
    public class ContactDTO
    {
        public string Telephone { get; }
        public string Mobile { get; }
        public string Telecopy { get; }
        public string Email { get; }
        public AddressDTO Address { get; }

        public ContactDTO(string telephone, string mobile, string telecopy, string email, AddressDTO address)
        {
            Telephone = telephone;
            Mobile = mobile;
            Telecopy = telecopy;
            Email = email;
            Address = address;
        }
    }
}
