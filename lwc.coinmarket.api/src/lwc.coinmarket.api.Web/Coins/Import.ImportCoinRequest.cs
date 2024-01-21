using System.ComponentModel.DataAnnotations;

namespace lwc.coinmarket.api.Web.Coins;

public class ImportCoinRequest
{
  public const string Route = "/Coins";

  [Required]
  public int Limit { get; set; }
}
