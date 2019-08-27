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
    //   public VaultKeep CreateVaultKeep(VaultKeep vaultkeep)
    //   {
    //     int id = _db.ExecuteScalar<int>(@"
    // INSERT INTO vaultkeeps (userId, vaultId, keepId)
    // VALUES (@CreateId, @VaultIs, @KeepId);
    // SELECT LAST_INSERT_ID();
    //   ", VaultKeep);
    //     return VaultKeep;
    //   }
    // #endregion
  }
}