using System;

namespace MedicinesStoreAPI.Controllers.Dto
{
    public class MedicationDto
    {
        public string Name { get; set; }

        public int Quantity { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}