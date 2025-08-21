using BLL.Domain.Addresses;
using BLL.Domain.Contacts;
using BLL.Mappers.Addesses;
using DAL.Contract.Contacts;
using DTO.Address;
using DTO.Contact;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers.Contacts
{
    internal class ContactMapper
    {
        public static Contact DTOToDomain(ContactDTO dto)
        {
            if (dto == null) return null;

            var addressDomain = AddressMapper.DTOToDomain(dto.Address);

            return new Contact(
                dto.ID,
                dto.ID_Address,
                dto.Telephone,
                dto.Mobile,
                dto.Telecopie,
                dto.Email,
                addressDomain
            );
        }

        public static ContactDTO EntityToDTO(int id,int id_Address,string telephone,string mobile,string telecopie,string email, int idCountry,int idCity,string apc,string street,string postalCode,string lieuDit,string reper)
        {
            var addressDto = new AddressDTO(id_Address, idCountry,idCity,apc,street,postalCode,lieuDit,reper);

            return new ContactDTO(id, id_Address, telephone, mobile, telecopie, email, addressDto);
        }
    }
}
