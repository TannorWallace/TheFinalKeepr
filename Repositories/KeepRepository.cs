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
    #region CREATE KEEPS
    public Keeps CreateKeeps(Keeps keeps)
    {
      int id = _db.ExecuteScalar<int>(@"INSERT INTO keeps (name, description) VALUES (@Name, @Description);
  SELECT LAST_INSERT_ID();", keeps);
      keeps.Id = id;
      return keeps;
    }
    #endregion

    #region GETALLKEEPS
    public IEnumerable<Keeps> GetKeeps()
    {
      return _db.Query<Keeps>("SELECT * FROM keeps");
    }
    #endregion

    #region GETKEEPBYID

    public Keeps GetKeepById(int id)
    {
      return _db.QueryFirstOrDefault<Keeps>("SELECT * FROM Keeps WHERE id = @id", new { id });
    }
    #endregion
    #region GETKEEPSBYUSERID
    public IEnumerable<Keeps> GetKeepsByUserId(string userId)
    {
      return _db.Query<Keeps>("SELECT * FROM keeps WHERE userId = @userId", new { userId });
    }
    #endregion
    #region DELETEKEEPBYID

    public void DeleteKeeps(int id)
    {
      var complete = _db.Execute("DELETE FROM keeps WHERE id = @id", new { id });
      if (complete != 1)
      {
        throw new Exception("Failed to delete");
      }
    }
    #endregion
  }
}