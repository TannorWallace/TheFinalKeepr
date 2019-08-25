/*BRICK EQUALS KEEP */
//Keep equals pin
/*Vault Equals Board */
/*kit Equals Vault */
using System;
using Dapper;
using System.Data;
using Keepr.Models;
using System.Collections.Generic;

namespace Keepr.Data
{
  public class KeepRepository
  {
    private readonly IDbConnection _db;

    public KeepRepository(IDbConnection db)
    {
      _db = db;
    }
    //Do the CRUD...just minus the U....Edits are a stretch goal.
    public IEnumerable<Keeps> CreateKeeps(Keeps keeps)
    {
      //image or img? 
      var id = _db.ExecuteScalar<int>(@"
      INSERT INTO keeps (name, image, description)
      VALUES (@Name, @Image, @Description);
      SELECT LAST_INSERT_ID();", keeps);
      keeps.Id = id;
      /* return keeps; 
      why isnt just return keeps working but yield return keep is?*/
      yield return keeps;

    }
    public IEnumerable<Keeps> GetKeeps()
    {
      return _db.Query<Keeps>("SELECT * FROM keeps");
    }



    public void DeleteKeeps(int id)
    {
      var success = _db.Execute("DELETE FROM keeps WHERE id = @id", new { id });
      if (success != 1)
      {
        throw new Exception("Failed to delete");
      }
    }
  }
