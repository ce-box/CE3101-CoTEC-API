using System.Collections.Generic;
using CotecAPI.DataAccess.Database;
using System.Linq;
using CotecAPI.Models.Entities;
using CotecAPI.Models.Views;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;

namespace CotecAPI.DataAccess.Repositories
{
    public class ContactRepo
    {
        private readonly CotecContext _context;

        // Injects the Data Base Context
        public ContactRepo(CotecContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Add a new contact to the database.
        /// </summary>
        /// <param name="contact">Contact to be added.</param>
        /// <returns> void </returns>
        public void CreateContact(ContactedPerson contact)
        {    
            try
            {
                _context.ContactedPersons.Add(contact);
            }
            catch(DbUpdateException e)
            { 
                var sqlException = e.GetBaseException() as SqlException;
                Console.Write("Problem Creating Patient\nExeption: "+ sqlException.ToString()); 
            }
        }

        /// <summary>
        /// Assign a contact to a patient's contact list.
        /// </summary>
        /// <param name="patientDni">Patient identity number.</param>
        /// <param name="contactDni">Contact identity number.</param>
        /// <returns> void </returns>
        public void AssignContact(string patientDni, string contactDni)
        {
            var relationship = new PersonsContactedByPatient() {PatientDni=patientDni,ContactDni= contactDni,MeetingDate=DateTime.Parse("2020-01-01")};
            _context.ContactedByPacients.Add(relationship);
        }

        /// <summary>
        /// Check if there is a contact in the database with a given Dni associated with a specific patient.
        /// </summary>
        /// <param name="patientDni">Patient identity number.</param>
        /// <param name="contactDni">Contact identity number.</param>
        /// <returns>If it exists, it returns the Object, otherwise it returns null.</returns>
        public ContactedPerson ExistContactedPerson(string contactDni)
        {
            return _context.ContactedPersons
                           .FirstOrDefault(c => c.Dni == contactDni);
        }

        /// <summary>
        /// Check if there is a contact in the database with a given Dni associated with a specific patient.
        /// </summary>
        /// <param name="patientDni">Patient identity number.</param>
        /// <param name="contactDni">Contact identity number.</param>
        /// <returns>If it exists, it returns the Object, otherwise it returns null.</returns>
        public PersonsContactedByPatient ExitsRegisteredContact(string patientDni,string contactDni)
        {
            return _context.ContactedByPacients
                           .FirstOrDefault(
                               c => c.ContactDni == contactDni && 
                               c.PatientDni == patientDni);
        }

        /// <summary>
        /// A person obtains giving his Dni.
        /// </summary>
        /// <param name="contactDni">Contact identity number.</param>
        /// <returns>Contact view instance</returns>
        public ContactView GetContactByDni(string contactDni)
        {
            var param = new SqlParameter("@contactDni",contactDni); 
            var contact =  _context.Set<ContactView>()
                                   .FromSqlRaw($"EXEC [ContactSummary] @contactDni={contactDni}")
                                   .ToList();
            return contact[0];
        }

        /// <summary>
        /// Get all the contacts associated with a patient.
        /// </summary>
        /// <param name="patientDni">Patient identity number.</param>
        /// <returns>Contact view instance List</returns>
        public IEnumerable<ContactView> GetPatientContacts(string patientDni)
        {
            var contacts = _context.Set<ContactView>()
                                   .FromSqlRaw($"EXEC [GetContacts] @patientDni={patientDni}")
                                   .ToList();
            return contacts;
        }

        /// <summary>
        /// Update a contact's information.
        /// </summary>
        /// <param name="contact">Contact to update</param>
        public void UpdateContact(ContactedPerson contact)
        {
            // The method should not be implemented
        }

        /// <summary>
        /// Delete a contact from the database.
        /// </summary>
        /// <param name="contact">Contact to delete.</param>
        public void DeleteContact(ContactedPerson contact)
        {
            _context.ContactedPersons.Remove(contact);
        }

        /// <summary>
        /// Saves all changes made to the database after a transaction.
        /// </summary>
        /// <returns>True if the changes were saved successfully, false if an error occurs.</returns>
        public bool SaveChanges()
        {
            return ( _context.SaveChanges() >= 0);
        }
    }
}