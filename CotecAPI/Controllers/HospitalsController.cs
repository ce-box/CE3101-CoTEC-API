using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CotecAPI.Models;

namespace CotecAPI.Controllers
{
    [Route("api/v#/admin/[controller]")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Hospital>>> Get()
        {
            var listHospital = await GetListHospital();

            if (listHospital.Count < 0)
                return NotFound();

            return listHospital;
        }

        [HttpGet("{Ids}")]
        public async Task<ActionResult<List<Hospital>>> Get(string ids,int s)
        {
            var listHospital = await GetListHospital();

            var listHospitalCountry = new List<Hospital>(){};

            for(int x = 0; x <= listHospital.Count; x++){
                if(listHospital[x].Country == ids){
                    listHospitalCountry.Add(listHospital[x]);
                }
            }
            
            return listHospitalCountry;
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Hospital>> Get(int Id)
        {
            var listHospital = await GetListHospital();

            var getHospital = listHospital.Find(u => u.Id == Id);

            return getHospital;
        }

        [HttpPost]
        public async Task<ActionResult<List<Hospital>>> Post(Hospital hospital)
        {
            var listHospital = await GetListHospital();

            listHospital.Add(new Hospital(){
                Id = hospital.Id,
                Name = hospital.Name
            }
            );

            return listHospital;
        }

        [HttpPut]
        public async Task<ActionResult<List<Hospital>>> Put(Hospital hospital)
        {
            var listHospital = await GetListHospital();

            var getHospital = listHospital.Find(u => u.Id == hospital.Id);

            if (getHospital == null)
                return NotFound();

            listHospital.First(u => u.Id == getHospital.Id).Id = hospital.Id;
            listHospital.First(u => u.Id == getHospital.Id).Name = hospital.Name;

            return listHospital;
        }

        [HttpPatch]
        public async Task<ActionResult<List<Hospital>>> Patch(int Id)
        {
            var listHospital = await GetListHospital();

            var getHospital = listHospital.Find(u => u.Id == Id);

            if (getHospital == null)
                return NotFound();

            // duda
            return listHospital;
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<Hospital>>> Delete(int Id)
        {
            var listHospital = await GetListHospital();

            var getHospital = listHospital.Find(u => u.Id == Id);

            if (getHospital == null)
                return NotFound();

            listHospital.Remove(getHospital);
            return listHospital;
        }

        private async Task<List<Hospital>> GetListHospital()
        {
            var listHospital = new List<Hospital>()
            {
                new Hospital(){Id=0, Name = "a"},
                new Hospital(){Id=1, Name = "b"}
            };

            return listHospital;
        }
    }
}