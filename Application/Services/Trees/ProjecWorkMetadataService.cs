using MyApplication.Abstractions;
using MyApplication.Abstractions.Trees;
using MyApplication.Abstractions.Works;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Services.Trees
{
    public class ProjecWorkMetadataService : IProjectWorkDataService
    {
        public IProjectService Projects { get; }
        public IWorkCategoryService Categories { get; }
        public IWorkTypeService Types { get; }
        public IWorkSpecService Specs { get; }

        public ProjecWorkMetadataService(IProjectService projects, IWorkCategoryService categories, IWorkTypeService types, IWorkSpecService specs)
        {
            this.Projects = projects;
            this.Categories = categories;
            this.Types = types;
            this.Specs = specs;
        }
    }
}
