using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CotecAPI.Models;

namespace CotecAPI.Controllers
{
    [Route("api/v#/admin/[controller]")]
    [ApiController]
    public class ContainmentController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<ContainmentMeasure>>> Get()
        {
            var listContainmentMeasure = await GetListContainmentMeasure();

            if (listContainmentMeasure.Count < 0)
                return NotFound();

            return listContainmentMeasure;
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<ContainmentMeasure>> Get(int Id)
        {
            var listContainmentMeasure = await GetListContainmentMeasure();

            var getContainmentMeasure = listContainmentMeasure.Find(u => u.Id == Id);

            return getContainmentMeasure;
        }

        [HttpPost]
        public async Task<ActionResult<List<ContainmentMeasure>>> Post(ContainmentMeasure containment)
        {
            var listContainmentMeasure = await GetListContainmentMeasure();

            listContainmentMeasure.Add(new ContainmentMeasure(){
                Id = containment.Id,
                Name = containment.Name
            }
            );

            return listContainmentMeasure;
        }

        [HttpPut]
        public async Task<ActionResult<List<ContainmentMeasure>>> Put(ContainmentMeasure containment)
        {
            var listContainmentMeasure = await GetListContainmentMeasure();

            var getContainmentMeasure = listContainmentMeasure.Find(u => u.Id == containment.Id);

            if (getContainmentMeasure == null)
                return NotFound();

            listContainmentMeasure.First(u => u.Id == getContainmentMeasure.Id).Id = containment.Id;
            listContainmentMeasure.First(u => u.Id == getContainmentMeasure.Id).Name = containment.Name;

            return listContainmentMeasure;
        }

        [HttpPatch]
        public async Task<ActionResult<List<ContainmentMeasure>>> Patch(int Id)
        {
            var listContainmentMeasure = await GetListContainmentMeasure();

            var getContainmentMeasure = listContainmentMeasure.Find(u => u.Id == Id);

            if (getContainmentMeasure == null)
                return NotFound();

            // duda
            return listContainmentMeasure;
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<ContainmentMeasure>>> Delete(int Id)
        {
            var listContainmentMeasure = await GetListContainmentMeasure();

            var getContainmentMeasure = listContainmentMeasure.Find(u => u.Id == Id);

            if (getContainmentMeasure == null)
                return NotFound();

            listContainmentMeasure.Remove(getContainmentMeasure);
            return listContainmentMeasure;
        }

        private async Task<List<ContainmentMeasure>> GetListContainmentMeasure()
        {
            var listContainmentMeasure = new List<ContainmentMeasure>()
            {
                new ContainmentMeasure(){Id=0, Name = "a"},
                new ContainmentMeasure(){Id=1, Name = "b"}
            };

            return listContainmentMeasure;
        }
    }
}