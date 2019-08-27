/*BRICK EQUALS KEEP */
/*Vault Equals Board */
/*kit Equals Vault */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Keepr.Data;
using Keepr.Models;
using keepr.Models;
using System.Security.Claims;

namespace Keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class VaultKeepController : ControllerBase
  {
    // POST api/values
    [HttpPost]
    public ActionResult<VaultKeep> Post([FromBody] VaultKeep vaultkeep)
    {
      var id = HttpContext.User.FindFirstValue("Id");
      return Ok(_repository.CreateVaultKeep(VaultKeep))
    }

    // GET api/values
    [HttpGet]
    public ActionResult<IEnumerable<string>> Get()
    {
      return new string[] { "value1", "value2" };
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public ActionResult<string> Get(int id)
    {
      return "value";
    }


    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}