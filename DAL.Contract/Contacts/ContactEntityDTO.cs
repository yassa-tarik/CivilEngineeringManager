namespace DAL.Contract.Contacts
{
    public class ContactEntityDTO
    {
        public int ID { get; }
        public int ID_Address { get; }
        public string Telephone { get; }
        public string Mobile { get; }
        public string Fax { get; }
        public string Email { get; }

        public ContactEntityDTO(
            int id,
            int idAddress,
            string telephone,
            string mobile,
            string fax,
            string email)
        {
            ID = id;
            ID_Address = idAddress;
            Telephone = telephone;
            Mobile = mobile;
            Fax = fax;
            Email = email;
        }
    }
}
