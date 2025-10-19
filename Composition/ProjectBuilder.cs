using Domain.Abstractions;
using Domain.Abstractions.Works;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Works;
using MyApplication;
using MyApplication.Abstractions;
using MyApplication.Abstractions.Works;
using MyApplication.Services.Trees;
using MyApplication.Services.Works;

namespace Composition
{
    public class ProjectBuilder
    {
        private readonly IProjectRepository projectRepo = new ProjectRepository();
        private readonly IAddressRepository addressRepo = new AddressRepository();
        public IProjectService BuildProjectService()
        {
            return new ProjectService(projectRepo, addressRepo);
        }
        public IProjectTreeService ProjectTreeService()
        {
            IProjectService projectService = BuildProjectService();
            IWorkCategoryDesignationRepository categoryDesignationRepository = new WorkCategoryDesignationRepository();
            IWorkCategoryDesignationService workCategoryName = new WorkCategoryDesignationService(categoryDesignationRepository);
            IWorkCategoryRepository workCategoryRepo = new WorkCategoryRepository();
            IWorkCategoryService workCategoryService = new WorkCategoryService(workCategoryRepo, workCategoryName);
            IWorkTypeRepository workTypeRepo = new WorkTypeRepository();
            IWorkTypeService workTypeService = new WorkTypeService(workTypeRepo);
            IWorkSpecRepository workSpecRepo = new WorkSpecRepository();
            IWorkSpecService workSpec = new WorkSpecService(workSpecRepo);
            return new ProjectTreeService(projectService, workCategoryRepo, workTypeService, workCategoryService, workSpec);
        }
    }
}
