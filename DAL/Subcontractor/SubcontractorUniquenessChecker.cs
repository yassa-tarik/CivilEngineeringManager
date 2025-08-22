using DAL.Interfaces;
using DAL.Interfaces.Subcontractor;

namespace DAL.Subcontractor
{
    public class SubcontractorUniquenessChecker : ISubcontractorUniquenessChecker
    {
        private readonly ISubcontractorRepository _repository;

        public SubcontractorUniquenessChecker(ISubcontractorRepository repository)
        {
            _repository = repository;
        }

        public bool ExistsByName(string raisonSocial)
        {
            return _repository.ExistsByName(raisonSocial);
        }
    }
}
