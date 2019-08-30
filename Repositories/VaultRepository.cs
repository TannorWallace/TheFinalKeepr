/*BRICK EQUALS KEEP */
/*Vault Equals Board */
/*kit Equals Vault */

using System;
using Dapper;
using System.Data;
using Keepr.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Keepr.Data
{
  public class VaultsRepository
  {
    private readonly IDbConnection _db;

    public VaultsRepository(IDbConnection db)
    {
      _db = db;
    }
    // public IEnumerable<Vault> GetVaults()
    // {
    //   return _db.Query<Vault>("SELECT * FROM vaults");
    // }
    #region DELETE
    //delete doesnt return anything DUH!!! THats why it wasnt working with action result
    public bool DeleteVaultById(int id)
    {
      var complete = _db.Execute("DELETE FROM vaults WHERE id = @id", new { id });
      return complete > 0;
      {
        throw new Exception("Unable to comply");
      }
    }
    #endregion

    #region CREATE/POST
    public Vault CreateVault(Vault vault)
    {
      var id = _db.ExecuteScalar<int>(@"INSERT INTO vaults (userId, name, description) VALUES (@UserId,@Name, @Description); 
      SELECT LAST_INSERT_ID();", vault);
      vault.Id = id;
      return vault;
    }
    #endregion

    #region GETBYID
    // public Vault GetVaultsById(int id)
    // {
    //   return _db.QueryFirstOrDefault<Vault>("SELECT * FROM vaults WHERE id = @id", new { id });
    // }

    public IEnumerable<Vault> GetVaultsByUserId(string userId)
    {
      //UGH!!! PAY ATTENTION TO YOUR NAMES!! FROM VAULTS NOT FROM KEEPS!! THAT WAS 2 HOURS OF WASTED TIME BECAUSE YOU DONT PAY ATTENTION!!
      return _db.Query<Vault>("SELECT * FROM vaults WHERE userId = @userId", new { userId });
    }
    #endregion

  }
}