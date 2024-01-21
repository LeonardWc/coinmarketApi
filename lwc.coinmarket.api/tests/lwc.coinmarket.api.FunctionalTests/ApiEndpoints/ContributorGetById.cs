﻿using Ardalis.HttpClientTestExtensions;
using lwc.coinmarket.api.Web;
using lwc.coinmarket.api.Web.ContributorEndpoints;
using lwc.coinmarket.api.Web.Endpoints.ContributorEndpoints;
using Xunit;

namespace lwc.coinmarket.api.FunctionalTests.ApiEndpoints;

[Collection("Sequential")]
public class ContributorGetById : IClassFixture<CustomWebApplicationFactory<Program>>
{
  private readonly HttpClient _client;

  public ContributorGetById(CustomWebApplicationFactory<Program> factory)
  {
    _client = factory.CreateClient();
  }

  [Fact(Skip = "skip")]
  public async Task ReturnsSeedContributorGivenId1()
  {
    var result = await _client.GetAndDeserializeAsync<ContributorRecord>(GetContributorByIdRequest.BuildRoute(1));

    Assert.Equal(1, result.Id);
    Assert.Equal(SeedData.Contributor1.Name, result.Name);
  }

  [Fact(Skip = "skip")]
  public async Task ReturnsNotFoundGivenId1000()
  {
    string route = GetContributorByIdRequest.BuildRoute(1000);
    _ = await _client.GetAndEnsureNotFoundAsync(route);
  }
}
