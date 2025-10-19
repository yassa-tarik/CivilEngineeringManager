using CivilEngineeringManager.Mappers;
using CivilEngineeringManager.ViewModels;
using DTO.TreeDTOs;
using DTO.Works.WorkSpecs;
using System.Collections.Generic;
using System.Linq;

namespace CivilEngineeringManager.Helpers.Tree
{
    internal static class TreeViewConverters
    {
        internal static List<TreeNodeViewModel> CombineTypeWithSpecLists(ICollection<WorkTypeTreeDTO> workTypes, ICollection<WorkSpecUpdateDTO> workSpecs)
        {
            var mainList = new List<TreeNodeViewModel>();
            var typesTreeView = workTypes.Select(wt => WorkTypeTreeMapper.FromWorkType(wt));
            var specsTreeView = workSpecs.Select(ws => WorkSpecTreeMapper.FromWorkSpec(ws));
            mainList.AddRange(typesTreeView);
            mainList.AddRange(specsTreeView);
            return mainList;
        }

        internal static List<TreeNodeViewModel> MergeTypesAndSpecsLists(TreeNodeViewModel parent)
        {
            var children = new List<TreeNodeViewModel>();
            var typesTreeView = parent.WorkTypes.Select(wt => WorkTypeTreeMapper.FromWorkType(wt));
            var specsTreeView = parent.WorkSpecs.Select(ws => WorkSpecTreeMapper.FromWorkSpec(ws));
            children.AddRange(typesTreeView);
            children.AddRange(specsTreeView);
            return children;
        }
    }
}
