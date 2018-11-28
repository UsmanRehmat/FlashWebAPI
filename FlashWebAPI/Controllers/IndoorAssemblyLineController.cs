using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlashWebAPI.Models;
using FlashWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FlashWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/IndoorAssemblyLine")]
    public class IndoorAssemblyLineController : Controller
    {
        [Route("GetAll")]
        [HttpGet]
        public List<InDoorAssemblyLine> GetAll()
        {
             return IndoorAssemblyLineService.GetAll();
        }
        [Route("addInDoorAssemblyUnit")]
        [HttpPost]
        public string AddAssemblyUnit([FromBody]InDoorAssemblyLine inDoorAssemblyLine)
        {
            if (inDoorAssemblyLine != null)
            {
                return IndoorAssemblyLineService.AddInDoorAssemblyUnit(inDoorAssemblyLine);
            }
            else
            {
                return "Data is empty";
            }
        }
        [Route("addInDoorEvaporatorAndMotorQRCode")]
        [HttpPost]
        public string AddEvaporatorAndMotorQRCode(InDoorAssemblyLine inDoorAssemblyLine)
        {
            if (inDoorAssemblyLine != null)
            {
                return IndoorAssemblyLineService.AddEvaporatorAndMotorQRCode(inDoorAssemblyLine);
            }
            else
            {
                return "Data is empty";
            }
        }
        [Route("addInDoorElectricalBoxAndBarCode")]
        [HttpPost]
        public string AddElectricalBoxAndBarCode([FromBody]InDoorAssemblyLine inDoorAssemblyLine)
        {
            if (inDoorAssemblyLine != null)
            {
                return IndoorAssemblyLineService.AddElectricalBoxAndBarCode(inDoorAssemblyLine);
            }
            else
            {
                return "Data is empty";
            }
        }
        [Route("addInDoorPerformanceTest")]
        [HttpPost]
        public string AddPerformanceTest([FromBody] InDoorAssemblyLine inDoorAssemblyLine)
        {
            if (inDoorAssemblyLine != null)
            {
                return IndoorAssemblyLineService.AddPerformanceTest(inDoorAssemblyLine);
            }
            else
            {
                return "Data is empty";
            }
        }
        [Route("addInDoorPerformanceTestForTesting")]
        [HttpPost]
        public string AddPerformanceTestForTesting([FromBody] InDoorAssemblyLine inDoorAssemblyLine)
        {
            if (inDoorAssemblyLine != null)
            {
                return IndoorAssemblyLineService.AddPerformanceTestForTesting(inDoorAssemblyLine);
            }
            else
            {
                return "Data is empty";
            }
        }
        [Route("addInDoorSafetyTest")]
        [HttpPost]
        public string AddSafetyTest([FromBody]InDoorAssemblyLine inDoorAssemblyLine)
        {
            if (inDoorAssemblyLine != null)
            {
                return IndoorAssemblyLineService.AddSafetyTest(inDoorAssemblyLine);
            }
            else
            {
                return "Data is empty";
            }
        }
        [Route("addInDoorSoundTest")]
        [HttpPost]
        public string AddSoundTest([FromBody]InDoorAssemblyLine inDoorAssemblyLine)
        {
            if (inDoorAssemblyLine != null)
            {
                return IndoorAssemblyLineService.AddSoundTest(inDoorAssemblyLine);
            }
            else
            {
                return "Data is empty";
            }
        }
        [Route("addInDoorFinalTest")]
        [HttpPost]
        public string AddFinalTest([FromBody]InDoorAssemblyLine inDoorAssemblyLine)
        {
            if (inDoorAssemblyLine != null)
            {
                return IndoorAssemblyLineService.AddFinalTest(inDoorAssemblyLine);
            }
            else
            {
                return "Data is empty";
            }
        }
        [Route("addInDoorRepairingStation1")]
        [HttpPost]
        public string AddRepairingStation1([FromBody]InDoorAssemblyLine inDoorAssemblyLine)
        {
            if (inDoorAssemblyLine != null)
            {
                return IndoorAssemblyLineService.AddRepairingStation1(inDoorAssemblyLine);
            }
            else
            {
                return "Data is empty";
            }
        }
        [Route("addInDoorRepairingStation2")]
        [HttpPost]
        public string AddRepairingStation2([FromBody]InDoorAssemblyLine inDoorAssemblyLine)
        {
            if (inDoorAssemblyLine != null)
            {
                return IndoorAssemblyLineService.AddRepairingStation2(inDoorAssemblyLine);
            }
            else
            {
                return "Data is empty";
            }
        }
        [Route("addInDoorLineExit")]
        [HttpPost]
        public string AddLineExit([FromBody] InDoorAssemblyLine inDoorAssemblyLine)
        {
            if (inDoorAssemblyLine != null)
            {
                return IndoorAssemblyLineService.AddLineExit(inDoorAssemblyLine);
            }
            else
            {
                return "Data is empty";
            }
        }
    }
}