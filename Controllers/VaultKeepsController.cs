/*BRICK EQUALS KEEP */
/*Vault Equals Board */
/*kit Equals Vault */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Keepr.Data;

using keepr.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepsRepository _repository;
    public VaultKeepsController(VaultKeepsRepository repository)
    {
      _repository = repository;
    }
    // POST api/values
    [Authorize]
    [HttpPost]
    public ActionResult<VaultKeep> Create([FromBody]VaultKeep newVaultKeep)
    {
      newVaultKeep.UserId = HttpContext.User.FindFirstValue("Id");

      try
      {

        return Ok(_repository.CreateVaultKeep(newVaultKeep));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}

// GET api/values
// [HttpGet]
// public ActionResult<VaultKeep> GetVault(int id)
// {
//   return _repository.GetVaultKeepByVaultId(id);
// }

// // GET api/values/5
// [HttpGet("{id}")]
// public ActionResult<string> Get(int id)
// {
//   return "value";
// }


// // DELETE api/values/5
// [HttpDelete("{id}")]
// public void Delete(int id)
// {
// }
//   }
