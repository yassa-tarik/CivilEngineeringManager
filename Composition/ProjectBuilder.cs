using Domain.Abstractions;
using Domain.Abstractions.Works;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Works;
using MyApplication;
using MyApplication.Abstractions;
using MyApplication.Abstractions.Works;
using MyApplication.Services.Trees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composition
{
    public class ProjectBuilder
    {
        public static IProjectService BuildProjectService()
        {
            IProjectRepository projectRepo = new ProjectRepository();
            IAddressRepository addressRepo = new AddressRepository();
      
            return new ProjectService(projectRepo, addressRepo);
        }
        public static IWorkCategoryTreeService WorkCategoryTreeService()
        {
            IWorkCategoryRepository workCategoryRepo = new WorkCategoryRepository();
            IWorkTypeRepository workTypeRepo = new WorkTypeRepository();
            IWorkSpecRepository workSpecRepo = new WorkSpecRepository();
            return new WorkCategoryTreeService(workCategoryRepo, workTypeRepo, workSpecRepo);
        }
    }
}
