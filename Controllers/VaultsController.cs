/*BRICK EQUALS KEEP */
/*Vault Equals Board */
/*kit Equals Vault */

using System;
using Dapper;
using Keepr.Data;
using System.Linq;

using Keepr.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class VaultsController : ControllerBase
  {
    private readonly VaultRepository _repository;
    public VaultsController(VaultRepository repository)
    {
      _repository = repository;
    }
    // GET api/values
    [HttpGet]
    //FIXME WHY ISNT GET WORKING?? VAULTS? VAULT? NAMING IS HARD!
    public ActionResult<IEnumerable<Vaults>> Get()
    {
      try
      {
        return Ok(_repository.GetVaults());
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
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