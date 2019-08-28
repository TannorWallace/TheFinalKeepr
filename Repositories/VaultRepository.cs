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
    public IEnumerable<Vault> GetVaults()
    {
      return _db.Query<Vault>("SELECT * FROM vaults");
    }
    #region DELETE
    //delete doesnt return anything DUH!!! THats why it wasnt working with action result
    public void DeleteVaults(int id)
    {
      var complete = _db.Execute("DELETE FROM vaults WHERE id = @id", new { id });
      if (complete != 1)
      {
        throw new Exception("Unable to comply");
      }
    }
    #endregion

    #region CREATE/POST
    public Vault CreateVault(Vault vault)
    {
      var id = _db.ExecuteScalar<int>(@"INSERT INTO vaults (name, description) VALUES (@Name, @Description); 
      SELECT LAST_INSERT_ID();", vault);
      vault.Id = id;
      return vault;
    }
    #endregion

    #region GETBYID
    public Vault GetVaultsById(int id)
    {
      return _db.QueryFirstOrDefault<Vault>("SELECT * FROM vaults WHERE id = @id", new { id });
    }
    #endregion

  }
}