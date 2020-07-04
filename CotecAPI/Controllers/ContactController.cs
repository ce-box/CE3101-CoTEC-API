using System.Collections.Generic;
using CotecAPI.DataAccess.Repositories;
using CotecAPI.Models.Views;
using CotecAPI.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using CotecAPI.Models.DTO;

namespace CotecAPI.Controllers
{
    
    //[ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ContactRepo _repository;
        private readonly IMapper _mapper;

        public ContactController(ContactRepo repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("api/v1/contacts/new")]
        public ActionResult<ContactedPerson> CreatePatient([FromQuery] string Dni, [FromBody] IEnumerable<ContactedPerson> contacts) 
        {
            foreach (var contact in contacts)
            {
                var contactFromRepo = _repository.Exist(contact.Dni);
                if(contactFromRepo == null) 
                    _repository.CreateContact(contact);
                _repository.CreateContactRelationship(Dni,contact.Dni);    
            }
            _repository.SaveChanges();

            return Created("https://cotecapi.com/contacts",contacts);
        }

        [HttpGet]
        [Route("api/v1/contacts/patient")]
        public ActionResult<IEnumerable<ContactView>> GetContacts([FromQuery] string Dni) {
            
            var contacts = _repository.GetPatientContact(Dni);
            return Ok(contacts);
        }

        [HttpGet]
        [Route("api/v1/contacts")]
        public ActionResult<ContactView> GetContactByDni([FromQuery] string Dni) {
            
            var contacts = _repository.GetByDni(Dni);
            return Ok(contacts);
        }

        [HttpPatch]
        [Route("api/v1/contacts/edit")]
        public ActionResult EditContact([FromQuery] string Dni ,JsonPatchDocument<ContactUpdateDTO> patchDoc)
        {
            // Check if exists
            var contactFromRepo = _repository.Exist(Dni);
            if(contactFromRepo == null)
                return NotFound();
            
            var contactToPatch = _mapper.Map<ContactUpdateDTO>(contactFromRepo);
            patchDoc.ApplyTo(contactToPatch, ModelState);

            if (!TryValidateModel(contactToPatch))
                return ValidationProblem(ModelState);
            
            _mapper.Map(contactToPatch, contactFromRepo);

            _repository.Update(contactFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
        
        [HttpDelete]
        [Route("api/v1/contacts/delete")]
        public ActionResult DeleteContact([FromQuery] string Dni)
        {
            //Check if patient exists
            var patientFromRepo = _repository.Exist(Dni);
            if (patientFromRepo == null)
                return NotFound();
            
            _repository.Delete(patientFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

    }
}