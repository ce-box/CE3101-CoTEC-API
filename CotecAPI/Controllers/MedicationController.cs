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
    /// <summary>
    /// This microservice allows you to create, edit, delete and assign medicines and medications.
    /// </summary>
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

        /// <summary>
        /// It allows to obtain the list of all medications in the database.
        /// </summary>
        /// <returns> Medication List</returns>
        [HttpGet]
        [Route("api/v1/medications/all")]
        public ActionResult<IEnumerable<MedicationView>> GetMedicationList()
        {
            var medications = _repository.GetMedicationList();
            return Ok(medications);
        }

        /// <summary>
        /// It allows obtaining the list of all the registered pharmaceutical companies.
        /// </summary>
        /// <returns>list of pharmaceutical companies.</returns>
        [HttpGet]
        [Route("api/v1/medications/companies")]
        public ActionResult<IEnumerable<PharmCoDTO>> GetCompaniesList()
        {
            var companies = _repository.GetPharmCoList();
            return Ok(_mapper.Map<IEnumerable<PharmCoDTO>>(companies));
        }

        /// <summary>
        /// Create a medication and add it to the database.
        /// </summary>
        /// <param name="med">Medication to be added.</param>
        /// <returns>Added medication.</returns>
        [HttpPost]
        [Route("api/v1/medications/new")]
        public ActionResult<MedicationReadDTO> CreateMedication([FromBody] Medication med)
        {
            _repository.CreateMedication(med);
            _repository.SaveChanges();

            var medication = _mapper.Map<MedicationReadDTO>(med);
            return Created("https://cotecapi.com/medications",medication);
        }

        /// <summary>
        /// Allows you to edit the information of a medicine.
        /// </summary>
        /// <param name="Id">Medication identification code. </param>
        /// <param name="patchDoc">Patch document with the edited data.</param>
        /// <returns>No Content</returns>
        [HttpPatch]
        [Route("api/v1/medications/edit")]
        public ActionResult UpdateMedication([FromQuery] int Id,JsonPatchDocument<MedicationUpdateDTO> patchDoc)
        {
            // Check if exists
            var medFromRepo = _repository.ExistMedications(Id);
            if(medFromRepo == null)
                return NotFound();
            
            var medToPatch = _mapper.Map<MedicationUpdateDTO>(medFromRepo);
            patchDoc.ApplyTo(medToPatch, ModelState);

            if (!TryValidateModel(medToPatch))
                return ValidationProblem(ModelState);
            
            _mapper.Map(medToPatch, medFromRepo);

            _repository.UpdateMedication(medFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        /// <summary>
        /// Allows you to delete a medicine.
        /// </summary>
        /// <param name="Id">Medication identification code. </param>
        /// <returns>No Content</returns>
        [HttpDelete]
        [Route("api/v1/medications/delete")]
        public ActionResult DeleteMedication([FromQuery] int Id)
        {
            var medication = _repository.ExistMedications(Id);
            if(medication == null)
                return NotFound();

            _repository.DeleteMedication(medication);
            _repository.SaveChanges();

            return NoContent();
        }

        /*--------------------------------
                ENTITY MEDICATIONS     
         *--------------------------------*/

        /// <summary>
        /// It allows to obtain all the medications of a patient.
        /// </summary>
        /// <param name="Dni">Patient identification number.</param>
        /// <returns>Medication List. </returns>
        [HttpGet]
        [Route("api/v1/medications/patient")]
        public ActionResult<IEnumerable<PatientMedicationView>> GetPatientMedication([FromQuery] string Dni)
        {
            var medications = _repository.GetPatientMedication(Dni);
            return Ok(medications);
        }    

        /// <summary>
        /// Allows you to assign a medication to a patient.
        /// </summary>
        /// <param name="p_med">new Patient Medication </param>
        /// <returns>Detail of the assigned medication.</returns>
        [HttpPost]
        [Route("api/v1/medications/patient/assign")]
        public ActionResult<PatientMedications> AssignMedication([FromBody] PatientMedications p_med) 
        {
            _repository.AssociateMedication(p_med);
            _repository.SaveChanges();

            return Created("https://cotecapi.com/medications",p_med);
        } 

        /// <summary>
        /// Allows you to assign a list of medications to a patient.
        /// </summary>
        /// <param name="p_med"> new Patient Medication List</param>
        /// <returns>Detail of the assigned medications.</returns>
        [HttpPost]
        [Route("api/v1/medications/patient/assign/list")]
        public ActionResult<IEnumerable<PatientMedications>> AssignMedications([FromBody] List<PatientMedications> p_med) 
        {
            foreach (var medication in p_med)
                {
                    _repository.DeleteAllPatientMedications(medication.PatientDni);
            }

            if(p_med.Count > 0)
            {    
                _repository.AssociateMedications(p_med);
            }
            _repository.SaveChanges();

            return Created("https://cotecapi.com/medications",p_med);
        }

        /// <summary>
        /// Allows you to remove a medication from a patient's medication list.
        /// </summary>
        /// <param name="Dni">Patient identification number.</param>
        /// <param name="MedicationId">Medication identification code. </param>
        /// <returns>No Content</returns>
        [HttpDelete]
        [Route("api/v1/medications/patient/delete")]
        public ActionResult DeletePatientMedication([FromQuery] string Dni, [FromQuery] int MedicationId) 
        {   
     
            _repository.DeletePatientMedication(Dni, MedicationId);
            _repository.SaveChanges();

            return NoContent();
        }

    }
}