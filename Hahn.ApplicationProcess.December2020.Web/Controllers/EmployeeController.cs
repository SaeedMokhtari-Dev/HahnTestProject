using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hahn.ApplicationProcess.December2020.Data.Entities;
using Hahn.ApplicationProcess.December2020.Domain.Interfaces;
using Hahn.ApplicationProcess.December2020.Domain.Models.EmployeeModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Hahn.ApplicationProcess.December2020.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeBusiness _employeeBusiness;

        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeBusiness employeeBusiness)
        {
            _logger = logger;
            _employeeBusiness = employeeBusiness;
        }

        /// <summary>
        /// Get a employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(EmployeeGet), 201)]
        [ProducesResponseType(typeof(IEnumerable<string>), 400)]
        [Route("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _employeeBusiness.GetById(id));
        }
        /// <summary>
        /// Create a new employee
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(string), 201)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 500)]
        [Route("post")]
        public async Task<IActionResult> Post([FromBody] EmployeeAdd model)
        {
            try
            {
                EmployeeGet employeeGet = await _employeeBusiness.Add(model);
                string getUrl = $"{Request.Host.Value}/get/{employeeGet.Id}";
                return Ok(getUrl);
            }
            catch (Exception exception)
            {
                return StatusCode(500, $"{exception.Message} - {exception.InnerException?.Message}");
            }
        }
        
        /// <summary>
        /// Edit an employee
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(string), 201)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 500)]
        [Route("put")]
        public async Task<IActionResult> Put([FromBody] EmployeeUpdate model)
        {
            if (model.Id <= 0)
                return BadRequest($"Invalid parameter!");
            try
            {
                EmployeeGet employeeGet = await _employeeBusiness.Update(model);
                string getUrl = $"{Request.Host.Value}/get/{employeeGet.Id}";
                return Ok(getUrl);
            }
            catch (Exception exception)
            {
                return StatusCode(500, $"{exception.Message} - {exception.InnerException?.Message}");
            }
        }
        /// <summary>
        /// Delete a employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(typeof(bool), 201)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 500)]
        [Route("delete/{Id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest($"Invalid parameter!");

            try
            {
                await _employeeBusiness.Delete(new EmployeeDelete(id));
                return Ok(true);
            }
            catch (Exception exception)
            {
                return StatusCode(500, $"{exception.Message} - {exception.InnerException?.Message}");
            }
        }
    }
}