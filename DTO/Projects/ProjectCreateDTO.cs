using DTO.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Projects
{
    public class ProjectCreateDTO : ProjectBaseDTO
    {
        public AddressCreateDTO AddressCreate { get; }
        public ProjectCreateDTO(string name, string projectCode, DateTime startDate, int duration, string projectType, string description, bool isActive, string landRegistry, string subdivisionPermitNumber, DateTime? subdivisionPermitDate, string constructionPermitNumber, DateTime constructionPermitDate, string deedVolume, string deedNumber, string deedFolio, string landBook, DateTime? landBookDate, string landBookBy, bool isSpecComplete, byte progress, AddressCreateDTO addressCreate, int createdBy, int modifiedBy) : base(name, projectCode, startDate, duration, projectType, description, isActive, landRegistry, subdivisionPermitNumber, subdivisionPermitDate, constructionPermitNumber, constructionPermitDate, deedVolume, deedNumber, deedFolio, landBook, landBookDate, landBookBy, isSpecComplete, progress, createdBy, modifiedBy)
        {
            AddressCreate = addressCreate;
        }
    }
}
