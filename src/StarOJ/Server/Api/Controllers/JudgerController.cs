using Judge0;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StarOJ.Models.Judging;
using StarOJ.Server.Models;
using StarOJ.Server.Models.Judging;
using System.Threading.Tasks;

namespace StarOJ.Server.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JudgerController : ControllerBase
    {
        public JudgerController(IOptions<Judge0Options> options, IJudge0Service judge0)
        {
            Options = options.Value;
            Judge0 = judge0;
        }

        public Judge0Options Options { get; }

        public IJudge0Service Judge0 { get; }

        [HttpPost]
        public async Task<ActionResult<string>> Create([FromBody] JudgingTask task)
        {
            await Judge0.Authenticate(Options);

            var result = await Judge0.SubmissionsService.Create(task.ToJudge0Submission());
            if (result.IsSuccessStatusCode)
            {
                return Ok(result.Result.token);
            }
            else
            {
                return BadRequest(result.Error);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<JudgingTask>> Get(string id)
        {
            await Judge0.Authenticate(Options);

            var result = await Judge0.SubmissionsService.Get(id, "stdout,time,memory,stderr,token,compile_output,message,status,language_id,stdin,source_code");
            if (result.IsSuccessStatusCode)
            {
                var res = result.Result.ToJudgingTask();
                return Ok(res);
            }
            else
            {
                return BadRequest(result.Error);
            }
        }
    }
}
