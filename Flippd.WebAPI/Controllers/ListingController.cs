using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flippd.Models.Listing;
using Flippd.Services.Listing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Flippd.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListingController : ControllerBase
    {
        private readonly IListingService _service;
        public ListingController(IListingService service)
        {
            _service = service;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterListing([FromBody] ListingRegister model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registerResult = await _service.RegisterListingAsync(model);
            if(registerResult)
            {
                return Ok("Listing was registered");
            }

            return BadRequest("Listing could not be registered");
        }

        [HttpGet("{listingId:int}")]
        public async Task<IActionResult> GetByListingId([FromRoute] int listingId)
        {
            var listingDetail = await _service.GetListingByIdAsync(listingId);

            if (listingDetail is null)
            {
                return NotFound();
            }
            return Ok(listingDetail);
        }
    }
}
