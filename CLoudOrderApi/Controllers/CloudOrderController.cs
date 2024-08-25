using CloudOrderApi.CloudModels;
using CloudOrderApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using System.Net;

namespace CloudOrderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CloudOrderController : ControllerBase
    {
        private ICloudOrderService _cloudOrderService;

        public CloudOrderController(ICloudOrderService cloudOrderService)
        {
            _cloudOrderService = cloudOrderService;
        }

        [HttpGet]
        [Route("GetCloudBiId")]
        public ActionResult<CloudModelResponse> GetCloudBiId([FromQuery]int id)
        {
            try
            {
                var cloud = _cloudOrderService.GetCloudById(id);
                return Ok(cloud);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }           
        }

        [HttpGet]
        [Route("GetAllClouds")]
        public ActionResult<IEnumerable<CloudModelResponse>> GetAllClouds()
        {
            var cloud = _cloudOrderService.GetAllClouds();
            return Ok(cloud);
        }

        [HttpPost]
        [Route("CreateCloud")]
        public IActionResult CreateCloud([FromBody] CloudModelRequest model)
        {
            try
            {
                _cloudOrderService.CreateCloud(model);
                   return Ok(model);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
            
        }
    }
}
