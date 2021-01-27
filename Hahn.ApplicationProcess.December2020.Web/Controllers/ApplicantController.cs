using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hahn.ApplicationProcess.December2020.Domain.Interfaces;
using Hahn.ApplicationProcess.December2020.Domain.Models;
using Hahn.ApplicationProcess.December2020.Domain.Models.ApplicantModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Hahn.ApplicationProcess.December2020.Web.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ApplicantController : ControllerBase
    {
        private const string CONTROLLERENTITY = "Applicant";
        private readonly ILogger<ApplicantController> _logger;
        private readonly IApplicantBusiness _applicantBusiness;

        public ApplicantController(ILogger<ApplicantController> logger, IApplicantBusiness applicantBusiness)
        {
            _logger = logger;
            _applicantBusiness = applicantBusiness;
        }

        /// <summary>
        /// Get a applicant
        /// </summary>
        /// <param name="id" example="1"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApplicantGet), 201)]
        [ProducesResponseType(typeof(IEnumerable<string>), 400)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                _logger.LogDebug($"REST request to get {CONTROLLERENTITY} : {id}");
                ApplicantGet applicantGet = await _applicantBusiness.GetById(id);
                return StatusCode(201, applicantGet);
            }
            catch (Exception exception)
            {
                _logger.LogError($"Error Occured in {Request.Path}: {exception.Message}");
                return BadRequest(exception.Message);
            }
            
        }
        /// <summary>
        /// Get all of applicants
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<ApplicantGet>), 201)]
        [ProducesResponseType(typeof(IEnumerable<string>), 400)]
        public async Task<IActionResult> Get()
        {
            try
            {
                _logger.LogDebug($"REST request to get all of {CONTROLLERENTITY}");
                List<ApplicantGet> applicantGet = await _applicantBusiness.GetAll();
                return StatusCode(201, applicantGet);
            }
            catch (Exception exception)
            {
                _logger.LogError($"Error Occured in {Request.Path}: {exception.Message}");
                return BadRequest(exception.Message);
            }
            
        }
        /// <summary>
        /// Create a new applicant
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(string), 201)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 500)]
        
        public async Task<IActionResult> Post([FromBody] ApplicantAdd model)
        {
            try
            {
                _logger.LogDebug($"REST request to create new {CONTROLLERENTITY} : {JsonConvert.SerializeObject(model)}");
                ApplicantGet applicantGet = await _applicantBusiness.Add(model);
                string getUrl = $"{Request.Host.ToString()}/{applicantGet.Id}";
                return StatusCode(201, new ResponseModel(applicantGet.Id, getUrl));
            }
            catch (Exception exception)
            {
                _logger.LogError($"Error Occured in {Request.Path}: {exception.Message}");
                return StatusCode(500, exception.Message);
            }
        }
        
        /// <summary>
        /// Edit an applicant
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(string), 201)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<IActionResult> Put([FromBody] ApplicantUpdate model)
        {
            if (model.Id <= 0)
                return BadRequest($"Invalid parameter!");
            try
            {
                _logger.LogDebug($"REST request to edit {CONTROLLERENTITY} : {JsonConvert.SerializeObject(model)}");
                ApplicantGet applicantGet = await _applicantBusiness.Update(model);
                string getUrl = $"{Request.Host.ToString()}/{applicantGet.Id}";
                return StatusCode(201, new ResponseModel(applicantGet.Id, getUrl));
            }
            catch (Exception exception)
            {
                _logger.LogError($"Error Occured in {Request.Path}: {exception.Message}");
                return StatusCode(500, exception.Message);
            }
        }
        /// <summary>
        /// Delete a applicant
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
                await _applicantBusiness.Delete(new ApplicantDelete(id));
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