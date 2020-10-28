namespace Keepr.Models
{
  public class Keep
  {
    public int Id { get; set; }
    public string CreatorId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Img { get; set; }
    public int Shares { get; set; } = 0;
    public int Views { get; set; } = 0;
    public int Keeps { get; set; } = 0;
    public Profile Creator { get; set; }
  }
  //getting all keeps by vault id
  public class VaultKeepViewModel : Keep
  {
    public int VaultKeepId { get; set; }
  }

}