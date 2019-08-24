/*BRICK EQUALS KEEP */
/*Vault Equals Board */
/*kit Equals Vault */

using System.Data;

namespace Keepr.Data
{
  public class VaultKeepRepository
  {
    private readonly IDbConnection _db;

    public VaultKeepRepository(IDbConnection db)
    {
      _db = db;
    }
  }
}