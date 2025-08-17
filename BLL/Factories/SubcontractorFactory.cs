using BLL.Domain;
using DTO.Subcontractor;
using System;

namespace BLL.Factories
{
    public static class SubcontractorFactory
    {
        /// <summary>
        /// Creates a new domain entity from a DTO for insertion or business rule processing.
        /// </summary>
        internal static Subcontractor CreateFromDTO(SubcontractorDTO dto)
        {
            throw new NotImplementedException();
            //if (dto == null)
            //    throw new ArgumentNullException(nameof(dto), "DTO cannot be null.");

            //return Subcontractor.Create(
            //    name: dto.Name,
            //    matriculeFiscale: dto.MatriculeFiscale,
            //    contactId: dto.Contact?.Id ?? 0,
            //    addressId: dto.Address?.Id ?? 0,
            //    createdAt: dto.CreatedAt,
            //    id: dto.Id // if 0, Create() will treat it as new
            //);
        }
    }
}
