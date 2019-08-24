namespace keepr.Models
{
  public class VaultKeep
  {
    public int VaultId { get; set; }
    public string KeepId { get; set; }
    public string Description { get; set; }
  }

  public class VaultVault : VaultKeep
  {
    public string VaultName { get; set; }
    public string KeepName { get; set; }
    //NOTE V_Description is AKA Vault Description cant have to descriptions on this page so you had to alias it (thumnbs up You're doin good!)
    public string V_Description { get; set; }
  }
}