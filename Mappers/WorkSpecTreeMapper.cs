using CivilEngineeringManager.ViewModels;
using DTO.TreeDTOs;
using DTO.Works.WorkSpecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivilEngineeringManager.Mappers
{
    internal static class WorkSpecTreeMapper
    {
        internal static TreeNodeViewModel FromWorkSpec(WorkSpecDTO dto)
        {
            if (dto == null) throw new ArgumentNullException("invalid data");
            return new TreeNodeViewModel(
                dto.ID,
                dto.Designation,
                dto.Unit,
                dto.UnitPrice,
                dto.Quantity,
                dto.Amount,
                null,
                null);
        }
    }
}
