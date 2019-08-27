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
using Microsoft.AspNetCore.Authorization;

namespace Keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class VaultKeepController : ControllerBase
  {
    private readonly VaultKeepRepository _repository;
    public VaultKeepController(VaultKeepRepository repository)
    {
      _repository = repository;
    }
    // POST api/values
    [Authorize]
    [HttpPost]
    public ActionResult<VaultKeep> Post([FromBody] VaultKeep newVaultKeep)
    {
      newVaultKeep.userId = HttpContext.User.FindFirstValue("Id");
      return Ok(_repository.CreateVaultKeep(newVaultKeep));
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