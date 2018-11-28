using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlashWebAPI.Models;
using FlashWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlashWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/StationFaults")]
    public class StationFaultsController : Controller
    {
        [HttpGet]
        [Route("GetAll")]
        public List<StationFaults> GetAll()
        {
            return ReferenceDataService.GetAll();
        }
        [HttpGet]
        [Route("Get")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}