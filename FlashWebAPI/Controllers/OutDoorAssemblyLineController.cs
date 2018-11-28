using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FlashWebAPI.Models;
using FlashWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FlashWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/OutDoorAssemblyLine")]
    public class OutDoorAssemblyLineController : Controller
    {
        [Route("GetAll")]
        [HttpGet]
        public List<OutDoorAssemblyLine> GetAll()
        {
            return OutDoorAssemblyLineService.GetAll();
        }
        [Route("addOutDoorStartLine")]
        [HttpPost]
        public string AddOutDoorAssemblyLine([FromBody] OutDoorAssemblyLine outDoorAssemblyLine)
        {
            return OutDoorAssemblyLineService.AddOutDoorAssemblyLine(outDoorAssemblyLine);
        }
        [Route("addOutDoorMotorQRCode")]
        [HttpPost]

        public string AddMotorQrCode([FromBody] OutDoorAssemblyLine outDoorAssemblyLine)
        {
            return OutDoorAssemblyLineService.AddMotorQrCode(outDoorAssemblyLine);
        }
        [Route("addOutDoorPCBQRCode")]
        [HttpPost]
        public string AddPCBQrCode([FromBody] OutDoorAssemblyLine outDoorAssemblyLine)
        {
            return OutDoorAssemblyLineService.AddPCBQrCode(outDoorAssemblyLine);
        }
        [Route("addOutDoorBarCode")]
        [HttpPost]
        public string AddBarCode([FromBody] OutDoorAssemblyLine outDoorAssemblyLine)
        {
            return OutDoorAssemblyLineService.AddBarCode(outDoorAssemblyLine);
        }
        [Route("addOutDoorGasChargingStation")]
        [HttpPost]
        public string AddGasChargingStation([FromBody] OutDoorAssemblyLine outDoorAssemblyLine)
        {

            //var obj = JsonConvert.DeserializeObject<OutDoorAssemblyLine>(outDoorAssemblyLine);
            return OutDoorAssemblyLineService.AddGasChargingStation(outDoorAssemblyLine);
            
        }
        [Route("addOutDoorLeakage1Station")]
        [HttpPost]
        public string AddLeakage1Station([FromBody] OutDoorAssemblyLine outDoorAssemblyLine)
        {
            return OutDoorAssemblyLineService.AddLeakage1Station(outDoorAssemblyLine);
        }
        [Route("addOutDoorLeakage2Station")]
        [HttpPost]
        public string AddLeakage2Station([FromBody] OutDoorAssemblyLine outDoorAssemblyLine)
        {
            return OutDoorAssemblyLineService.AddLeakage2Station(outDoorAssemblyLine);
        }
        [Route("addOutDoorSafetyTest")]
        [HttpPost]
        public string AddSafetyTest([FromBody] OutDoorAssemblyLine outDoorAssemblyLine)
        {
            return OutDoorAssemblyLineService.AddSafetyTest(outDoorAssemblyLine);
        }
        [Route("addOutDoorHeatingTest")]
        [HttpPost]
        public string AddHeatingTest([FromBody] OutDoorAssemblyLine outDoorAssemblyLine)
        {
            return OutDoorAssemblyLineService.AddHeatingTest(outDoorAssemblyLine);
        }
        [Route("addOutDoorPerformanceTest")]
        [HttpPost]
        public string AddPerformanceTest([FromBody] OutDoorAssemblyLine  outDoorAssemblyLine)
        {
            //OutDoorAssemblyLine outdoor = JsonConvert.DeserializeObject<OutDoorAssemblyLine>(outDoorAssemblyLine);
            return OutDoorAssemblyLineService.AddPerformanceTest(outDoorAssemblyLine);
        }
        [Route("addOutDoorLeakage3Test")]
        [HttpPost]
        public string AddLeakage3Test([FromBody] OutDoorAssemblyLine outDoorAssemblyLine)
        {
            return OutDoorAssemblyLineService.AddLeakage3Station(outDoorAssemblyLine);
        }
        [Route("addOutDoorFinalTest")]
        [HttpPost]
        public string AddFinalTest([FromBody] OutDoorAssemblyLine outDoorAssemblyLine)
        {
            return OutDoorAssemblyLineService.AddFinalTest(outDoorAssemblyLine);
        }
        [Route("addOutDoorRepairingStation1")]
        [HttpPost]
        public string AddRepairingStation1([FromBody] OutDoorAssemblyLine outDoorAssemblyLine)
        {
            return OutDoorAssemblyLineService.AddRepairingStation1(outDoorAssemblyLine);
        }
        [Route("addOutDoorRepairingStation2")]
        [HttpPost]
        public string AddRepairingStation2([FromBody] OutDoorAssemblyLine outDoorAssemblyLine)
        {
            return OutDoorAssemblyLineService.AddRepairingStation2(outDoorAssemblyLine);
        }

    }
}