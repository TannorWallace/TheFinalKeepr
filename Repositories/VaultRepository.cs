/*BRICK EQUALS KEEP */
/*Vault Equals Board */
/*kit Equals Vault */

using System.Data;
using System;
using System.Collections.Generic;
using Dapper;
namespace Keepr.Data
{
  public class VaultRepository
  {
    private readonly IDbConnection _db;

    public VaultRepository(IDbConnection db)
    {
      _db = db;
    }

    public Vault GetVault(int VaultId)
    {
      try
      {
        return _db.QueryFirst<Vault>("SELECT * FROM vaults WHERE id =@vaultId", new { VaultId });
      }
      catch (Exception)
      {

        throw new Exception("Vault not found at id" + VaultId);
      }
    }
  }
}