/*BRICK EQUALS KEEP */
//Keep equals pin
/*Vault Equals Board */
/*kit Equals Vault */
//WANT TO GET ALL THE KEEPS BECAUSE THAT IS WHAT EVERYONE IS LOOKING AT
// ALL VAULTS WILL BE DONE BY USER ID BECUAE THAT IS EVERYONES OWN VAULT
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
    // public IEnumerable<Keeps> CreateKeeps(Keeps keeps)
    // {
    //   //image or img? 
    //   int id = _db.ExecuteScalar<int>(@"
    //   INSERT INTO keeps (name, description)
    //   VALUES (@Name, @Description);
    //   SELECT LAST_INSERT_ID();", keeps);
    //   keeps.Id = id;
    //   yield return keeps;
    // }

    public Keeps CreateKeeps(Keeps keeps)
    {
      int id = _db.ExecuteScalar<int>(@"INSERT INTO keeps (name, description) VALUES (@Name, @Description);
  SELECT LAST_INSERT_ID();", keeps);
      keeps.Id = id;
      return keeps;
    }

    public IEnumerable<Keeps> GetKeeps()
    {
      return _db.Query<Keeps>("SELECT * FROM keeps");
    }

    public Keeps GetKeepById(int id)
    {
      return _db.QueryFirstOrDefault<Keeps>("SELECT * FROM keeps WHERE id = @id", new { id });
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
}


