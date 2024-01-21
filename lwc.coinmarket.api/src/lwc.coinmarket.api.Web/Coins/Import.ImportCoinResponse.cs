namespace lwc.coinmarket.api.Web.Coins;
public class ImportCoinResponse
{
  public ImportCoinResponse(bool success)
  {
    Success = success;
  }

  public bool Success { get; set; }
}
