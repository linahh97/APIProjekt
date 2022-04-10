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
    public class EmployeesController : ControllerBase
    {
        private IProjekt<Employee> _projekt;
        public EmployeesController(IProjekt<Employee> projekt)
        {
            _projekt = projekt;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
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

        //Get employee with timereport
        [HttpGet("time/{id}")]
        public async Task<IActionResult> GetEmpTimeRep(int id)
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

        //Get only one employee
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
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

        //Adds new employee
        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployee(Employee emp)
        {
            try
            {
                if (emp == null)
                {
                    return BadRequest();
                }
                var addEmp = await _projekt.Add(emp);
                return CreatedAtAction(nameof(GetEmployee), new { id = addEmp.EmployeeId }, addEmp);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to add data from database...");
            }
        }

        //Delete employee
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            try
            {
                var delete = await _projekt.GetSingle(id);
                if (delete == null)
                {
                    return NotFound($"Employee ID {id} not found...");
                }
                return await _projekt.Delete(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to delete data from database...");
            }
        }

        //Updates employee
        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id, Employee emp)
        {
            try
            {
                if (id != emp.EmployeeId)
                {
                    return BadRequest("Employee ID does not match...");
                }
                var update = await _projekt.GetSingle(id);
                if (update == null)
                {
                    return NotFound($"Person with ID {id} not found...");
                }
                return await _projekt.Update(emp);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to update data from database...");
            }
        }
    }
}
