using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hahn.ApplicationProcess.December2020.Data.Entities;
using Hahn.ApplicationProcess.December2020.Domain.Interfaces;
using Hahn.ApplicationProcess.December2020.Domain.Models.EmployeeModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Filters;

namespace Hahn.ApplicationProcess.December2020.Web.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private const string CONTROLLERENTITY = "Employee";
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
        /// <param name="id" example="1"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EmployeeGet), 201)]
        [ProducesResponseType(typeof(IEnumerable<string>), 400)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                _logger.LogDebug($"REST request to get {CONTROLLERENTITY} : {id}");
                EmployeeGet employeeGet = await _employeeBusiness.GetById(id);
                return StatusCode(201, employeeGet);
            }
            catch (Exception exception)
            {
                _logger.LogError($"Error Occured in {Request.Path}: {exception.Message}");
                return BadRequest(exception.Message);
            }
            
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
        
        public async Task<IActionResult> Post([FromBody] EmployeeAdd model)
        {
            try
            {
                _logger.LogDebug($"REST request to create new {CONTROLLERENTITY} : {JsonConvert.SerializeObject(model)}");
                EmployeeGet employeeGet = await _employeeBusiness.Add(model);
                string getUrl = $"{Request.Host.ToString()}/{employeeGet.Id}";
                return StatusCode(201, getUrl);
            }
            catch (Exception exception)
            {
                _logger.LogError($"Error Occured in {Request.Path}: {exception.Message}");
                return StatusCode(500, exception.Message);
            }
        }
        
        /// <summary>
        /// Edit an employee
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(string), 201)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<IActionResult> Put([FromBody] EmployeeUpdate model)
        {
            if (model.Id <= 0)
                return BadRequest($"Invalid parameter!");
            try
            {
                _logger.LogDebug($"REST request to edit {CONTROLLERENTITY} : {JsonConvert.SerializeObject(model)}");
                EmployeeGet employeeGet = await _employeeBusiness.Update(model);
                string getUrl = $"{Request.Host.ToString()}/{employeeGet.Id}";
                return StatusCode(201, getUrl);
            }
            catch (Exception exception)
            {
                _logger.LogError($"Error Occured in {Request.Path}: {exception.Message}");
                return StatusCode(500, exception.Message);
            }
        }
        /// <summary>
        /// Delete a employee
        /// </summary>
        /// <param name="id" example="1"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), 201)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest($"Invalid parameter!");

            try
            {
                _logger.LogDebug($"REST request to delete {CONTROLLERENTITY} : {id}");
                await _employeeBusiness.Delete(new EmployeeDelete(id));
                return StatusCode(201, true);
            }
            catch (Exception exception)
            {
                _logger.LogError($"Error Occured in {Request.Path}: {exception.Message}");
                return StatusCode(500, exception.Message);
            }
        }
    }
}