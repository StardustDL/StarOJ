using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StarOJ.Client.Models;
using StarOJ.Models;

namespace StarOJ.Server.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemController : ControllerBase
    {
        public SystemController(IOptions<OJOptions> ojOptions, IOptions<BuildStatus> buildStatus)
        {
            OJOptions = ojOptions.Value;
            BuildStatus = buildStatus.Value;
        }

        public OJOptions OJOptions { get; }

        public BuildStatus BuildStatus { get; }

        [HttpGet("Options")]
        public OJOptions OJ() => OJOptions;

        [HttpGet("Build")]
        public BuildStatus Build() => BuildStatus;
    }
}
