using DTO.Addresses;
using System;

namespace DTO.Projects
{
    public class ProjectCreateDTO : ProjectBaseDTO
    {
        public AddressDTO AddressDto { get; }
        public ProjectCreateDTO(string name, string projectCode, DateTime startDate, int duration, string projectType, string description, bool isActive, string landRegistry, string subdivisionPermitNumber, DateTime? subdivisionPermitDate, string constructionPermitNumber, DateTime constructionPermitDate, string deedVolume, string deedNumber, string deedFolio, string landBook, DateTime? landBookDate, string landBookBy, bool isSpecComplete, byte progress, AddressDTO addressDto) : base(name, projectCode, startDate, duration, projectType, description, isActive, landRegistry, subdivisionPermitNumber, subdivisionPermitDate, constructionPermitNumber, constructionPermitDate, deedVolume, deedNumber, deedFolio, landBook, landBookDate, landBookBy, isSpecComplete, progress)
        {
            AddressDto = addressDto;
        }
    }
}
