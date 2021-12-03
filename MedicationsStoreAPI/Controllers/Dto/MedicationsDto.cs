using System;
using System.Diagnostics.CodeAnalysis;

namespace MedicationsStoreAPI.Controllers.Dto
{
    [ExcludeFromCodeCoverage]
    public class MedicationDto
    {
        public string Name { get; set; }

        public int Quantity { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}