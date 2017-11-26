using System.Threading.Tasks;
using AppServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IValuesHandler valuesHandler;

        public ValuesController(IValuesHandler valuesHandler)
        {
            this.valuesHandler = valuesHandler;
        }

        // GET api/values
        [HttpGet]
        public Task<string> Get([FromQuery] string x) => valuesHandler.Get(x);

        [HttpGet("m2")]
        public Task<string> M2([FromQuery] string x) => valuesHandler.M2(x);

        // GET api/values/5
        [HttpGet("{id}")]
        public string GetById(int id)
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
