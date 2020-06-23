using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CotecAPI.Models;

namespace CotecAPI.Controllers
{
    [Route("api/v#/admin/[controller]")]
    [ApiController]
    public class SanitaryController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<SanitaryMeasure>>> Get()
        {
            var listSanitaryMeasure = await GetListSanitaryMeasure();

            if (listSanitaryMeasure.Count < 0)
                return NotFound();

            return listSanitaryMeasure;
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<SanitaryMeasure>> Get(int Id)
        {
            var listSanitaryMeasure = await GetListSanitaryMeasure();

            var getSanitaryMeasure = listSanitaryMeasure.Find(u => u.Id == Id);

            return getSanitaryMeasure;
        }

        [HttpPost]
        public async Task<ActionResult<List<SanitaryMeasure>>> Post(SanitaryMeasure sanitary)
        {
            var listSanitaryMeasure = await GetListSanitaryMeasure();

            listSanitaryMeasure.Add(new SanitaryMeasure(){
                Id = sanitary.Id,
                Name = sanitary.Name
            }
            );

            return listSanitaryMeasure;
        }

        [HttpPut]
        public async Task<ActionResult<List<SanitaryMeasure>>> Put(SanitaryMeasure sanitary)
        {
            var listSanitaryMeasure = await GetListSanitaryMeasure();

            var getSanitaryMeasure = listSanitaryMeasure.Find(u => u.Id == sanitary.Id);

            if (getSanitaryMeasure == null)
                return NotFound();

            listSanitaryMeasure.First(u => u.Id == getSanitaryMeasure.Id).Id = sanitary.Id;
            listSanitaryMeasure.First(u => u.Id == getSanitaryMeasure.Id).Name = sanitary.Name;

            return listSanitaryMeasure;
        }

        [HttpPatch]
        public async Task<ActionResult<List<SanitaryMeasure>>> Patch(int Id)
        {
            var listSanitaryMeasure = await GetListSanitaryMeasure();

            var getSanitaryMeasure = listSanitaryMeasure.Find(u => u.Id == Id);

            if (getSanitaryMeasure == null)
                return NotFound();

            // duda
            return listSanitaryMeasure;
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<SanitaryMeasure>>> Delete(int Id)
        {
            var listSanitaryMeasure = await GetListSanitaryMeasure();

            var getSanitaryMeasure = listSanitaryMeasure.Find(u => u.Id == Id);

            if (getSanitaryMeasure == null)
                return NotFound();

            listSanitaryMeasure.Remove(getSanitaryMeasure);
            return listSanitaryMeasure;
        }

        private async Task<List<SanitaryMeasure>> GetListSanitaryMeasure()
        {
            var listSanitaryMeasure = new List<SanitaryMeasure>()
            {
                new SanitaryMeasure(){Id=0, Name = "a"},
                new SanitaryMeasure(){Id=1, Name = "b"}
            };

            return listSanitaryMeasure;
        }
    }
}