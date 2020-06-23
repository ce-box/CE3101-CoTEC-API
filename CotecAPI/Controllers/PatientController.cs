using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CotecAPI.Models;

namespace CotecAPI.Controllers
{
    [Route("api/v#/hospital/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Patient>>> Get()
        {
            var listPatient = await GetListPatient();

            if (listPatient.Count < 0)
                return NotFound();

            return listPatient;
        }

        [HttpGet("{Dni}")]
        public async Task<ActionResult<Patient>> Get(string Dni)
        {
            var listPatient = await GetListPatient();

            var getPatient = listPatient.Find(u => u.Dni == Dni);

            return getPatient;
        }

        [HttpPost]
        public async Task<ActionResult<List<Patient>>> Post(Patient patient)
        {
            var listPatient = await GetListPatient();

            listPatient.Add(new Patient(){
                Dni=patient.Dni, 
                Name =patient.Name, 
                LastName=patient.LastName, 
                Hospitalized= patient.Hospitalized, 
                ICU = patient.ICU
            }
            );

            return listPatient;
        }

        [HttpPut]
        public async Task<ActionResult<List<Patient>>> Put(Patient patient)
        {
            var listPatient = await GetListPatient();

            var getPatient = listPatient.Find(u => u.Dni == patient.Dni);

            if (getPatient == null)
                return NotFound();

            listPatient.First(u => u.Dni == getPatient.Dni).Dni = patient.Dni;
            listPatient.First(u => u.Dni == getPatient.Dni).Name = patient.Name;
            listPatient.First(u => u.Dni == getPatient.Dni).LastName = patient.LastName;
            listPatient.First(u => u.Dni == getPatient.Dni).Hospitalized = patient.Hospitalized;
            listPatient.First(u => u.Dni == getPatient.Dni).ICU = patient.ICU;

            return listPatient;
        }

        [HttpPatch]
        public async Task<ActionResult<List<Patient>>> Patch(string Dni)
        {
            var listPatient = await GetListPatient();

            var getPatient = listPatient.Find(u => u.Dni == Dni);

            if (getPatient == null)
                return NotFound();

            // duda
            return listPatient;
        }

        [HttpDelete("{Dni}")]
        public async Task<ActionResult<List<Patient>>> Delete(string Dni)
        {
            var listPatient = await GetListPatient();

            var getPatient = listPatient.Find(u => u.Dni == Dni);

            if (getPatient == null)
                return NotFound();

            listPatient.Remove(getPatient);
            return listPatient;
        }

        private async Task<List<Patient>> GetListPatient()
        {
            var listPatient = new List<Patient>()
            {
                new Patient(){Dni="a", Name = "a", LastName="a", Hospitalized= true, ICU = false},
                new Patient(){Dni="b", Name = "b", LastName="b", Hospitalized= true, ICU = false}
            };

            return listPatient;
        }
    }
}