using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CotecAPI.Models;

namespace CotecAPI.Controllers
{
    [Route("api/v#/admin/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<PatientStatus>>> Get()
        {
            var listPatientStatus = await GetListPatientStatus();

            if (listPatientStatus.Count < 0)
                return NotFound();

            return listPatientStatus;
        }

        [HttpPost]
        public async Task<ActionResult<List<PatientStatus>>> Post(PatientStatus status)
        {
            var listPatientStatus = await GetListPatientStatus();

            listPatientStatus.Add(new PatientStatus(){
                Id = status.Id,
                Name = status.Name
            }
            );

            return listPatientStatus;
        }

        [HttpPut]
        public async Task<ActionResult<List<PatientStatus>>> Put(PatientStatus status)
        {
            var listPatientStatus = await GetListPatientStatus();

            var getPatientStatus = listPatientStatus.Find(u => u.Id == status.Id);

            if (getPatientStatus == null)
                return NotFound();

            listPatientStatus.First(u => u.Id == getPatientStatus.Id).Id = status.Id;
            listPatientStatus.First(u => u.Id == getPatientStatus.Id).Name = status.Name;

            return listPatientStatus;
        }

        [HttpPatch]
        public async Task<ActionResult<List<PatientStatus>>> Patch(int Id)
        {
            var listPatientStatus = await GetListPatientStatus();

            var getPatientStatus = listPatientStatus.Find(u => u.Id == Id);

            if (getPatientStatus == null)
                return NotFound();

            // duda
            return listPatientStatus;
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<PatientStatus>>> Delete(int Id)
        {
            var listPatientStatus = await GetListPatientStatus();

            var getPatientStatus = listPatientStatus.Find(u => u.Id == Id);

            if (getPatientStatus == null)
                return NotFound();

            listPatientStatus.Remove(getPatientStatus);
            return listPatientStatus;
        }

        private async Task<List<PatientStatus>> GetListPatientStatus()
        {
            var listMedication = new List<PatientStatus>()
            {
                new PatientStatus(){Id=0, Name = "a"},
                new PatientStatus(){Id=1, Name = "b"}
            };

            return listMedication;
        }
    }
}