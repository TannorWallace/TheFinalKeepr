/*BRICK EQUALS KEEP */
/*Vault Equals Board */
/*kit Equals Vault */
/*POSTMAN ON http://localhost:5000/api/vaults*/
using System;
using Keepr.Data;
using Keepr.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
// Stack over flow not very helpful
// using Microsoft.AspNetCore.Identity;


namespace Keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  // [Authorize]
  public class VaultsController : ControllerBase
  {
    private readonly VaultsRepository _repository;
    public VaultsController(VaultsRepository repository)
    {
      _repository = repository;
    }
    #region POST
    // POST api/vaults
    [HttpPost]
    public ActionResult<Vault> Post([FromBody] Vault vault)
    {
      try
      {
        vault.userId = HttpContext.User.FindFirstValue("Id");
        return Ok(_repository.CreateVault(vault));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    #endregion
    #region GET
    // GET api/values
    [HttpGet]
    //FIXME WHY ISNT GET WORKING?? VAULTS? VAULT? NAMING IS HARD!
    public ActionResult<IEnumerable<Vault>> Get()
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
    #endregion
    #region GETBYID
    // GET api/values/5
    [HttpGet("{id}")]
    public ActionResult<Vault> Get(int id)
    {
      try
      {

        return Ok(_repository.GetVaultsById(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    #endregion
    #region DELETE
    // DELETE api/values/5
    [HttpDelete("{id}")]
    public ActionResult<Vault> Delete(int id)
    {
      try
      {
        _repository.DeleteVaults(id);
        return Ok("Vault Destroyed");
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
    #endregion
  }
}