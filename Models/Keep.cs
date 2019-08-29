using System.Collections.Generic;

namespace Keepr.Models
{
  public class Keep
  {
    public int Id { get; set; }
    public string userId { get; set; }
    public string Img { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool isPrivate { get; set; }
    public int Shares { get; set; }
    public int Views { get; set; }
    public int Keeps { get; set; }
    //NOTE DO I NEED TO KEEP A LIST OF MY KEEPS (AKA PINS)?
    // public List<VaultKeep> KeeprList { get; set; }
  }

}