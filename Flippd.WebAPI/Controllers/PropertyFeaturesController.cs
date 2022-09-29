using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flippd.Models.PropertyFeatures;
using Flippd.Services.PropertyFeatures;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Flippd.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyFeaturesController : ControllerBase
    {
        private readonly IPropertyFeaturesService _service;
        public PropertyFeaturesController(IPropertyFeaturesService service)
        {
            _service = service;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreatePropertyFeatures([FromBody] PropertyFeaturesCreate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registerResult = await _service.CreatePropertyFeaturesAsync(model);
            if (registerResult)
            {
                return Ok("Property features Added.");
            }

            return BadRequest("Property features could not be added");
        }
        
        [HttpGet("{listingId:int}")]
        public async Task<IActionResult> GetById([FromRoute] int listingId)
        {
            var propertyFeaturesDetail = await _service.GetPropertyFeaturesByPropertyFeaturesIdAsync(listingId);

            if (propertyFeaturesDetail is null)
            {
                return NotFound();
            }

            return Ok(propertyFeaturesDetail);
        }

        // PUT 
        [HttpPut("Update")]
        public async Task<IActionResult> UpdatePropertyFeaturesById([FromBody] PropertyFeaturesUpdate request)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return await _service.UpdatePropertyFeaturesAsync(request)
            ? Ok("Property Features updated successfully.")
            : BadRequest("Property Features could not be updated.");
        }

        // DELETE 
        [HttpDelete("{PropertyFeaturesId:int}")]
        public async Task<IActionResult> DeletePropertyFeatures([FromRoute] int propertyFeaturesId)
        {
            return await _service.DeletePropertyFeaturesAsync(propertyFeaturesId)
            ? Ok($"Property {propertyFeaturesId} features successfully deleted.")
            : BadRequest($"Property {propertyFeaturesId} features could not be deleted.");
        }
    }
}
