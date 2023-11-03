using lwc.coinmarket.api.Web.ContributorEndpoints;

namespace lwc.coinmarket.api.Web.Endpoints.ContributorEndpoints;

public class ContributorListResponse
{
  public List<ContributorRecord> Contributors { get; set; } = new();
}
