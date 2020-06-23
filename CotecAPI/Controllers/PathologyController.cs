using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CotecAPI.Models;

namespace CotecAPI.Controllers
{
    [Route("api/v#/admin/[controller]")]
    [ApiController]
    public class PathologiesController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Pathology>>> Get()
        {
            var listPathology = await GetListPathology();

            if (listPathology.Count < 0)
                return NotFound();

            return listPathology;
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<Pathology>> Get(string name)
        {
            var listPathology = await GetListPathology();

            var getPathology = listPathology.Find(u => u.Name == name);

            return getPathology;
        }

        [HttpPost]
        public async Task<ActionResult<List<Pathology>>> Post(Pathology pathology)
        {
            var listPathology = await GetListPathology();

            listPathology.Add(new Pathology(){
                Name = pathology.Name, 
                Symptoms = pathology.Symptoms, 
                Description = pathology.Description, 
                Treatment = pathology.Treatment
            }
            );

            return listPathology;
        }

        [HttpPut]
        public async Task<ActionResult<List<Pathology>>> Put(Pathology pathology)
        {
            var listPathology = await GetListPathology();

            var getPathology = listPathology.Find(u => u.Name == pathology.Name);

            if (getPathology == null)
                return NotFound();

            listPathology.First(u => u.Name == getPathology.Name).Name = pathology.Name;
            listPathology.First(u => u.Name == getPathology.Name).Symptoms = pathology.Symptoms;
            listPathology.First(u => u.Name == getPathology.Name).Description = pathology.Description;
            listPathology.First(u => u.Name == getPathology.Name).Treatment = pathology.Treatment;

            return listPathology;
        }

        [HttpPatch]
        public async Task<ActionResult<List<Pathology>>> Patch(string name)
        {
            var listPathology = await GetListPathology();

            var getPathology = listPathology.Find(u => u.Name == name);

            if (getPathology == null)
                return NotFound();

            // duda
            return listPathology;
        }

        [HttpDelete("{name}")]
        public async Task<ActionResult<List<Pathology>>> Delete(string name)
        {
            var listPathology = await GetListPathology();

            var getPathology = listPathology.Find(u => u.Name == name);

            if (getPathology == null)
                return NotFound();

            listPathology.Remove(getPathology);
            return listPathology;
        }

        private async Task<List<Pathology>> GetListPathology()
        {
            var listPathology = new List<Pathology>()
            {
                new Pathology(){Name = "a", Symptoms = "a", Description = "a", Treatment = "a"},
                new Pathology(){Name = "b", Symptoms = "b", Description = "b", Treatment = "b"}
            };

            return listPathology;
        }
    }
}