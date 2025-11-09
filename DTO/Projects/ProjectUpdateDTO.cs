using DTO.Addresses;
using System;

namespace DTO.Projects
{
    public class ProjectUpdateDTO : ProjectBaseDTO
    {
        public int ID { get; }
        public AddressUpdateDTO AddressUpdate { get; }

        public ProjectUpdateDTO(int iD, string name, string projectCode, DateTime startDate, int duration, string projectType, string description, bool isActive, string landRegistry, string subdivisionPermitNumber, DateTime? subdivisionPermitDate, string constructionPermitNumber, DateTime constructionPermitDate, string deedVolume, string deedNumber, string deedFolio, string landBook, DateTime? landBookDate, string landBookBy, bool isSpecComplete, byte progress, AddressUpdateDTO addressUpdate) : base(name, projectCode, startDate, duration, projectType, description, isActive, landRegistry, subdivisionPermitNumber, subdivisionPermitDate, constructionPermitNumber, constructionPermitDate, deedVolume, deedNumber, deedFolio, landBook, landBookDate, landBookBy, isSpecComplete, progress)
        {
            this.ID = iD;
            this.AddressUpdate = addressUpdate;
        }
    }
}
