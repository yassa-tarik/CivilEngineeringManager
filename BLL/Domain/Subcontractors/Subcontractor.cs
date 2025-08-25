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
        internal Subcontractor(int iD, int iD_Contact, string companyName, string representative, string bankAccountNumber, DateTime creationDate, int createdBy, DateTime modificationDate, int modifiedBy, bool isActive, Contact contact) : base(iD, iD_Contact, companyName, representative, bankAccountNumber, creationDate, createdBy, modificationDate, modifiedBy, isActive, contact)
        {
            // Validate company name
            if (string.IsNullOrWhiteSpace(companyName))
                throw new ArgumentException("Company name cannot be empty", nameof(companyName));
            if (companyName.Length > 100) // Adjust max length as needed
                throw new ArgumentException("Company name is too long", nameof(companyName));

            // Validate representative name
            if (string.IsNullOrWhiteSpace(representative))
                throw new ArgumentException("Representative name cannot be empty", nameof(representative));
            if (representative.Length > 100) // Adjust max length as needed
                throw new ArgumentException("Representative name is too long", nameof(representative));

            // Validate bank account number
            if (string.IsNullOrWhiteSpace(bankAccountNumber))
                throw new ArgumentException("Bank account number cannot be empty", nameof(bankAccountNumber));
            if (bankAccountNumber.Length > 34) // IBAN max length is 34 characters
                throw new ArgumentException("Bank account number is too long", nameof(bankAccountNumber));

            // Validate creation date (not in future)
            if (creationDate > DateTime.Now)
                throw new ArgumentException("Creation date cannot be in the future", nameof(creationDate));

            // Validate creator ID
            if (createdBy <= 0)
                throw new ArgumentException("Creator ID must be a positive value", nameof(createdBy));

            // Validate modification date (not before creation date)
            if (modificationDate < creationDate)
                throw new ArgumentException("Modification date cannot be before creation date", nameof(modificationDate));

            // Validate modifier ID
            if (modifiedBy <= 0)
                throw new ArgumentException("Modifier ID must be a positive value", nameof(modifiedBy));

            // Validate contact object
            if (contact == null)
                throw new ArgumentNullException(nameof(contact));
            if (contact.ID != iD_Contact)
                throw new ArgumentException("Contact ID mismatch between parameter and DTO", nameof(contact));
        }
       
        // ✅ Factory for new subcontractor
        public static Subcontractor Create(SubcontractorDTO dto, ISubcontractorUniquenessChecker uniquenessChecker)
        {
            if (string.IsNullOrWhiteSpace(dto.CompanyName))
                throw new ArgumentException("RaisonSocial is required.");

            if (uniquenessChecker.ExistsByName(dto.CompanyName))
                throw new InvalidOperationException("Subcontractor already exists.");

            return SubcontractorMapper.DTOToDomain(dto);
        }

        // ✅ Update method
        public void Update(SubcontractorDTO dto, ISubcontractorUniquenessChecker checker)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            // Check uniqueness only if RaisonSocial is being changed
            if (!string.Equals(this.CompanyName, dto.CompanyName, StringComparison.OrdinalIgnoreCase))
            {
                if (checker.ExistsByName(dto.CompanyName))
                    throw new InvalidOperationException($"Another subcontractor already uses the name {dto.CompanyName}.");
            }

            // Apply updates
            base.ID_Contact = dto.ID_Contact;
            this.CompanyName = dto.CompanyName;
            this.Representative = dto.Representative;
            this.BankAccountNumber = dto.BankAccountNumber;

            // CreationDate and CreePar should not normally change on update
            // this.CreationDate = dto.CreationDate;
            // this.CreePar = dto.CreePar;

            this.ModificationDate = DateTime.Now;
            this.ModifiedBy = dto.ModifiedBy;
            this.IsActive = dto.IsActive;

            // Contact is an object — you may want to delegate updating it via a Contact.Update(dto.Contact) instead of full replace
            this.Contact = ContactMapper.DTOToDomain( dto.Contact);
        }

    }
}
