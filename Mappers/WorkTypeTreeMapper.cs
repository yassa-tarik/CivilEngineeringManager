using CivilEngineeringManager.Helpers.Tree;
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
    internal static class WorkTypeTreeMapper
    {
        internal static TreeNodeViewModel FromWorkType(WorkTypeTreeDTO dto)
        {
            //var children = TreeViewConverters.MergeTypesAndSpecsLists(dto.WorkTypes, dto.WorkSpecs);
            if (dto == null) throw new ArgumentNullException("invalid data");
            return new TreeNodeViewModel(
                dto.ID,
                dto.Designation,
                null,
                null,
                null,
                null,
                dto.WorkTypes,
                dto.WorkSpecs
            );
        }
    }
}
