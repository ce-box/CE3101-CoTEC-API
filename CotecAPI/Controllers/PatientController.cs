using System.Collections.Generic;
using CotecAPI.DataAccess.Repositories;
using CotecAPI.Models.Views;
using CotecAPI.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System;

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

        

        [HttpPost]
        [Route("api/v1/patients/new")]
        public ActionResult<Patient> CreatePatient([FromBody] Patient pat) {

            //Check if patient exists
            var patientFromRepo = _repository.GetByDni(pat.Dni);
            if (patientFromRepo != null)
                return new BadRequestObjectResult(new { message = "Existing Entity", currentDate = DateTime.Now });

            _repository.Create(pat);
            _repository.SaveChanges();

            return Created("https://cotecapi.com/patients",pat);
        }

        

        [HttpPost]
        [Route("api/v1/patients/new/list")]
        public ActionResult<IEnumerable<Patient>> CreatePatients([FromBody] IEnumerable<Patient> pat) {
            _repository.CreatePatients(pat);
            _repository.SaveChanges();

            return Created("https://cotecapi.com/patients",pat);
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

        [HttpPut]
        [Route("api/v1/patients/edit")]
        public ActionResult UpdatePatient([FromQuery]string Dni, [FromBody] Patient pat)
        {
            //Check if patient exists
            var patientFromRepo = _repository.GetByDni(Dni);
            if (patientFromRepo == null)
                return NotFound();
            
            _repository.Update(pat);
            _repository.SaveChanges();
            
            return NoContent();
        }

        [HttpDelete]
        [Route("api/v1/patients/delete")]
        public ActionResult DeletePatient([FromQuery] string Dni)
        {
            //Check if patient exists
            var patientFromRepo = _repository.GetByDni(Dni);
            if (patientFromRepo == null)
                return NotFound();
            
            _repository.Delete(Dni);
            return NoContent();
        }


    }
}