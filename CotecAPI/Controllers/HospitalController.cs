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
    /// <summary>
    /// This microservice allows to create, modify and eliminate Hospitals.
    /// </summary>
    public class HospitalController : ControllerBase
    {
        private readonly HospitalRepo _repository;
        private readonly IMapper _mapper;

        public HospitalController(HospitalRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// It allows creating a new Hospital and adding it to the database.
        /// </summary>
        /// <param name="hospital">Hospital JSON object to add.</param>
        /// <returns>Hospital JSON object added.</returns>
        [HttpPost]
        [Route("api/v1/hospitals/new")]
        public ActionResult<HospitalReadDTO> CreateHospital([FromBody] Hospital hospital)
        {
            _repository.CreateHospital(hospital);
            _repository.SaveChanges();
         
            var hospitalDTO = _mapper.Map<HospitalReadDTO>(hospital);
            return Created("https://cotecapi.com/hospital",hospitalDTO);
        }

        /// <summary>
        /// It allows to obtain all the registered hospitals.
        /// </summary>
        /// <returns>Hospital List.</returns>
        [HttpGet]
        [Route("api/v1/hospitals/all")]
        public ActionResult<IEnumerable<HospitalReadDTO>> GetAllHospitals()
        {
            var hospitals = _repository.GetAllHospitals();
            return Ok(_mapper.Map<IEnumerable<HospitalReadDTO>>(hospitals));
        }

        /// <summary>
        /// It allows obtaining a list of the hospitals that a country has.
        /// </summary>
        /// <param name="Country">Country code in alpha-3 format.</param>
        /// <returns>Hospital List.</returns>
        [HttpGet]
        [Route("api/v1/hospitals/country")]
        public ActionResult<IEnumerable<HospitalReadDTO>> GetHospitalsByCountry([FromQuery] string Country)
        {
            var hospitals = _repository.GetHospitalsByCountry(Country);
            return Ok(_mapper.Map<IEnumerable<HospitalReadDTO>>(hospitals));
        }

        /// <summary>
        /// It allows to obtain the detail of a given Hospital Id.
        /// </summary>
        /// <param name="Id">Hospital identification number.</param>
        /// <returns>JSON object of the requested Hospital.</returns>
        [HttpGet]
        [Route("api/v1/hospitals")]
        public ActionResult<HospitalReadDTO> GetHospitalById([FromQuery] int Id)
        {
            var hospital = _repository.GetHospitalById(Id);
            return Ok(_mapper.Map<HospitalReadDTO>(hospital));
        }

        /// <summary>
        /// It allows to edit the data of a hospital given its Id and a Patch of the changes.
        /// </summary>
        /// <param name="Id">Hospital identification number.</param>
        /// <param name="patchDoc">Patch document with changes.</param>
        /// <returns>ActionResult  NoContent.</returns>
        [HttpPatch]
        [Route("api/v1/hospitals/edit")]
        public ActionResult EditHospital([FromQuery] int Id,[FromBody] JsonPatchDocument<HospitalUpdateDTO> patchDoc)
        {
            // Check if exists
            var hospFromRepo = _repository.GetHospitalById(Id);
            if(hospFromRepo == null)
                return NotFound();
            
            var hospToPatch = _mapper.Map<HospitalUpdateDTO>(hospFromRepo);
            patchDoc.ApplyTo(hospToPatch);
            _mapper.Map(hospToPatch, hospFromRepo);

            _repository.UpdateHospital(hospFromRepo);
            _repository.SaveChanges(); 

            return NoContent();
        }

        /// <summary>
        /// It allows to Delete a Hospital from the database.
        /// </summary>
        /// <param name="Id">Hospital identification number.</param>
        /// <returns>ActionResult  NoContent.</returns>
        [HttpDelete]
        [Route("api/v1/hospitals/delete")]
        public ActionResult DeleteHospital([FromQuery] int Id)
        {
            // Check if  exists
            var hospital = _repository.GetHospitalById(Id);
            if(hospital == null)
                return NotFound();
         
            _repository.DeleteHospital(hospital);
            _repository.SaveChanges();
            
            return NoContent();
        }
    }
}