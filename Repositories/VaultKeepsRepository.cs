/*BRICK EQUALS KEEP */
/*Vault Equals Board */
/*kit Equals Vault */

// using System;
using Dapper;
using System.Data;
using Keepr.Models;
// using Keepr.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
// using Microsoft.AspNetCore.Authorization;

namespace Keepr.Data
{
  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;

    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<VaultKeep> GetEmAll()
    {
      return _db.Query<VaultKeep>("SELECT * FROM vaultkeeps;");
    }


    [HttpPost]
    public VaultKeep CreateVaultKeep(VaultKeep VaultKeep)
    {
      int id = _db.ExecuteScalar<int>(@"
    INSERT INTO vaultkeeps (userId, vaultId, keepId)
    VALUES (@UserId, @VaultId, @KeepId);
    SELECT LAST_INSERT_ID();
      ", VaultKeep);
      VaultKeep.Id = id;
      return VaultKeep;
    }
    #region Had to rewrite this one...
    // IDFK....WHY doesnt this like the repo!?
    //     [Authorize]
    //     [HttpGet("{VaultId}")]
    //     public IEnumerable<VaultKeep> GetByVaultId(int VaultId, string UserId)
    //     {
    //       string query = @"
    //        SELECT * FROM vaultkeeps vk
    // -- -- -- INNER JOIN keeps k ON k.id = vk.KeepId 
    // -- -- -- WHERE (VaultId = @VaultId AND vk.UserId = @UserId)
    //       ";
    //       return _db.Query<Keep>(query, new { VaultId, UserId });
    //     }
    #endregion

    public IEnumerable<Keep> GetKeepsByVaultId(int VaultId, string UserId)
    {
      string query = @"
      SELECT * FROM vaultkeeps vk
      INNER JOIN keeps k ON k.id = vk.KeepId
      WHERE(VaultId = @VaultId AND vk.UserId = @UserId)
      ";
      return _db.Query<Keep>(query, new { VaultId, UserId });
    }
  }
}