/*BRICK EQUALS KEEP */
/*Vault Equals Board */
/*kit Equals Vault */

using System;
using System.Linq;
using Keepr.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Keepr.Models;

namespace Keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class KeepsController : ControllerBase
  {
    // GET api/values
    [HttpGet]
    public ActionResult<IEnumerable<Keeps>> Get()
    {
      try
      {
        return Ok(_repository.GetKeeps());
      }
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public ActionResult<string> Get(int id)
    {
      return "value";
    }

    // POST api/values
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // // PUT api/values/5
    // [HttpPut("{id}")]
    // public void Put(int id, [FromBody] string value)
    // {
    // }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}