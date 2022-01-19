using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadzenDh5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        [HttpGet]
        [Route("ipaddress")]
        public async Task<string> GetIpAddress()
        {
            var remoteIpAddress = this.HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
            if (remoteIpAddress != null)
                return remoteIpAddress.ToString();
            return string.Empty;
        }
    }
}
