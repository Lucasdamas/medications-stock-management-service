using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using MedicinesStoreAPI.Controllers.Dto;
using MedicinesStoreAPI.Database.Models;
using MedicinesStoreAPI.Database.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MedicinesStoreAPI.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[Controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IMedicationRepository _medicationRepository;

        public EventsController(IMedicationRepository medicationRepository)
        {
            _medicationRepository = medicationRepository;
        }

        [HttpPost("createmedication")]
        public async Task<IActionResult> Create(
            [Required] [FromBody] MedicationDto medicationUserDto)
        {
            if (medicationUserDto.Quantity<=0)
            {
                Console.WriteLine("indefinite-number-of-medications");
                return BadRequest();
            }
            var medicationDbo = new Medication()
            {
                Name = medicationUserDto.Name,
                Quantity = medicationUserDto.Quantity,
                CreatedDate = medicationUserDto.CreatedDate
            };

            _medicationRepository.InsertMedication(medicationDbo);
            return Ok();
        }

        [HttpGet("medicationlist")]
        public async Task<IActionResult> GetMedicineList()
        {
            var medicationsList = _medicationRepository.GetMedicationsList();
            return Ok(medicationsList);
        }

        [HttpDelete("deletemedication")]
        public async Task<IActionResult> DeleteMedicine(string name)
        {
            _medicationRepository.DeleteMedication(name);
            return Ok();
        }
    }
}