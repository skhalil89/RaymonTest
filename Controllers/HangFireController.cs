using Hangfire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaymonApiTaskTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class HangFireController : ControllerBase
    {



        [HttpPost]
        [Route("invoice")]
        public IActionResult Invoice(string userName)
        {
            RecurringJob.AddOrUpdate(() => Console.WriteLine($"Here is your invoice, {userName}"), Cron.Minutely);
            return Ok($"Recurring Job Scheduled. Invoice will be mailed Minutely for {userName}!");
        }


    }
}
