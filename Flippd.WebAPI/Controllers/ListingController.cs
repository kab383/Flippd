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

        [HttpGet]
        public async Task<IActionResult> GetAllListings()
        {
            var listings = await _service.GetAllListingsAsync();
            return Ok(listings);
        }

        [HttpGet("City")]
        public async Task<IActionResult> GetAllListingsByCity([FromBody] ListingGetByCity city)
        {
            var listingDetail = await _service.GetAllListingsByCityAsync(city.Name);
            if(listingDetail is null)
            {
                return NotFound();
            }
            return Ok(listingDetail);
        }

        [HttpGet("Zip")]
        public async Task<IActionResult> GetAllListingsByZip(int zip)
        {
            var listingDetail = await _service.GetAllListingsByZipCode(zip);
            if(listingDetail is null)
            {
                return NotFound();
            }
            return Ok(listingDetail);
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

        [HttpPut]
        public async Task<IActionResult> UpdateListingById([FromBody] ListingUpdate request)
        {
            if(!ModelState.IsValid)
            return BadRequest(ModelState);

            return await _service.UpdateListingAsync(request)
            ? Ok("Listing updated successfully.")
            : BadRequest("Listing could not be updated");
        }

        [HttpDelete("{listingId:int}")]
        public async Task<IActionResult> DeleteListing([FromRoute] int listingId)
        {
            return await _service.DeleteListingAsync(listingId)
            ? Ok($"Listing {listingId} was deleted successfully.")
            : BadRequest($"Listing {listingId} could not be deleted.");
        }
    }
}
