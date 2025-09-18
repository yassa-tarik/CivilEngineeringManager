using Domain.Abstractions.Works;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject1
{
   /*
    // ---------- Interfaces (assumed to exist) ----------
    public interface IWorkCategoryRepository
    {
        Task<ICollection<WorkCategory>> GetAllAsync();
    }

    public interface IWorkTypeRepository
    {
        Task<IEnumerable<WorkType>> GetAllAsync();
    }

    public interface IWorkSpecRepository
    {
        Task<ICollection<WorkSpec>> GetAllAsync();
    }
   */
    // ---------- Mock Repository Implementation ----------

    /// <summary>
    /// This class provides a way to create a mock repository that returns predefined data.
    /// It simplifies the process of setting up test data for unit tests.
    /// </summary>
    // Mock repository helper methods
    public static class MockRepositoryHelper
    {
        public static Mock<IWorkCategoryRepository> CreateCategoryMock(IEnumerable<WorkCategory> data)
        {
            var mock = new Mock<IWorkCategoryRepository>();
            mock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(data.ToList());
            return mock;
        }

        public static Mock<IWorkTypeRepository> CreateTypeMock(IEnumerable<WorkType> data)
        {
            var mock = new Mock<IWorkTypeRepository>();
            mock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(data.ToList());
            return mock;
        }

        public static Mock<IWorkSpecRepository> CreateSpecMock(IEnumerable<WorkSpec> data)
        {
            var mock = new Mock<IWorkSpecRepository>();
            mock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(data.ToList());
            return mock;
        }
    }
}
