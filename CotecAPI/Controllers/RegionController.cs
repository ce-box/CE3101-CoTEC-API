using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CotecAPI.Models;

namespace CotecAPI.Controllers
{
    [Route("api/v#/admin/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Region>>> Get()
        {
            var listRegion = await GetListRegion();

            if (listRegion.Count < 0)
                return NotFound();

            return listRegion;
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<Region>> Get(string name)
        {
            var listRegion = await GetListRegion();

            var getRegion = listRegion.Find(u => u.Name == name);

            return getRegion;
        }

        [HttpPost]
        public async Task<ActionResult<List<Region>>> Post(Region region)
        {
            var listRegion = await GetListRegion();

            listRegion.Add(new Region(){
                Name = region.Name
            }
            );

            return listRegion;
        }

        [HttpPut]
        public async Task<ActionResult<List<Region>>> Put(Region region)
        {
            var listRegion = await GetListRegion();

            var getRegion = listRegion.Find(u => u.Name == region.Name);

            if (getRegion == null)
                return NotFound();

            listRegion.First(u => u.Name == getRegion.Name).Name = region.Name;

            return listRegion;
        }

        [HttpPatch]
        public async Task<ActionResult<List<Region>>> Patch(string name)
        {
            var listRegion = await GetListRegion();

            var getRegion = listRegion.Find(u => u.Name == name);

            if (getRegion == null)
                return NotFound();

            // duda
            return listRegion;
        }

        [HttpDelete("{name}")]
        public async Task<ActionResult<List<Region>>> Delete(string name)
        {
            var listRegion = await GetListRegion();

            var getRegion = listRegion.Find(u => u.Name == name);

            if (getRegion == null)
                return NotFound();

            listRegion.Remove(getRegion);
            return listRegion;
        }

        private async Task<List<Region>> GetListRegion()
        {
            var listRegion = new List<Region>()
            {
                new Region(){Name = "a"},
                new Region(){Name = "b"}
            };

            return listRegion;
        }
    }
}