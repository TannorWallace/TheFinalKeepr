/*BRICK EQUALS KEEP */
/*Vault Equals Board */
/*kit Equals Vault */

using System.Data;
using keepr.Models;
using Dapper;
using System.Collections.Generic;
namespace Keepr.Data
{
  public class VaultKeepRepository
  {
    private readonly IDbConnection _db;

    public VaultKeepRepository(IDbConnection db)
    {
      _db = db;
    }
    //   #region CREATEVAULT_KEEP
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
    // #endregion
  }
}