using System.Collections.Generic;
using CotecAPI.DataAccess.Repositories;
using CotecAPI.Models.Views;
using CotecAPI.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CotecAPI.Controllers
{
    
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly PatientRepo _repository;

        public PatientController(PatientRepo repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("api/v1/patients")]
        public ActionResult<PatientView> GetPatientByDni([FromQuery] string Dni) {
            var patientItem = _repository.GetByDni(Dni);
            if (patientItem != null)
                return Ok(patientItem);

            return NotFound();
        }
        
        [HttpGet]
        [Route("api/v1/patients/hospital")] // Patients in hospital
        public ActionResult<IEnumerable<PatientView>> GetAllPatients([FromQuery] int hospital_Id) {
            var patientItem = _repository.GetAll(hospital_Id);
            if (patientItem != null)
                return Ok(patientItem);

            return NotFound();
        }

        [HttpGet]
        [Route("api/v1/patients/world")] // world wide
        public ActionResult<IEnumerable<PatientView>> GetAllPatients() {
            var patientItem = _repository.GetAll();
            if (patientItem != null)
                return Ok(patientItem);

            return NotFound();
        }

        [HttpPost]
        [Route("api/v1/patients/new")]
        public ActionResult<Patient> CreatePatient([FromBody] Patient pat) {
            _repository.Create(pat);
            _repository.SaveChanges();

            return Created("https://cotecapi.com/patients",pat);
        }
    }
}