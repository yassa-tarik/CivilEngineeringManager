using DTO.Contact;
using System;

namespace DTO.Subcontractor
{
    public class SubcontractorDTO : ContributorBaseDTO
    {
        public SubcontractorDTO(int iD, int iD_Contact, string raisonSocial, string representant, string numCptBank, DateTime creationDate, int creePar, DateTime modificationDate, int modifierPar, bool isActive, ContactDTO contact) : base(iD, iD_Contact, raisonSocial, representant, numCptBank, creationDate, creePar, modificationDate, modifierPar, isActive, contact)
        {
        }
    }
}
