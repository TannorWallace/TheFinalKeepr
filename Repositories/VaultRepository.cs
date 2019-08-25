/*BRICK EQUALS KEEP */
/*Vault Equals Board */
/*kit Equals Vault */

using System.Data;
using System;
using System.Collections.Generic;
using Dapper;
using keepr.Models;

namespace Keepr.Data
{
  public class VaultRepository
  {
    private readonly IDbConnection _db;

    public VaultRepository(IDbConnection db)
    {
      _db = db;
    }
    public IEnumerable<Vaults> GetVaults()
    {
      return _db.Query<Vaults>("SELECT * FROM vaults");
    }
    public Vaults CreateVault(Vaults vaults)
    {
      var id = _db.ExecuteScalar<int>(@"INTSERT INTO vault (name, image, description) VALUES (@Name, @Image, @Description);SELECT LAST_INSERTED_ID();", vaults);
      vaults.Id = id;
      return vaults;
    }
    public Vaults GetVaultsById(int id)
    {
      return _db.QueryFirstOrDefault<Vaults>("SELECT * FROM vaults WHERE id = @id", new { id });
    }
    //delete doesnt return anything DUH!!! THats why it wasnt working with action result
    public void DeleteVaults(int id)
    {
      var complete = _db.Execute("DELETE FROM vaults WHERE id = @id", new { id });
      if (complete != 1)
      {
        throw new Exception("Un able to comply");
      }
    }
  }
}