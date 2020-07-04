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

        // Inject the Data Base Context
        public ContactRepo(CotecContext context)
        {
            _context = context;
        }

        public void CreateContact(ContactedPerson contact)
        {       
            _context.ContactedPersons.Add(contact);
        }

        public void CreateContactRelationship(string p_Dni, string c_Dni)
        {
            var relationship = new PersonsContactedByPatient() {PatientDni=p_Dni,ContactDni= c_Dni,MeetingDate=DateTime.Parse("2020-01-01")};
            _context.ContactedByPacients.Add(relationship);
        }

        public ContactedPerson Exist(string Dni)
        {
            return _context.ContactedPersons.FirstOrDefault(c => c.Dni == Dni);
        }

        public ContactView GetByDni(string Dni)
        {
            var param = new SqlParameter("@contactDni",Dni); 
            var contact =  _context.Set<ContactView>().FromSqlRaw("ContactSummary @contactDni",param).ToList();
            return contact[0];
        }

        public IEnumerable<ContactView> GetPatientContact(string p_Dni)
        {
            var contacts = _context.Set<ContactView>().FromSqlRaw($"EXEC [GetContacts] @patientDni={p_Dni}").ToList();
            return contacts;
        }

        public void Update(ContactedPerson contact)
        {
            // Nothing
        }

        public void Delete(ContactedPerson contact)
        {
            _context.ContactedPersons.Remove(contact);
        }
        public bool SaveChanges()
        {
            return ( _context.SaveChanges() >= 0);
        }
    }
}