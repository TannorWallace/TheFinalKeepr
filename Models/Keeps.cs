using System.Collections.Generic;
using keepr.Models;

namespace Keepr.Models
{
  public class Keeps
  {
    public int Id { get; set; }
    public string Img { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    //NOTE DO I NEED TO KEEP A LIST OF MY KEEPS (AKA PINS)?
    public List<VaultKeep> KeeprList { get; set; }
  }

}