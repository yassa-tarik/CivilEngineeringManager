using Domain.Abstractions;
using Domain.Abstractions.Works;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Works;
using MyApplication;
using MyApplication.Abstractions;
using MyApplication.Abstractions.Works;
using MyApplication.Services.Trees;
using MyApplication.Services.Works;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            IWorkCategoryNameService workCategoryName = new WorkCategoryNameService();
            IWorkCategoryRepository workCategoryRepo = new WorkCategoryRepository();
            IWorkCategoryService workCategoryService = new WorkCategoryService(workCategoryRepo, workCategoryName);
            IWorkTypeRepository workTypeRepo = new WorkTypeRepository();
            IWorkSpecRepository workSpecRepo = new WorkSpecRepository();
            return new ProjectTreeService(projectService,workCategoryRepo, workTypeRepo, workSpecRepo, workCategoryService);
        }
    }
}
