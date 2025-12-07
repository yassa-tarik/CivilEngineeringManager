using System;

namespace Domain.Entities
{
    public class Contact
    {
        public string Telephone { get; set; }
        public string Mobile { get; set; }
        public string Telecopy { get; set; }
        public string Email { get; set; }
        public Address Address { get; private set; }

        public Contact(string telephone, string mobile, string telecopy, string email, Address address)
        {
            if (address == null) throw new ArgumentNullException("address");

            if (string.IsNullOrWhiteSpace(telephone))
                throw new ArgumentException("Telephone cannot be empty.");

            if (string.IsNullOrWhiteSpace(mobile))
                throw new ArgumentException("Mobile cannot be empty.");


            Telephone = telephone;
            Mobile = mobile;
            Telecopy = telecopy;
            Email = email;
            Address = address;
        }
    }
}
