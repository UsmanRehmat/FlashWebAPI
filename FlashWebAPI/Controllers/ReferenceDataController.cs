using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlashWebAPI.Models;
using FlashWebAPI.Services;
using Microsoft.AspNetCore.Http;


namespace FlashWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/ReferenceData")]
    public class ReferenceDataController : Controller
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

        [HttpPost]
        [Route("AddStationFaults")]
        public bool AddStationFaults([FromBody]StationFaults stationFault)
        {
            if (stationFault != null)
            {
                return ReferenceDataService.AddStationFaults(stationFault);
            }
            else
            {
                return false;
            }

        }
        [HttpPost]
        [Route("AddCorrectiveAction")]
        public bool AddCorrectiveAction([FromBody]StationFaults stationFault)
        {
            if (stationFault != null)
            {
                return ReferenceDataService.AddCorrectiveAction(stationFault.StationName, stationFault.Faults, stationFault.CorrectiveActions.ToList());
            }
            else
            {
                return false;
            }

        }
        [HttpGet]
        [Route("GetStationFaults")]
        public List<StationFaults> GetStationFaults([FromQuery] string stationName, [FromQuery] string assembly)
        {
            if (!string.Empty.Equals(stationName))
            {
                return ReferenceDataService.GetStationFaults(stationName, assembly);
            }
            else
            {
                return null;
            }

        }
        [HttpGet]
        [Route("GetCorrectiveActions")]
        public List<CorrectiveAction> GetCorrectiveActions([FromQuery] string stationName, [FromQuery] string fault, [FromQuery] string assembly)
        {
            if (!string.Empty.Equals(stationName) && !string.Empty.Equals(fault) && !string.Empty.Equals(assembly))
            {
                return ReferenceDataService.GetCorrectiveAction(stationName, fault, assembly);
            }
            else
            {
                return null;
            }

        }

    }
}