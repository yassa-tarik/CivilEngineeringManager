namespace Composition
{
    public class ProjectBuilder
    {
        /*
        private readonly IProjectRepository projectRepo = new ProjectRepository();
        public IProjectService BuildProjectService()
        {
            return new ProjectService(projectRepo);
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
        */
    }
}
