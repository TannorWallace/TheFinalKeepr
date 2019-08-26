/*BRICK EQUALS KEEP */
/*Vault Equals Board */
/*kit Equals Vault */
/*POSTMAN ON http://localhost:5000/api/vaults*/
using System;
using Keepr.Data;
using keepr.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
// using keepr.Models;

namespace Keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
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
    public ActionResult<Vaults> Post([FromBody] Vaults vaults)
    {
      try
      {
        return Ok(_repository.CreateVault(vaults));
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
    #endregion
    #region GETBYID
    // GET api/values/5
    [HttpGet("{id}")]
    public ActionResult<Vaults> Get(int id)
    {
      try
      {
        return Ok(_repository.GetVaultsById(id));
      }
      catch (Exception e)
      {
        return BadRequest("This is not the vault youre looking for.");
      }
    }
    #endregion
    #region DELETE
    // DELETE api/values/5
    [HttpDelete("{id}")]
    public ActionResult<Vaults> Delete(int id)
    {
      try
      {
        _repository.DeleteVaults(id);
        return Ok("Vault Destroyed");
      }
      catch (Exception e)
      {

        return BadRequest("Cannot Delete Vault!");
      }
    }
    #endregion
  }
}