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
    /// <summary> This service allows you to create, modify and delete contacted people, that is, 
    /// people who had contact with another infected with CoTEC 20. It allows you to assign, edit
    ///  and delete the contact between both people.
    /// </summary>
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ContactRepo _repository;
        private readonly IMapper _mapper;

        public ContactController(ContactRepo repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Add a new contacts to the database and immediately assign the relationship with a patient.
        /// </summary>
        /// <param name="Dni">Patient Identification Number.</param>
        /// <param name="contacts"> List of contact to add. </param>
        /// <returns>Added Contacts List.</returns>
        [HttpPost]
        [Route("api/v1/contacts/new")]
        public ActionResult<IEnumerable<ContactedPerson>> CreateContact([FromQuery] string Dni, [FromBody] IEnumerable<ContactedPerson> contacts) 
        {
            foreach (var contact in contacts)
            {
                var contactFromRepo = _repository.ExistContactedPerson(contact.Dni);
                if(contactFromRepo == null) 
                    _repository.CreateContact(contact);
                var rel = _repository.ExitsRegisteredContact(Dni,contact.Dni);
                if(rel == null) 
                    _repository.AssignContact(Dni,contact.Dni);    
            }
            _repository.SaveChanges();
            
            return Created("https://cotecapi.com/contacts",contacts);
        }

        /// <summary>
        /// Get all the contacts associated with a patient.
        /// </summary>
        /// <param name="Dni"> Patient Dni</param>
        /// <returns> Patient Contact List. </returns>
        [HttpGet]
        [Route("api/v1/contacts/patient")]
        public ActionResult<IEnumerable<ContactView>> GetContacts([FromQuery] string Dni) {
            
            var contacts = _repository.GetPatientContacts(Dni);
            return Ok(contacts);
        }

        /// <summary>
        /// Get a contact given a Dni.
        /// </summary>
        /// <param name="Dni"> Contact Identification Number.</param>
        /// <returns> Contact obtained. </returns>
        [HttpGet]
        [Route("api/v1/contacts")]
        public ActionResult<ContactView> GetContactByDni([FromQuery] string Dni) {
            
            var try_contacts = _repository.ExistContactedPerson(Dni);
            if(try_contacts == null)
                return NotFound();
            var contact = _repository.GetContactByDni(Dni);
            return Ok(contact);
        }

        /// <summary>
        /// Allows you to modify the information of a contact.
        /// </summary>
        /// <param name="Dni"> Contact Identification Number. </param>
        /// <param name="patchDoc"> Patch document for editing. </param>
        /// <returns> NotContent </returns>
        [HttpPatch]
        [Route("api/v1/contacts/edit")]
        public ActionResult EditContact([FromQuery] string Dni, [FromBody] JsonPatchDocument<ContactUpdateDTO> patchDoc)
        {
            // Check if exists
            var contactFromRepo = _repository.ExistContactedPerson(Dni);
            if(contactFromRepo == null)
                return NotFound();
            
            var contactToPatch = _mapper.Map<ContactUpdateDTO>(contactFromRepo);
            patchDoc.ApplyTo(contactToPatch);
            
            _mapper.Map(contactToPatch, contactFromRepo);

            _repository.UpdateContact(contactFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
        
        /// <summary>
        /// Delete a contact from the database.
        /// </summary>
        /// <param name="Dni"> Contact Identification Number</param>
        /// <returns> NoContent. </returns>
        [HttpDelete]
        [Route("api/v1/contacts/delete")]
        public ActionResult DeleteContact([FromQuery] string Dni)
        {
            //Check if patient exists
            var patientFromRepo = _repository.ExistContactedPerson(Dni);
            if (patientFromRepo == null)
                return NotFound();
            
            _repository.DeleteContact(patientFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

    }
}