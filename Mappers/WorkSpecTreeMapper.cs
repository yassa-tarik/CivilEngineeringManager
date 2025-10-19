using CivilEngineeringManager.ViewModels;
using DTO.Works.WorkSpecs;
using System;

namespace CivilEngineeringManager.Mappers
{
    internal static class WorkSpecTreeMapper
    {
        internal static TreeNodeViewModel FromWorkSpec(WorkSpecUpdateDTO dto)
        {
            if (dto == null) throw new ArgumentNullException("invalid data");
            return new TreeNodeViewModel(
                dto.ID,
                dto.Designation,
                dto.Unit,
                dto.UnitPrice,
                dto.Quantity,
                //dto.Amount,
                null,
                null);
        }
    }
}
