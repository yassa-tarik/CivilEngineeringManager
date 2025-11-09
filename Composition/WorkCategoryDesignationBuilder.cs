using Infrastructure.Persistence.Works;
using MyApplication.Abstractions.Works;
using MyApplication.Services.Works;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
