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
    public ActionResult<IEnumerable<Keep>> Get()
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
    // [Authorize]
    // [HttpGet("{id}")]
    // public ActionResult<Keep> Get(int id)
    // {
    //   try
    //   {
    //     return Ok(_repository.GetKeepById(id));
    //   }
    //   catch (Exception e)
    //   {
    //     return BadRequest(e.Message);
    //   }
    // }

    [Authorize]
    [HttpGet("user")]

    public ActionResult<Keep> GetKeepsByUserId()
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
    public ActionResult<Keep> Post([FromBody] Keep keep)
    {
      try
      {
        keep.userId = HttpContext.User.FindFirstValue("Id");
        return Ok(_repository.CreateKeep(keep));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }

    // DELETE api/values/5
    [Authorize]
    [HttpDelete("{id}")]
    public ActionResult<Keep> DeleteKeepById(int id)
    {
      try
      {

        return Ok(_repository.DeleteKeepById(id));
        // return Ok("Keep Destoryed!");
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
    [Authorize]
    [HttpGet("{id}")]
    //CAPITAL KEEP NOT keep !! JEEZ MAN COME ON!!
    public ActionResult<IEnumerable<Keep>> GetPublicKeeps()
    {
      string userId = HttpContext.User.FindFirstValue("Id");
      try
      {
        return Ok(_repository.GetPublicKeeps());
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
    //I DONT WANNA DO EEEEEEDITSSSS!!! people said they are hard (sad face)

  }
}