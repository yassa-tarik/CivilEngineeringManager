using DTO.Addresses;
using System;

namespace DTO.Projects
{
    public class ProjectDTO : ProjectBaseDTO
    {
        public int ID { get; }
        public AddressDTO Address { get; }
        // audit
        public DateTime CreatedDate { get; private set; }
        public DateTime ModificationDate { get; private set; }

        public ProjectDTO(int id, string name, string projectCode, DateTime startDate, int duration, string projectType, string description, bool isActive, string landRegistry, string subdivisionPermitNumber, DateTime? subdivisionPermitDate, string constructionPermitNumber, DateTime constructionPermitDate, string deedVolume, string deedNumber, string deedFolio, string landBook, DateTime? landBookDate, string landBookBy, bool isSpecComplete, byte progress, AddressDTO address, DateTime createdDate, int createdBy, DateTime modificationDate, int modifiedBy, bool isDeleted) : base(name, projectCode, startDate, duration, projectType, description, isActive, landRegistry, subdivisionPermitNumber, subdivisionPermitDate, constructionPermitNumber, constructionPermitDate, deedVolume, deedNumber, deedFolio, landBook, landBookDate, landBookBy, isSpecComplete, progress)
        {
            ID = id;
            CreatedDate = createdDate;
            ModificationDate = modificationDate;
            Address = address;
        }
    }
}
