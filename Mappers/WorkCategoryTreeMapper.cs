using CivilEngineeringManager.ViewModels;
using DTO.TreeDTOs;
using System;

namespace CivilEngineeringManager.Mappers
{
    internal static class WorkCategoryTreeMapper
    {
        internal static TreeNodeViewModel FromWorkCategory(WorkCategoryTreeDTO root)
        {
            //var children = TreeViewConverters.MergeTypesAndSpecsLists(root.WorkTypes, root.WorkSpecs);
            if (root == null) throw new ArgumentNullException("invalid data");
            return new TreeNodeViewModel(
                root.ID,
                root.Designation,
                null,
                null,
                null,
                //null,
                //dto.WorkTypes);
                //root.WorkTypes.Select(wt => WorkTypeTreeMapper.FromWorkType(wt))
                root.WorkTypes,
                root.WorkSpecs
                );
        }
    }
}
