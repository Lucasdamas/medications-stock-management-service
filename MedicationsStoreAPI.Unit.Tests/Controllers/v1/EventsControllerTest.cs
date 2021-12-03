using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using MedicationsStoreAPI.Controllers.v1;
using MedicationsStoreAPI.Database.Repositories.Interface;
using MedicationsStoreAPI.Unit.Tests.Mocks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MedicationsStoreAPI.Unit.Tests.Controllers.v1
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class EventsControllerTest
    {
        private EventsController _eventsController;

        private Mock<IMedicationRepository> _mockMedicationRepository;


        [TestInitialize]
        public void TestInitialize()
        {
            var httpContext = new DefaultHttpContext();
            _mockMedicationRepository = new Mock<IMedicationRepository>();
            _eventsController = new EventsController(_mockMedicationRepository.Object)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext
                }
            };
        }

        [TestMethod]
        public async Task Create_WithValidEventDto_ReturnsOk()
        {
            var medicationDtoTest = EventMock.ValidMedicationDto();

            var response = await _eventsController.Create(medicationDtoTest);
            var result = response as OkResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }
        
        [TestMethod]
        public async Task Create_WithNotValidEventDto_ReturnsOk()
        {
            var medicationDtoTest = EventMock.NotValidMedicationDto();

            var response = await _eventsController.Create(medicationDtoTest);
            var result = response as BadRequestResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.StatusCode);
        }
    }
}