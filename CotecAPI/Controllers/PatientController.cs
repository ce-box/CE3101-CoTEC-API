using System.Collections.Generic;
using CotecAPI.DataAccess.Repositories;
using CotecAPI.Models.Views;
using CotecAPI.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using AutoMapper;
using CotecAPI.Models.DTO;
using Microsoft.AspNetCore.JsonPatch;
using CotecAPI.Models.DTO.Patient;

namespace CotecAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly PatientRepo _repository;
        private readonly IMapper _mapper;

        public PatientController(PatientRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        [HttpPost]
        [Route("api/v1/patients/new")]
        public ActionResult<PatientReadDTO> CreatePatient([FromBody] Patient pat)
        {

            //Check if patient exists
            var patientFromRepo = _repository.GetPatientByDniRaw(pat.Dni);
            if (patientFromRepo != null)
                return new BadRequestObjectResult(new { message = "Existing Entity", currentDate = DateTime.Now });

            _repository.CreatePatient(pat);
            _repository.SaveChanges();

            var patient = _mapper.Map<PatientReadDTO>(pat);
            return Created("https://cotecapi.com/patients", patient);
        }



        [HttpPost]
        [Route("api/v1/patients/new/list")]
        public ActionResult<IEnumerable<PatientReadDTO>> CreatePatients([FromBody] IEnumerable<Patient> pat)
        {

            _repository.CreatePatients(pat);
            _repository.SaveChanges();

            var patients = _mapper.Map<IEnumerable<PatientReadDTO>>(pat);

            return Created("https://cotecapi.com/patients", patients);
        }

        [HttpGet]
        [Route("api/v1/patients")]
        public ActionResult<PatientView> GetPatientByDni([FromQuery] string Dni)
        {
            var patientItem = _repository.GetPatientByDni(Dni);
            if (patientItem != null)
                return Ok(patientItem);

            return NotFound();
        }

        [HttpGet]
        [Route("api/v1/patients/raw")]
        public ActionResult<Patient> GetPatientByDniRaw([FromQuery] string Dni)
        {
            var patientItem = _repository.GetPatientByDniRaw(Dni);
            if (patientItem != null)
                return Ok(patientItem);

            return NotFound();
        }

        [HttpGet]
        [Route("api/v1/patients/hospital")] // Patients in hospital
        public ActionResult<IEnumerable<PatientView>> GetAllPatients([FromQuery] int hospital_Id)
        {
            var patientItem = _repository.GetAll(hospital_Id);
            if (patientItem != null)
                return Ok(patientItem);

            return NotFound();
        }

        [HttpPatch]
        [Route("api/v1/patients/edit")]
        public ActionResult UpdatePatient([FromQuery] string Dni, JsonPatchDocument<PatientUpdateDTO> patchDoc)
        {
            //Check if patient exists
            var patientFromRepo = _repository.GetPatientByDniRaw(Dni);
            if (patientFromRepo == null)
                return NotFound();

            var patToPatch = _mapper.Map<PatientUpdateDTO>(patientFromRepo);
            patchDoc.ApplyTo(patToPatch, ModelState);

            _mapper.Map(patToPatch, patientFromRepo);

            _repository.UpdatePatient(patientFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete]
        [Route("api/v1/patients/delete")]
        public ActionResult DeletePatient([FromQuery] string Dni)
        {
            //Check if patient exists
            var patientFromRepo = _repository.GetPatientByDniRaw(Dni);
            if (patientFromRepo == null)
                return NotFound();

            _repository.DeletePatient(Dni);
            return NoContent();
        }


        [HttpPost]
        [Route("api/v1/patients/excel")]
        public ActionResult<IEnumerable<Patient>> AddFromExcel([FromBody] IEnumerable<ExcelPatient> patientsList)
        {
            var countryList = _repository.GetCountries();
            var correctPatients = new List<Patient>();

            foreach (var patient in patientsList)
            {
                //1. Check Country

                var country = countryList.Find(c => c.Name == patient.Nacionalidad);
                if (country != null)
                {// Does not accepted

                    //1.2. Country Code and region
                    var patientCountry = country.Code;
                    var regionList = _repository.GetRegions(patientCountry);

                    if (regionList.Count != 0)
{
                        var patientRegion = regionList[0].Name; // Gets the first Region --> No complications
                        DateTime patientDoB;
                        try
                        {
                            //2. Cast Date
                            patientDoB = DateTime.Parse(patient.FechaNacimiento);
                        } catch(System.FormatException)
                        {
                            patientDoB = DateTime.Today;
                        }
                            //3. Name se va como Tal
                            var patientName = patient.Nombre;
                            //4. Identificacion juega
                            var patientDni = patient.Identificación;

                            var new_patient = new Patient()
                            {
                                Dni = patientDni,
                                Name = patientName,
                                LastName = "",
                                DoB = patientDoB,
                                Status = 2, // INFECTED
                                Hospital_Id = 8, //  Default Hospital
                                Region = patientRegion,
                                Country = patientCountry
                            };

                            _repository.CreatePatient(new_patient);
                            _repository.SaveChanges(); 
                            correctPatients.Add(new_patient);
                        
                    }
                }
            }

            return Ok(correctPatients);
        }


    }
}