using Infrastructure.Persistence.Works;
using MyApplication.Abstractions.Works;
using MyApplication.Services.Works;

namespace Composition
{
    public class WorkCategoryDesignationBuilder
    {
        WorkCategoryDesignationRepository _workCategoryDesignationRepo;
        WorkCategoryDesignationService _workCategoryDesignationService;
        public IWorkCategoryDesignationService BuildService()
        {
            _workCategoryDesignationRepo = new WorkCategoryDesignationRepository();
            return new WorkCategoryDesignationService(_workCategoryDesignationRepo);
        }
    }
}
