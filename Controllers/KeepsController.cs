/*BRICK EQUALS KEEP */
/*Vault Equals Board */
/*kit Equals Vault */
using System;
using Keepr.Data;
using Keepr.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace Keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class KeepsController : ControllerBase

  {
    private readonly KeepRepository _repository;

    public KeepsController(KeepRepository repository)
    {
      _repository = repository;
    }
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

    // POST api/values
    [HttpPost]
    public ActionResult<Keeps> Post([FromBody] Keeps keeps)
    {
      try
      {
        return Ok(_repository.CreateKeeps(keeps));
      }
      catch (Exception e)
      {

        return BadRequest("Cannot create keep data");
      }
    }

    // // PUT api/values/5
    // [HttpPut("{id}")]
    // public void Put(int id, [FromBody] string value)
    // {
    // }

    // DELETE api/values/5
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

        return BadRequest("Unable to destroy Keep");
      }
    }
  }
}