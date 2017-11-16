using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NLog.Web;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1
{
    [Route("api/[controller]")]
    public class MyController : Controller
    {
        private readonly ILogger<MyController> _logger;

        public MyController(ILogger<MyController> logger)
        {
            _logger = logger;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            _logger.LogInformation("Index page says hello");

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
