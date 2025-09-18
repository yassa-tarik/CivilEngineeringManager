using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Subcontractors
{
    /// <summary>
    /// A data transfer object (DTO) used to create a new subcontractor.
    /// Inherits common properties from SubcontractorBaseDto.
    /// </summary>
    public class SubcontractorCreateDTO : SubcontractorBaseDTO
    {
        /// <summary>
        /// Initializes a new instance of the SubcontractorCreateDto class.
        /// It calls the base class constructor to initialize common properties.
        /// </summary>
        public SubcontractorCreateDTO(string companyName, string representative, string bankAccountNumber, bool isActive)
            : base(companyName, representative, bankAccountNumber, isActive)
        {
        }
    }
}
