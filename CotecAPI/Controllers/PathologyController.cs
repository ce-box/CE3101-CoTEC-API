using System.Collections.Generic;
using CotecAPI.DataAccess.Repositories;
using CotecAPI.Models.Views;
using CotecAPI.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using CotecAPI.Models.DTO;
using System;
using Microsoft.AspNetCore.JsonPatch;

namespace CotecAPI.Controllers
{
    /// <summary>
    /// This microservice allows creating, modifying and eliminating 
    /// pathologies to the database. Also, it allows assigning, modifying 
    /// or eliminating the pathologies of a patient or contact.
    /// </summary>
    [ApiController]
    public class PathologyController : ControllerBase
    {
        private readonly PathologyRepo _repository;
        private readonly IMapper _mapper;

        public PathologyController(PathologyRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /*--------------------------------
                     PATHOLOGIES     
         *--------------------------------*/

        /// <summary>
        /// It allows obtaining all pathologies.
        /// </summary>
        /// <returns>List of pathologies.</returns>
        [HttpGet]
        [Route("api/v1/pathologies/all")]
        public ActionResult<IEnumerable<PathologyReadDTO>> GetAll()
        {
            var pathologies = _repository.GetAllPathologies();
            return Ok(_mapper.Map<IEnumerable<PathologyReadDTO>>(pathologies));
        }

        /// <summary>
        /// It allows to create and add a new pathology.
        /// </summary>
        /// <param name="newPathology"> New Patology. </param>
        /// <returns>Added pathology.</returns>
        [HttpPost]
        [Route("api/v1/pathologies/new")]
        public ActionResult<IEnumerable<PathologyReadDTO>> CreatePathology([FromBody] Pathology newPathology)
        {
            var patFromRepo = _repository.ExistPathology(newPathology.Name);
            if(patFromRepo != null)
                return new BadRequestObjectResult(new { message = "Existing Pathology", currentDate = DateTime.Now });

            _repository.CreatePathology(newPathology);
            _repository.SaveChanges();

            var pathology = _mapper.Map<PathologyReadDTO>(newPathology);
            return Created("https://cotecapi.com/pathologies",pathology);
        }

        /// <summary>
        /// It allows to modify information of a pathology.
        /// </summary>
        /// <param name="Name"> Pathology Name. </param>
        /// <param name="patchDoc">JSON with the changes to be applied. </param>
        /// <returns> No Content </returns>
        [HttpPatch]
        [Route("api/v1/pathologies/edit")]
        public ActionResult UpdatePathology([FromQuery] string Name,[FromBody] JsonPatchDocument<PathologyUpdateDTO> patchDoc)
        {
            // Check if exists
            var patFromRepo = _repository.ExistPathology(Name);
            if(patFromRepo == null)
                return NotFound();
            
            var patToPatch = _mapper.Map<PathologyUpdateDTO>(patFromRepo);
            patchDoc.ApplyTo(patToPatch, ModelState);

            if (!TryValidateModel(patToPatch))
                return ValidationProblem(ModelState);
            
            _mapper.Map(patToPatch, patFromRepo);

            _repository.UpdatePathology(patFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        /// <summary>
        /// It allows to eliminate a pathology.
        /// </summary>
        /// <param name="Name"> Pathology Name. </param>
        /// <returns> No Content.async </returns>
        [HttpDelete]
        [Route("api/v1/pathologies/delete")]
        public ActionResult DeleteContactPathology([FromQuery] string Name)
        {   
            var patFromRepo = _repository.ExistPathology(Name);
            if(patFromRepo == null)
                return NotFound();

            _repository.DeletePathology(patFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        /*--------------------------------
                ENTITY PATHOLOGIES     
         *--------------------------------*/
        /// <summary>
        /// It allows assigning a pathology list to a patient.
        /// </summary>
        /// <param name="pathologies">pathologies to assign.</param>
        /// <returns>List of assigned pathologies.</returns>
        [HttpPost]
        [Route("api/v1/pathologies/patient/assign")]
        public ActionResult<IEnumerable<PatientPathologies>> AssignPatientPathology([FromBody] List<PatientPathologies> pathologies)
        {
            foreach (var pathology in pathologies)
            {
                _repository.DeleteAllPatientPathologies(pathology.PatientDni);
            }
            
            if(pathologies.Count > 0){
                _repository.AssignPatientPathologies(pathologies);
            }
            _repository.SaveChanges();

            return Created("https://cotecapi.com/pathologies",pathologies);
        }

        /// <summary>
        /// It allows assigning a pathology list to a contact.
        /// </summary>
        /// <param name="pathologies">pathologies to assign.</param>
        /// <returns>List of assigned pathologies.</returns>
        [HttpPost]
        [Route("api/v1/pathologies/contact/assign")]
        public ActionResult<IEnumerable<PatientPathologies>> AssignContactPathology([FromBody] List<PersonPathologies> pathologies)
        {
            foreach (var pathology in pathologies)
            {
                _repository.DeleteAllContactPathologies(pathology.PersonDni);
            }

            if(pathologies.Count > 0){
                _repository.AssignContactPathologies(pathologies);
            }
            _repository.SaveChanges();
            return Created("https://cotecapi.com/pathologies",pathologies);
        }

        /// <summary>
        /// Obtains the list of the pathologies of a patient.
        /// </summary>
        /// <param name="Dni"> Patient Dni.</param>
        /// <returns>List of pathologies.</returns>
        [HttpGet]
        [Route("api/v1/pathologies/patient")]
        public ActionResult<IEnumerable<PatientPathologyView>> GetPatientPathology([FromQuery] string Dni)
        {
            var pathologies = _repository.getPatientPathologies(Dni);
            return Ok(pathologies);
        }

        /// <summary>
        /// Obtains the list of the pathologies of a contact.
        /// </summary>
        /// <param name="Dni"> Contacted Person Dni.</param>
        /// <returns>List of pathologies.</returns>
        [HttpGet]
        [Route("api/v1/pathologies/contact")]
        public ActionResult<IEnumerable<PatientPathologyView>> GetContactPathology([FromQuery] string Dni)
        {
            var pathologies = _repository.getContactPathologies(Dni);
            return Ok(pathologies);
        }

        /// <summary>
        /// It allows to eliminate a pathology from the list of pathologies of a patient.
        /// </summary>
        /// <param name="Dni"> Patient Dni.</param>
        /// <param name="Pathology"> Pathology Name.</param>
        /// <returns>No Content</returns>
        [HttpDelete]
        [Route("api/v1/pathologies/patient/delete")]
        public ActionResult DeletePatientPathology([FromQuery] string Dni, string Pathology)
        {
            _repository.DeletePatientPathology(Dni,Pathology);
            _repository.SaveChanges();

            return NoContent();
        }
        
        /// <summary>
        /// It allows to eliminate a pathology from the list of pathologies of a contact.
        /// </summary>
        /// <param name="Dni"> Contacted Person Dni.</param>
        /// <param name="Pathology"> Pathology Name.</param>
        /// <returns>No Content</returns>
        [HttpDelete]
        [Route("api/v1/pathologies/contact/delete")]
        public ActionResult DeleteContactPathology([FromQuery] string Dni, string Pathology)
        {
            _repository.DeleteContactPathology(Dni,Pathology);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}