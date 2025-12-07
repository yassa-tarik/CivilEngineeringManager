using Domain.Entities;
using DTO.Subcontractors;
using System.Collections.Generic;
using System.Linq;

namespace MyApplication.Mappers
{
    internal class SubcontractorMapper
    {
        public static Subcontractor DTOToDomain(SubcontractorDTO dto)
        {
            if (dto == null) return null;

            var caontactDTO = ContactMapper.DTOToDomain(dto.Contact);

            return new Subcontractor(
                dto.CompanyName,
                dto.Representative,
                dto.BankAccountNumber,
                caontactDTO,
                dto.IsActive,
                dto.IsDeleted
            );
        }

        public static SubcontractorDTO DomainToDTO(Subcontractor domain)
        {
            if (domain == null) return null;
            var contact = ContactMapper.DomainToDTO(domain.Contact);

            return new SubcontractorDTO(
                domain.ID,
                domain.CompanyName,
                domain.Representative,
                domain.BankAccountNumber,
                domain.IsActive,
                domain.IsDeleted,
                contact
            );
        }

        public static Subcontractor CreateDTOToDomain(SubcontractorCreateDTO dto)
        {
            if (dto == null) return null;
            var contact = ContactMapper.DTOToDomain(dto.ContactDTO);

            return new Subcontractor(
                dto.CompanyName,
                dto.Representative,
                dto.BankAccountNumber,
                contact,
                dto.IsActive,
                dto.IsDeleted
            );
        }

        internal static List<SubcontractorDTO> DomainsToDtoList(List<Subcontractor> subcontractors)
        {
            if (subcontractors == null) return null;
            return subcontractors.Select(s => DomainToDTO(s)).ToList();
        }
    }
}
