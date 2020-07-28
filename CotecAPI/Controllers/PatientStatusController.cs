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
    public class PatientStatusController: ControllerBase
    {
        private readonly StatusRepo _repository;
        private readonly IMapper _mapper;

        public PatientStatusController(StatusRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("api/v1/status/all")]
        public ActionResult<IEnumerable<StatusReadDTO>> GetStatusList()
        {
            var statusList = _repository.GetAll();
            return Ok(_mapper.Map<IEnumerable<StatusReadDTO>>(statusList));
        }

        [HttpPost]
        [Route("api/v1/status/new")]
        public ActionResult<StatusReadDTO> CreateStatus([FromBody] StatusUpdateDTO stDTO)
        {
            PatientStatus p_st = _mapper.Map<PatientStatus>(stDTO);
            
            _repository.CreateStatus(p_st);
            _repository.SaveChanges();

            return Ok(_mapper.Map<StatusReadDTO>(p_st));
        }

        [HttpPatch]
        [Route("api/v1/status/edit")]
        public ActionResult UpdatePathology([FromQuery] int Id,JsonPatchDocument<StatusUpdateDTO> patchDoc)
        {
            // Check if exists
            var statusFromRepo = _repository.Exist(Id);
            if(statusFromRepo == null)
                return NotFound();
            
            var statusToPatch = _mapper.Map<StatusUpdateDTO>(statusFromRepo);
            patchDoc.ApplyTo(statusToPatch, ModelState);

            if (!TryValidateModel(statusToPatch))
                return ValidationProblem(ModelState);
            
            _mapper.Map(statusToPatch, statusFromRepo);

            _repository.Update(statusFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete]
         [Route("api/v1/status/delete")]
        public ActionResult DeleteStatus([FromQuery] int Id)
        {
            var p_st = _repository.Exist(Id);
            if(p_st == null)
                return NotFound();

            _repository.Delete(p_st);
            _repository.SaveChanges();

            return NoContent();
        }

    }
}