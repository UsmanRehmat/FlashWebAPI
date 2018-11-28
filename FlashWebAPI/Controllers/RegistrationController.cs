using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FlashWebAPI.Models;
using FlashWebAPI.Services;

namespace FlashWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class RegistrationController : Controller
    {
        [Route("login")]
        [HttpPost]
        public User Login([FromBody] User userInfo)
        {
            return RegisrationService.login(userInfo);
            
        }
        [HttpPost]
        [Route("register")]
        public string register([FromBody] User userInfo)
        {
            return RegisrationService.register(userInfo);
        }
        [HttpPost]
        [Route("update")]
        public bool update([FromBody] User userInfo)
        {
            return RegisrationService.update(userInfo);
        }
        [HttpPost]
        [Route("delete")]
        public bool delete([FromBody] User userInfo)
        {
            return RegisrationService.delete(userInfo);
        }
        [Route("isManager")]
        public bool IsManager([FromQueryAttribute] string userName)
        {
            //TODO
            return true;
        }
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        [HttpGet]
        [Route("GetAll")]
        public List<User> GetAll()
        {
            return RegisrationService.GetAll();
        }
    }
}