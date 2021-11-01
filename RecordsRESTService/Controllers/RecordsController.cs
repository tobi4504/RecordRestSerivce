using EntityLibary;
using Microsoft.AspNetCore.Mvc;
using RecordsRESTService.Interface;
using RecordsRESTService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecordsRESTService.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class RecordsController
    {
        private readonly IRecords repository;

        public RecordsController()
        {
            repository = new MockRecords();
        }

        // Get / Records
        [HttpGet]
        public IEnumerable<Record> Get([FromQuery] string title = null, [FromQuery] string sort_by = null)
        {
            return repository.GetRecords(title, sort_by);
        }


        [HttpPost]
        public IActionResult Post([FromBody] Record value)
        {
            try
            {
                // data object without restriction
                // records
                bool CheckIfItemExist = Get().Any(f => f.Id == value.Id);

                if (!CheckIfItemExist)
                {

                    return Created("SuccesFully Commited", repository.CreateRecord(value));
                }
                else
                {
                    return BadRequest("Item With this Id allready exists");

                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                return BadRequest(e.Message);
            }
        }


    }

  
}
