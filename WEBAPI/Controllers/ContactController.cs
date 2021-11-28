using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBAPI.Models;

namespace WEBAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : Controller
    {
        [HttpGet]
        [Authorize(Roles ="Admin")]
        public List<ContactModel> Get()
        {
            return new List<ContactModel> { 
            
            new ContactModel{ Id =1 , FirstName = "TUFAN", LastName = "CEVIK"}
            
            }; 
        
        
        }
    }
}
