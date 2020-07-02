using System.Collections.Generic;
using CotecAPI.DataAccess.Repositories;
using CotecAPI.Models.Views;
using CotecAPI.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using CotecAPI.Models.DTO;
using AutoMapper;
using System;
using Microsoft.AspNetCore.JsonPatch;

namespace CotecAPI.Controllers
{
    public class HospitalController : ControllerBase
    {
        private readonly HospitalRepo _repository;
        private readonly IMapper _mapper;

        public HospitalController(HospitalRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("api/v1/hospitals/new")]
        public ActionResult<HospitalReadDTO> CreateHospital([FromBody] Hospital hospital)
        {
            _repository.CreateHospital(hospital);
            _repository.SaveChanges();
         
            var hospitalDTO = _mapper.Map<HospitalReadDTO>(hospital);
            return Created("https://cotecapi.com/hospital",hospitalDTO);
        }

        [HttpGet]
        [Route("api/v1/hospitals/all")]
        public ActionResult<IEnumerable<HospitalReadDTO>> GetAll()
        {
            var hospitals = _repository.GetAll();
            return Ok(_mapper.Map<IEnumerable<HospitalReadDTO>>(hospitals));
        }

        [HttpGet]
        [Route("api/v1/hospitals/country")]
        public ActionResult<IEnumerable<HospitalReadDTO>> GetByCountry([FromQuery] string Country)
        {
            var hospitals = _repository.GetByCountry(Country);
            return Ok(_mapper.Map<IEnumerable<HospitalReadDTO>>(hospitals));
        }

        [HttpGet]
        [Route("api/v1/hospitals")]
        public ActionResult<HospitalReadDTO> GetById([FromQuery] int Id)
        {
            var hospital = _repository.getById(Id);
            return Ok(_mapper.Map<HospitalReadDTO>(hospital));
        }

        // TODO: Revisar ¿porqué no se aplica el patch?
        [HttpPatch]
        [Route("api/v1/hospitals/edit")]
        public ActionResult<Hospital> EditHospital([FromQuery] int Id, JsonPatchDocument<HospitalUpdateDTO> patchDoc)
        {
            // Check if exists
            var hospFromRepo = _repository.getById(Id);
            if(hospFromRepo == null)
                return NotFound();
            
            var hospToPatch = _mapper.Map<HospitalUpdateDTO>(hospFromRepo);
            patchDoc.ApplyTo(hospToPatch, ModelState);

            if (!TryValidateModel(hospToPatch))
                return ValidationProblem(ModelState);
            
            _mapper.Map(hospToPatch, hospFromRepo);

            _repository.UpdateHospital(hospFromRepo);
            _repository.SaveChanges();

            return Ok(hospFromRepo);
        }

        [HttpDelete]
        [Route("api/v1/hospitals/delete")]
        public ActionResult DeleteHospital([FromQuery] int Id)
        {
            var hospital = _repository.getById(Id);
            if(hospital == null)
                return NotFound();
         
            _repository.DeleteHospital(hospital);
            _repository.SaveChanges();
            
            return NoContent();
        }


    }
}