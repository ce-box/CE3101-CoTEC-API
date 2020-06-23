using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CotecAPI.Models;

namespace CotecAPI.Controllers
{
    [Route("api/v#/admin/[controller]")]
    [ApiController]
    public class MedicinesController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Medication>>> Get()
        {
            var listMedication = await GetListMedication();

            if (listMedication.Count < 0)
                return NotFound();

            return listMedication;
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Medication>> Get(int Id)
        {
            var listMedication = await GetListMedication();

            var getMedication = listMedication.Find(u => u.Id == Id);

            return getMedication;
        }

        [HttpPost]
        public async Task<ActionResult<List<Medication>>> Post(Medication medication)
        {
            var listMedication = await GetListMedication();

            listMedication.Add(new Medication(){
                Id = medication.Id,
                Name = medication.Name
            }
            );

            return listMedication;
        }

        [HttpPut]
        public async Task<ActionResult<List<Medication>>> Put(Medication medication)
        {
            var listMedication = await GetListMedication();

            var getMedication = listMedication.Find(u => u.Id == medication.Id);

            if (getMedication == null)
                return NotFound();

            listMedication.First(u => u.Id == getMedication.Id).Id = medication.Id;
            listMedication.First(u => u.Id == getMedication.Id).Name = medication.Name;

            return listMedication;
        }

        [HttpPatch]
        public async Task<ActionResult<List<Medication>>> Patch(int Id)
        {
            var listMedication = await GetListMedication();

            var getMedication = listMedication.Find(u => u.Id == Id);

            if (getMedication == null)
                return NotFound();

            // duda
            return listMedication;
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<Medication>>> Delete(int Id)
        {
            var listMedication = await GetListMedication();

            var getMedication = listMedication.Find(u => u.Id == Id);

            if (getMedication == null)
                return NotFound();

            listMedication.Remove(getMedication);
            return listMedication;
        }

        private async Task<List<Medication>> GetListMedication()
        {
            var listMedication = new List<Medication>()
            {
                new Medication(){Id=0, Name = "a"},
                new Medication(){Id=1, Name = "b"}
            };

            return listMedication;
        }
    }
}