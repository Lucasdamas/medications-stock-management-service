using System;
using MedicationsStoreAPI.Controllers.Dto;

namespace MedicationsStoreAPI.Unit.Tests.Mocks
{
    public class EventMock
    {
        public static MedicationDto ValidMedicationDto()
        {
            return new MedicationDto
            {
                Name = "bruffen",
                Quantity = 1,
                CreatedDate = DateTime.Parse("2020-08-31T00:01:24.990Z")
            };
        }
        
        public static MedicationDto NotValidMedicationDto()
        {
            return new MedicationDto
            {
                Name = "bruffen",
                Quantity = 0,
                CreatedDate = DateTime.Parse("2020-08-31T00:01:24.990Z")
            };
        }
    }
}