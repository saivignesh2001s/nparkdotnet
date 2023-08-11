using Microsoft.AspNetCore.Mvc;
using Nationalparks.Model;
using Nationalparks.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Nationalparks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NParkController : ControllerBase
    {
        private readonly INationalparkmethods inpmethods;
        public NParkController(INationalparkmethods _inpmethods)
        {
            inpmethods = _inpmethods;
        }
        // GET: api/<NParkController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<nationalpark> p = inpmethods.GetAllNationalparks();
            return Ok(p);
        }

        // GET api/<NParkController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
       {
            nationalpark p = inpmethods.GetNationalpark(id);
            return Ok(p);

        }

        // POST api/<NParkController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] nationalpark nationalpark)
        {
            nationalpark p = inpmethods.addnationalpark(nationalpark);
            return Ok(p);

        }

        // PUT api/<NParkController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]nationalpark nationalpark)
        {


            nationalpark p = inpmethods.updatenationalpark(id,nationalpark);
            return Ok(p);
    }
    

        // DELETE api/<NParkController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            int k=inpmethods.removenationalpark(id);
            return Ok(k);

        }
    }
}
