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
    public class ProjectsController : ControllerBase
    {
        private IProjekt<Project> _projekt;
        public ProjectsController(IProjekt<Project> projekt)
        {
            _projekt = projekt;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProjects()
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

        //Get project with employees
        [HttpGet("emp/{id}")]
        public async Task<IActionResult> GetProject(int id)
        {
            try
            {
                return Ok(await _projekt.GetOne(id));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrieve data from database...");
            }
        }

        //Get only one project
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Project>> GetOnlyProject(int id)
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
        public async Task<ActionResult<Project>> AddProject(Project pro)
        {
            try
            {
                if (pro == null)
                {
                    return BadRequest();
                }
                var addPro = await _projekt.Add(pro);
                return CreatedAtAction(nameof(GetOnlyProject), new { id = addPro.ProjectId }, addPro);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to add data from database...");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Project>> DeleteProject(int id)
        {
            try
            {
                var delete = await _projekt.GetSingle(id);
                if (delete == null)
                {
                    return NotFound($"Project with ID {id} not found...");
                }
                return await _projekt.Delete(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to delete data from database...");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Project>> UpdateProject(int id, Project pro)
        {
            try
            {
                if (id != pro.ProjectId)
                {
                    return BadRequest("Employee ID does not match...");
                }
                var update = await _projekt.GetSingle(id);
                if (update == null)
                {
                    return NotFound($"Person with ID {id} not found...");
                }
                return await _projekt.Update(pro);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to update data from database...");
            }
        }
    }
}
