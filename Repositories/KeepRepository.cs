/*BRICK EQUALS KEEP */
/*Vault Equals Board */
/*kit Equals Vault */
using System.Data;
namespace Keepr.Data
{
  public class KeepRepository
  {
    private readonly IDbConnection _db;

    public KeepRepository(IDbConnection db)
    {
      _db = db;
    }
  }
}