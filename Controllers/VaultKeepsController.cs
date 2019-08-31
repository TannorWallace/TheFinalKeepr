/*BRICK EQUALS KEEP */
/*Vault Equals Board */
/*kit Equals Vault */
using System;
using Keepr.Data;
using Keepr.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
    public ActionResult<VaultKeep> Create([FromBody]VaultKeep VaultKeep)
    // needs a keep id and a vault id
    {
      VaultKeep.UserId = HttpContext.User.FindFirstValue("Id");

      try
      {

        return Ok(_repository.CreateVaultKeep(VaultKeep));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // GET api/values
    [Authorize]
    [HttpGet("{VaultId}")]
    public ActionResult<IEnumerable<VaultKeep>> GetKeepsByVaultId(int VaultId)
    {
      var UserId = HttpContext.User.FindFirstValue("Id");
      return Ok(_repository.GetKeepsByVaultId(VaultId, UserId));
    }

    // // DELETE api/values/5
    // [HttpDelete("{id}")]
    // public void Delete(int id)
    // {
    // }
    //   }
  }
}

