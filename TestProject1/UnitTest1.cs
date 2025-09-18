using Domain.Abstractions.Works;
using Moq;
using MyApplication.Services.Trees;

namespace TestProject1
{
    // The DTOs and Service classes must be available in the test project.
    // Make sure to reference the files containing WorkCategoryTreeDTO, WorkTypeTreeDTO, and WorkSpecDTO.

    [TestFixture]
    public class WorkCategoryTreeServiceTests
    {
        private WorkCategoryTreeService _service;
        private Mock<IWorkCategoryRepository> _categoryRepoMock;
        private Mock<IWorkTypeRepository> _typeRepoMock;
        private Mock<IWorkSpecRepository> _specRepoMock;

        /// <summary>
        /// Sets up the test environment before each test.
        /// This is where we create the mocks and the service instance.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _categoryRepoMock = new Mock<IWorkCategoryRepository>();
            _typeRepoMock = new Mock<IWorkTypeRepository>();
            _specRepoMock = new Mock<IWorkSpecRepository>();
            _service = new WorkCategoryTreeService(_categoryRepoMock.Object, _typeRepoMock.Object, _specRepoMock.Object);
        }

        /// <summary>
        /// Test case: Verifies that the service correctly builds a full, complex hierarchy.
        /// This is the primary test for a happy path scenario.
        /// </summary>
        [Test]
        public async Task GetWorkCategoryTreeAsync_WithFullData_BuildsCorrectHierarchy()
        {
            // Arrange
            var categories = new List<WorkCategory>
        {
            new WorkCategory { ID = 1, WorkCategoryName = "General" }
        };
            var workTypes = new List<WorkType>
        {
            new WorkType { ID = 101, WorkCategory_ID = 1, Parent_ID = null, Designation = "Construction" },
            new WorkType { ID = 102, WorkCategory_ID = 1, Parent_ID = 101, Designation = "Excavation" }
        };
            var workSpecs = new List<WorkSpec>
        {
            new WorkSpec { ID = 1001, WorkType_ID = 101, Designation = "Labor", Unit = "man-hour", UnitPrice = 50.0m, Quantity = 8.0, VAT = "10%" },
            new WorkSpec { ID = 1002, WorkType_ID = 102, Designation = "Concrete", Unit = "m3", UnitPrice = 120.0m, Quantity = 5.0, VAT = "20%" }
        };

            _categoryRepoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(categories);
            _typeRepoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(workTypes);
            _specRepoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(workSpecs);

            // Act
            var result = await _service.GetWorkCategoryTreeAsync();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(1));

            var category = result.First();
            Assert.That(category.ID, Is.EqualTo(1));
            Assert.That(category.WorkTypes.Count, Is.EqualTo(1));

            var parentWorkType = category.WorkTypes.First();
            Assert.That(parentWorkType.ID, Is.EqualTo(101));
            Assert.That(parentWorkType.WorkSpecs.Count, Is.EqualTo(1));
            Assert.That(parentWorkType.ChildWorkTypes.Count, Is.EqualTo(1));

            var childWorkType = parentWorkType.ChildWorkTypes.First();
            Assert.That(childWorkType.ID, Is.EqualTo(102));
            Assert.That(childWorkType.WorkSpecs.Count, Is.EqualTo(1));
        }

        /// <summary>
        /// Test case: Verifies that the service handles an empty dataset gracefully.
        /// No exceptions should be thrown, and an empty list should be returned.
        /// </summary>
        [Test]
        public async Task GetWorkCategoryTreeAsync_WithEmptyData_ReturnsEmptyCollection()
        {
            // Arrange
            _categoryRepoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<WorkCategory>());
            _typeRepoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<WorkType>());
            _specRepoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<WorkSpec>());

            // Act
            var result = await _service.GetWorkCategoryTreeAsync();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.Empty);
        }

        /// <summary>
        /// Test case: Verifies that the service correctly builds the tree when there are
        /// no WorkSpec items.
        /// </summary>
        [Test]
        public async Task GetWorkCategoryTreeAsync_WithNoWorkSpecs_StillBuildsTree()
        {
            // Arrange
            var categories = new List<WorkCategory> { new WorkCategory { ID = 1, WorkCategoryName = "General" } };
            var workTypes = new List<WorkType> { new WorkType { ID = 101, WorkCategory_ID = 1, Parent_ID = null, Designation = "Construction" } };
            var workSpecs = new List<WorkSpec>(); // Empty list

            _categoryRepoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(categories);
            _typeRepoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(workTypes);
            _specRepoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(workSpecs);

            // Act
            var result = await _service.GetWorkCategoryTreeAsync();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.First().WorkTypes.First().WorkSpecs, Is.Empty);
        }
    }
}