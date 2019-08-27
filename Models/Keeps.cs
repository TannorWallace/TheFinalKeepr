using System.Collections.Generic;
using keepr.Models;

namespace Keepr.Models
{
  public class Keeps
  {
    public int Id { get; set; }
    public string userId { get; set; }
    //idk if this is what get keep by keepID means but I'll try should this be a string instead of an int?
    // public int keepId { get; set; }
    public string Img { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    //NOTE DO I NEED TO KEEP A LIST OF MY KEEPS (AKA PINS)?
    // public List<VaultKeep> KeeprList { get; set; }
  }

}