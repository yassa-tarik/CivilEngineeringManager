using BLL.Domain.Addresses;

namespace BLL.Domain.Contacts
{
    internal class Contact
    {
        public int ID { get; }
        public int ID_Address { get; }
        public string Telephone { get; }
        public string Mobile { get; }
        public string Fax { get; }
        public string Email { get; }
        public Address Address { get; }

        internal Contact(int id, int idAddress, string telephone, string mobile, string fax, string email, Address address)
        {
            ID = id;
            ID_Address = idAddress;
            Telephone = telephone;
            Mobile = mobile;
            Fax = fax;
            Email = email;
            Address = address;
        }
    }
}
