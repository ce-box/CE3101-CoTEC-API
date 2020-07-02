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

        [HttpGet]
        [Route("api/v1/pathologies/all")]
        public ActionResult<IEnumerable<PathologyReadDTO>> GetAll()
        {
            var pathologies = _repository.GetAll();
            return Ok(_mapper.Map<IEnumerable<PathologyReadDTO>>(pathologies));
        }

        [HttpPost]
        [Route("api/v1/pathologies/new")]
        public ActionResult<IEnumerable<PathologyReadDTO>> CreatePathology([FromBody] Pathology ptg)
        {
            var patFromRepo = _repository.ExistPathology(ptg.Name);
            if(patFromRepo != null)
                return new BadRequestObjectResult(new { message = "Existing Pathology", currentDate = DateTime.Now });

            _repository.CreatePathology(ptg);
            _repository.SaveChanges();

            var pathology = _mapper.Map<PathologyReadDTO>(ptg);
            return Created("https://cotecapi.com/pathologies",pathology);
        }

        [HttpPatch]
        [Route("api/v1/pathologies/edit")]
        public ActionResult UpdatePathology([FromQuery] string Name,JsonPatchDocument<PathologyUpdateDTO> patchDoc)
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

        [HttpPost]
        [Route("api/v1/pathologies/patient/assign")]
        public ActionResult<IEnumerable<PatientPathologies>> AssignPatientPathology([FromBody] IEnumerable<PatientPathologies> ptg)
        {
            _repository.AssignPatientPathologies(ptg);
            _repository.SaveChanges();

            return Created("https://cotecapi.com/pathologies",ptg);
        }

        [HttpPost]
        [Route("api/v1/pathologies/contact/assign")]
        public ActionResult<IEnumerable<PatientPathologies>> AssignContactPathology([FromBody] IEnumerable<PersonPathologies> ptg)
        {
            _repository.AssignContactPathologies(ptg);
            _repository.SaveChanges();
            return Created("https://cotecapi.com/pathologies",ptg);
        }

        [HttpGet]
        [Route("api/v1/pathologies/patient")]
        public ActionResult<IEnumerable<PatientPathologyView>> GetPatientPathology([FromQuery] string Dni)
        {
            var pathologies = _repository.getPatientPathology(Dni);
            return Ok(pathologies);
        }

        [HttpGet]
        [Route("api/v1/pathologies/contact")]
        public ActionResult<IEnumerable<PatientPathologyView>> GetContactPathology([FromQuery] string Dni)
        {
            var pathologies = _repository.getContactPathology(Dni);
            return Ok(pathologies);
        }

        [HttpDelete]
        [Route("api/v1/pathologies/patient/delete")]
        public ActionResult DeletePatientPathology([FromQuery] string Dni, string Pathology)
        {
            _repository.DeletePatientPathology(Dni,Pathology);
            _repository.SaveChanges();

            return NoContent();
        }

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