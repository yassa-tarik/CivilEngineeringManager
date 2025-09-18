using DTO.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Projects
{
    public class ProjectUpdateDTO : ProjectBaseDTO
    {
        public int ID { get; }
        public AddressUpdateDTO AddressUpdate { get; }

        public ProjectUpdateDTO(int iD, string name, string projectCode, DateTime startDate, int duration, string projectType, string description, bool isActive, string landRegistry, string subdivisionPermitNumber, DateTime? subdivisionPermitDate, string constructionPermitNumber, DateTime constructionPermitDate, string deedVolume, string deedNumber, string deedFolio, string landBook, DateTime? landBookDate, string landBookBy, bool isSpecComplete, byte progress, AddressUpdateDTO addressUpdate, int createdBy, int modifiedBy) : base(name, projectCode, startDate, duration, projectType, description, isActive, landRegistry, subdivisionPermitNumber, subdivisionPermitDate, constructionPermitNumber, constructionPermitDate, deedVolume, deedNumber, deedFolio, landBook, landBookDate, landBookBy, isSpecComplete, progress, createdBy, modifiedBy)
        {
            this.ID = iD;
            this.AddressUpdate = addressUpdate;
        }       
    }
}
