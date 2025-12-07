using MyApplication.Abstractions.Works;

namespace MyApplication.Abstractions.Trees
{
    public interface IProjectWorkDataService
    {
        IProjectService Projects { get; }
        IWorkCategoryService Categories { get; }
        IWorkTypeService Types { get; }
        IWorkSpecService Specs { get; }
    }
}
