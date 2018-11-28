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
    [Route("api/Test")]
    public class TestController : Controller
    {
        [Route("GetAll")]
        [HttpGet]
        public List<QualityTest> GetAll()
        {
            return QualityTestService.GetAll();
        }

        [Route("checkstatus")]
        [HttpGet]
        public bool getStatus([FromQuery] string rfid, [FromQuery]string testName)
        {
            return QualityTestService.CheckStatusofTest(rfid,testName);
        }
        [Route("GetFailedTestUnit")]
        [HttpGet]
        public QualityTest GetFailedTestUnit([FromQuery] string stationName,[FromQuery] string assembly)
        {
            return QualityTestService.GetFailedTestUnit(stationName, assembly);
        }
        [Route("GetFailedRepairingUnit")]
        [HttpGet]
        public QualityTest GetFailedRepairingUnit([FromQuery] string stationName, [FromQuery] string assembly)
        {
            return QualityTestService.GetFailedRepairingUnit(stationName, assembly);
        }
        [Route("GetFailedRepairingUnits")]
        [HttpGet]
        public QualityTest GetFailedRepairingUnit([FromQuery] string repairingStationName)
        {
            return QualityTestService.GetFailedRepairingUnit(repairingStationName);
        }
        [Route("AddFault")]
        [HttpPost]
        public bool AddFault([FromBody] QualityTest test)
        {
            if (test != null)
            {
                return QualityTestService.AddPreleminaryFaults(test);
            }
            else
            {
                return false;
            }
            
        }
        [Route("AddRepairingUnit")]
        [HttpPost]
        public bool AddRepairingUnit([FromBody] QualityTest test)
        {
            if (test != null)
            {
                return QualityTestService.AddRepairingUnit(test);
            }
            else
            {
                return false;
            }

        }

        

    }
}