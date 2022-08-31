using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}
