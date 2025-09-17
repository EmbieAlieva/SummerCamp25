using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiPaisesProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Distritos_LE_Controller : ControllerBase
    {
        // GET: api/<Distritos_LE_Controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<Distritos_LE_Controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Distritos_LE_Controller>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<Distritos_LE_Controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Distritos_LE_Controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
