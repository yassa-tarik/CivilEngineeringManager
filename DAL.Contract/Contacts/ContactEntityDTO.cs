using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contract.Contacts
{
    public class ContactEntityDTO
    {
        public int ID { get; }
        public int ID_Address { get; }
        public string Telephone { get; }
        public string Mobile { get; }
        public string Telecopie { get; }
        public string Email { get; }

        public ContactEntityDTO(
            int id,
            int idAddress,
            string telephone,
            string mobile,
            string telecopie,
            string email)
        {
            ID = id;
            ID_Address = idAddress;
            Telephone = telephone;
            Mobile = mobile;
            Telecopie = telecopie;
            Email = email;
        }
    }
}
