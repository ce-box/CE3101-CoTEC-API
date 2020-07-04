using System.Collections.Generic;
using CotecAPI.DataAccess.Repositories;
using CotecAPI.Models.Views;
using CotecAPI.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using CotecAPI.Models.DTO;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;

namespace CotecAPI.Controllers
{
    [ApiController]
    public class MedicationController : ControllerBase
    {
        private readonly MedicationRepo _repository;
        private readonly IMapper _mapper;

        public MedicationController(MedicationRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        /*--------------------------------
                    MEDICATIONS     
         *--------------------------------*/

        [HttpGet]
        [Route("api/v1/medications/all")]
        public ActionResult<IEnumerable<MedicationView>> GetMedicationList()
        {
            var medications = _repository.GetMedicationList();
            return Ok(medications);
        }

        [HttpGet]
        [Route("api/v1/medications/companies")]
        public ActionResult<IEnumerable<PharmCoDTO>> GetCompaniesList()
        {
            var companies = _repository.GetPharmCoList();
            return Ok(_mapper.Map<IEnumerable<PharmCoDTO>>(companies));
        }

        [HttpPost]
        [Route("api/v1/medications/new")]
        public ActionResult<MedicationDTO> CreateMedication([FromBody] Medication med)
        {
            _repository.CreateMedication(med);
            _repository.SaveChanges();

            var medication = _mapper.Map<MedicationDTO>(med);
            return Created("https://cotecapi.com/medications",medication);
        }

        [HttpPatch]
        [Route("api/v1/medications/edit")]
        public ActionResult UpdateMedication([FromQuery] int Id,JsonPatchDocument<MedicationUpdateDTO> patchDoc)
        {
            // Check if exists
            var medFromRepo = _repository.Exist(Id);
            if(medFromRepo == null)
                return NotFound();
            
            var medToPatch = _mapper.Map<MedicationUpdateDTO>(medFromRepo);
            patchDoc.ApplyTo(medToPatch, ModelState);

            if (!TryValidateModel(medToPatch))
                return ValidationProblem(ModelState);
            
            _mapper.Map(medToPatch, medFromRepo);

            _repository.UpdateMedications(medFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete]
        [Route("api/v1/medications/delete")]
        public ActionResult DeleteMedication([FromQuery] int Id)
        {
            var medication = _repository.Exist(Id);
            if(medication == null)
                return NotFound();

            _repository.DeleteMedication(medication);
            _repository.SaveChanges();

            return NoContent();
        }

        /*--------------------------------
                ENTITY MEDICATIONS     
         *--------------------------------*/

        [HttpGet]
        [Route("api/v1/medications/patient")]
        public ActionResult<IEnumerable<PatientMedicationView>> GetPatientMedication([FromQuery] string Dni)
        {
            var medications = _repository.GetPatientMedication(Dni);
            return Ok(medications);
        }    

        [HttpPost]
        [Route("api/v1/medications/patient/assign")]
        public ActionResult<PatientMedications> AssignMedication([FromBody] PatientMedications p_med) 
        {
            _repository.AssociateMedication(p_med);
            _repository.SaveChanges();

            return Created("https://cotecapi.com/medications",p_med);
        } 

        [HttpPost]
        [Route("api/v1/medications/patient/assign/list")]
        public ActionResult<IEnumerable<PatientMedications>> AssignMedication([FromBody] IEnumerable<PatientMedications> p_med) 
        {
            _repository.AssociateMedications(p_med);
            _repository.SaveChanges();

            return Created("https://cotecapi.com/medications",p_med);
        }

        [HttpDelete]
        [Route("api/v1/medications/patient/delete")]
        public ActionResult AssignMedication([FromQuery] string Dni, [FromQuery] int MedicationId) 
        {   
     
            _repository.DeletePatientMedication(Dni, MedicationId);
            _repository.SaveChanges();

            return NoContent();
        }

    }
}