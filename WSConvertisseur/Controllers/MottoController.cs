using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WSConvertisseur.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WSConvertisseur.Controllers
{
    /// <summary>
    /// TODO
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MottoController : ControllerBase
    {
        private List<Motto> _mottos;

        /// <summary>
        /// Get a all mottos.
        /// </summary>
        /// <returns>Http response</returns>
        /// <response code="200"></response>

        // GET: api/<MottoControlleur>
        [ProducesResponseType(typeof(Motto), 200)]
        [HttpGet]
        public IEnumerable<Motto> GetAll()
        {
            return this._mottos;
        }

        /// <summary>
        /// Get a single motto.
        /// </summary>
        /// <returns>Http response</returns>
        /// <param name="id">The id of the motto</param>
        /// <response code="200">When the motto id is found</response>
        /// <response code="404">When the motto id is not found</response>

        // GET api/<MottoControlleur>/5
        [ProducesResponseType(typeof(Motto), 200)]
        [HttpGet("{id}", Name = "GetMotto")]
        public IActionResult GetById([FromRoute] int id)
        {
            Motto motto = _mottos.FirstOrDefault((m) => m.Id == id);
            if (motto == null) { return NotFound(); }
            return Ok(motto);
        }


        /// <summary>
        /// Create a motto.
        /// </summary>
        /// <returns>Http response</returns>
        /// <param name="motto">The motto</param>
        /// <response code="200">When the motto is created</response>
        /// <response code="400">When the motto isn't validated</response>
        // POST api/<MottoControlleur>
        [ProducesResponseType(typeof(Motto), 200)]
        [HttpPost]
        public ActionResult Post([FromBody] Motto motto)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            _mottos.Add(motto);
            return CreatedAtRoute("GetMotto", new { id = motto.Id }, motto);
        }

        /// <summary>
        ///   TODO
        /// </summary>
        // PUT api/<MottoControlleur>/5
        [ProducesResponseType(typeof(Motto), 200)]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Motto motto)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            if (id != motto.Id) { return BadRequest(); }
            int index = _mottos.FindIndex((d) => d.Id == id); if (index < 0) { return NotFound(); }
            _mottos[index] = motto;
            return Ok(motto);
        }

        /// <summary>
        /// TODO
        /// </summary>
        // DELETE api/<MottoControlleur>/5
        [ProducesResponseType(typeof(Motto), 200)]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Motto motto = _mottos.FirstOrDefault((m) => m.Id == id);
            if (motto == null) { return NotFound(); }
            _mottos.Remove(motto);
            return Ok(_mottos);
        }

        /// <summary>
        /// TODO
        /// </summary>
        public MottoController()
        {
            _mottos = new List<Motto>();
            _mottos.Add(new Motto(1, "Dollar", 1.08));
            _mottos.Add(new Motto(2, "Franc Suisse", 1.07));
            _mottos.Add(new Motto(3, "Yen", 120));
        }
    }
}
