using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CotecAPI.Models;

namespace CotecAPI.Controllers
{
    [Route("api/v#/hospital/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<ContactedPerson>>> Get()
        {
            var listContactedPerson = await GetListContactedPerson();

            if (listContactedPerson.Count < 0)
                return NotFound();

            return listContactedPerson;
        }

        [HttpGet("{Dni}")]
        public async Task<ActionResult<ContactedPerson>> Get(string Dni)
        {
            var listContactedPerson = await GetListContactedPerson();

            var getContactedPerson = listContactedPerson.Find(u => u.Dni == Dni);

            return getContactedPerson;
        }

        [HttpPost]
        public async Task<ActionResult<List<ContactedPerson>>> Post(ContactedPerson contactedPerson)
        {
            var listContactedPerson = await GetListContactedPerson();

            listContactedPerson.Add(new ContactedPerson(){
                Dni=contactedPerson.Dni, 
                Name =contactedPerson.Name, 
                LastName=contactedPerson.LastName, 
                Email= contactedPerson.Email, 
                Address = contactedPerson.Address
            }
            );

            return listContactedPerson;
        }

        [HttpPut]
        public async Task<ActionResult<List<ContactedPerson>>> Put(ContactedPerson contactedPerson)
        {
            var listContactedPerson = await GetListContactedPerson();

            var getContactedPerson = listContactedPerson.Find(u => u.Dni == contactedPerson.Dni);

            if (getContactedPerson == null)
                return NotFound();

            listContactedPerson.First(u => u.Dni == getContactedPerson.Dni).Dni = contactedPerson.Dni;
            listContactedPerson.First(u => u.Dni == getContactedPerson.Dni).Name = contactedPerson.Name;
            listContactedPerson.First(u => u.Dni == getContactedPerson.Dni).LastName = contactedPerson.LastName;
            listContactedPerson.First(u => u.Dni == getContactedPerson.Dni).Email = contactedPerson.Email;
            listContactedPerson.First(u => u.Dni == getContactedPerson.Dni).Address = contactedPerson.Address;

            return listContactedPerson;
        }

        [HttpPatch]
        public async Task<ActionResult<List<ContactedPerson>>> Patch(string Dni)
        {
            var listContactedPerson = await GetListContactedPerson();

            var getContactedPerson = listContactedPerson.Find(u => u.Dni == Dni);

            if (getContactedPerson == null)
                return NotFound();

            // duda
            return listContactedPerson;
        }

        [HttpDelete("{Dni}")]
        public async Task<ActionResult<List<ContactedPerson>>> Delete(string Dni)
        {
            var listContactedPerson = await GetListContactedPerson();

            var getContactedPerson = listContactedPerson.Find(u => u.Dni == Dni);

            if (getContactedPerson == null)
                return NotFound();

            listContactedPerson.Remove(getContactedPerson);
            return listContactedPerson;
        }

        private async Task<List<ContactedPerson>> GetListContactedPerson()
        {
            var listContactedPerson = new List<ContactedPerson>()
            {
                new ContactedPerson(){Dni="a", Name = "a", LastName="a", Email= "a", Address = "a"},
                new ContactedPerson(){Dni="b", Name = "b", LastName="b", Email= "b", Address = "b"}
            };

            return listContactedPerson;
        }
    }
}