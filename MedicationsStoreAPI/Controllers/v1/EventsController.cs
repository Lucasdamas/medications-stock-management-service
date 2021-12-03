using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;
using MedicationsStoreAPI.Controllers.Dto;
using MedicationsStoreAPI.Database.Models;
using MedicationsStoreAPI.Database.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MedicationsStoreAPI.Controllers.v1
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
            [Required] [FromBody] MedicationDto medicationDto)
        {
            if (medicationDto.Quantity<=0)
            {
                Console.WriteLine("indefinite-number-of-medications");
                return BadRequest();
            }
            var medicationDbo = new Medication()
            {
                Name = medicationDto.Name,
                Quantity = medicationDto.Quantity,
                CreatedDate = medicationDto.CreatedDate
            };

            _medicationRepository.InsertMedication(medicationDbo);
            return Ok();
        }

        [HttpGet("medicationlist")]
        public async Task<IActionResult> GetMedicationsList()
        {
            var medicationsList = _medicationRepository.GetMedicationsList();
            return Ok(medicationsList);
        }

        [HttpDelete("deletemedication")]
        public async Task<IActionResult> DeleteMedication(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                return StatusCode((int) HttpStatusCode.NotFound);
            }
            _medicationRepository.DeleteMedication(name);
            return Ok();
        }
    }
}