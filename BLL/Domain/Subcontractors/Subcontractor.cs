using BLL.Domain.Contacts;
using BLL.Domain.Subcontractors;
using BLL.Mappers.Contacts;
using DTO.Subcontractor;
using System;

namespace BLL.Domain
{
    internal class Subcontractor : ContributorsBase
    {
        internal Subcontractor(int iD, int iD_Contact, string raisonSocial, string representant, string numCptBank, DateTime creationDate, int creePar, DateTime modificationDate, int modifierPar, bool isActive, Contact contact) : base(iD, iD_Contact, raisonSocial, representant, numCptBank, creationDate, creePar, modificationDate, modifierPar, isActive, contact)
        {
        }
        internal static Subcontractor AddEdit(SubcontractorDTO dto)
        {
            //TODO: implement validation logic here
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto) + "is empty");
            }
            /*
            if (dto == null)
                throw new DomainException("Subcontractor data is missing.");

            if (string.IsNullOrWhiteSpace(dto.Name))
                throw new DomainException("Name is required.");

            if (string.IsNullOrWhiteSpace(dto.MatriculeFiscale))
                throw new DomainException("Matricule Fiscale is required.");

            if (dto.Contact == null || dto.Contact.Id <= 0)
                throw new DomainException("Valid contact is required.");

            if (dto.Address == null || dto.Address.Id <= 0)
                throw new DomainException("Valid address is required.");
            */
            return new Subcontractor(dto.ID, dto.ID_Contact, dto.RaisonSocial, dto.Representant, dto.NumCptBank, dto.CreationDate, dto.CreePar, dto.ModificationDate, dto.ModifierPar, dto.IsActive, ContactMapper.DTOToDomain(dto.Contact));
        }

        //TODO: implement logic, validations and rules specific to subcontractors
    }
}
