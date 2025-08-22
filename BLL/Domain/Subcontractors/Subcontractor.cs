using BLL.Domain.Contacts;
using BLL.Domain.Subcontractors;
using BLL.Mappers.Contacts;
using BLL.Mappers.Subcontractors;
using DAL.Interfaces.Subcontractor;
using DTO.Subcontractor;
using System;

namespace BLL.Domain
{
    internal class Subcontractor : ContributorsBase
    {
        internal Subcontractor(int iD, int iD_Contact, string raisonSocial, string representant, string numCptBank, DateTime creationDate, int creePar, DateTime modificationDate, int modifierPar, bool isActive, Contact contact) : base(iD, iD_Contact, raisonSocial, representant, numCptBank, creationDate, creePar, modificationDate, modifierPar, isActive, contact)
        {
        }
       
        // ✅ Factory for new subcontractor
        public static Subcontractor Create(SubcontractorDTO dto, ISubcontractorUniquenessChecker uniquenessChecker)
        {
            if (string.IsNullOrWhiteSpace(dto.RaisonSocial))
                throw new ArgumentException("RaisonSocial is required.");

            if (uniquenessChecker.ExistsByName(dto.RaisonSocial))
                throw new InvalidOperationException("Subcontractor already exists.");

            return SubcontractorMapper.DTOToDomain(dto);
        }

        // ✅ Update method
        public void Update(SubcontractorDTO dto, ISubcontractorUniquenessChecker checker)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            // Check uniqueness only if RaisonSocial is being changed
            if (!string.Equals(this.RaisonSocial, dto.RaisonSocial, StringComparison.OrdinalIgnoreCase))
            {
                if (checker.ExistsByName(dto.RaisonSocial))
                    throw new InvalidOperationException($"Another subcontractor already uses the name {dto.RaisonSocial}.");
            }

            // Apply updates
            base.ID_Contact = dto.ID_Contact;
            this.RaisonSocial = dto.RaisonSocial;
            this.Representant = dto.Representant;
            this.NumCptBank = dto.NumCptBank;

            // CreationDate and CreePar should not normally change on update
            // this.CreationDate = dto.CreationDate;
            // this.CreePar = dto.CreePar;

            this.ModificationDate = DateTime.Now;
            this.ModifierPar = dto.ModifierPar;
            this.IsActive = dto.IsActive;

            // Contact is an object — you may want to delegate updating it via a Contact.Update(dto.Contact) instead of full replace
            this.Contact = ContactMapper.DTOToDomain( dto.Contact);
        }

    }
}
