/*BRICK EQUALS KEEP */
/*Vault Equals Board */
/*kit Equals Vault */
using System;
using Keepr.Data;
using Keepr.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  // [Authorize]
  public class KeepsController : ControllerBase

  {
    private readonly KeepRepository _repository;

    public KeepsController(KeepRepository repository)
    {
      _repository = repository;
    }

    #region ALL-GET-METHODS!!
    // GET api/values
    [HttpGet]
    public ActionResult<IEnumerable<Keeps>> Get()
    {
      try
      {
        //IDK why GetKeeps is red? hmmm....I guess I figured it out
        return Ok(_repository.GetKeeps());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // GET api/values/5
    [Authorize]
    [HttpGet("{id}")]
    public ActionResult<Keeps> Get(int id)
    {
      try
      {
        return Ok(_repository.GetKeepById(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [Authorize]
    [HttpGet("user")]

    public ActionResult<Keeps> GetKeepsByUserId()
    {
      try
      {

        string userId = HttpContext.User.FindFirstValue("Id");
        return Ok(_repository.GetKeepsByUserId(userId));

      }
      catch
      {
        return BadRequest("NOpe UserID or something is wrong");
      }

    }
    #endregion

    // POST api/values
    [HttpPost]
    public ActionResult<Keeps> Post([FromBody] Keeps keeps)
    {
      try
      {
        keeps.userId = HttpContext.User.FindFirstValue("Id");
        return Ok(_repository.CreateKeeps(keeps));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }

    // DELETE api/values/5
    [Authorize]
    [HttpDelete("{id}")]
    public ActionResult<Keeps> Delete(int id)
    {
      try
      {
        _repository.DeleteKeeps(id);
        return Ok("Keep Destoryed!");
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
  }
}