using APIProjekt.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projekt.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeReportsController : ControllerBase
    {
        private IProjekt<TimeReport> _projekt;
        public TimeReportsController(IProjekt<TimeReport> projekt)
        {
            _projekt = projekt;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTimeRep()
        {
            try
            {
                return Ok(await _projekt.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrieve data from database...");
            }
        }

        //Get only one time report
        [HttpGet("{id:int}")]
        public async Task<ActionResult<TimeReport>> GetTimeRep(int id)
        {
            try
            {
                var result = await _projekt.GetSingle(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrieve data from database...");
            }
        }

        [HttpPost]
        public async Task<ActionResult<TimeReport>> AddTimeRep(TimeReport time)
        {
            try
            {
                if (time == null)
                {
                    return BadRequest();
                }
                var addTime = await _projekt.Add(time);
                return CreatedAtAction(nameof(GetTimeRep), new { id = addTime.TimeReportId }, addTime);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to add data from database...");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TimeReport>> DeleteTime(int id)
        {
            try
            {
                var delete = await _projekt.GetSingle(id);
                if (delete == null)
                {
                    return NotFound($"Time Report with ID {id} not found...");
                }
                return await _projekt.Delete(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to delete data from database...");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TimeReport>> UpdateTime(int id, TimeReport tr)
        {
            try
            {
                if (id != tr.TimeReportId)
                {
                    return BadRequest("Time Report ID does not match...");
                }
                var update = await _projekt.GetSingle(id);
                if (update == null)
                {
                    return NotFound($"Person with ID {id} not found...");
                }
                return await _projekt.Update(tr);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to update data from database...");
            }
        }
    }
}
