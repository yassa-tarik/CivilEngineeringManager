using CivilEngineeringManager.ViewModels;
using DTO.TreeDTOs;
using System;

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
