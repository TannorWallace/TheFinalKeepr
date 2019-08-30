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
//breaks alot of stuff. IDK where I got two keepr.models
// using keepr.Models;

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
    public Keep CreateKeep(Keep keeps)
    {
      int id = _db.ExecuteScalar<int>(@"INSERT INTO keeps (name, img, description, userId, isprivate) VALUES (@Name, @Img, @Description, @userId, @Isprivate);
  SELECT LAST_INSERT_ID();", keeps);
      keeps.Id = id;
      return keeps;
    }
    #endregion

    #region GETALLKEEPS
    public IEnumerable<Keep> GetKeeps()
    {
      return _db.Query<Keep>("SELECT * FROM keeps WHERE isPrivate = 0");
    }
    #endregion

    #region GETKEEPBYID

    public Keep GetKeepById(int id)
    {
      try
      {
        return _db.QuerySingle<Keep>("SELECT * FROM keeps WHERE id = @Id", new { id });
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }
    #endregion
    #region GETKEEPSBYUSERID
    public IEnumerable<Keep> GetKeepsByUserId(string userId)
    {
      return _db.Query<Keep>("SELECT * FROM keeps WHERE userId = @userId", new { userId });
    }
    #endregion

    #region DELETEKEEPBYID

    public bool DeleteKeepById(int id)
    {
      var complete = _db.Execute("DELETE FROM keeps WHERE id = @id", new { id });
      return complete > 0;
      {
        throw new Exception("Failed to delete");
      }
    }
    public IEnumerable<Keep> GetPublicKeeps()
    {
      // ohhhhhh!!!! That wasn't like swallowing a fist full of rusty nails...
      return _db.Query<Keep>("SELECT * FROM keeps WHERE isPrivate = 0");
    }

    #endregion
  }
}