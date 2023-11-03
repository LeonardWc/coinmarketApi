using Ardalis.Result;
using Ardalis.SharedKernel;

namespace lwc.coinmarket.api.UseCases.Contributors.Get;

public record GetContributorQuery(int ContributorId) : IQuery<Result<ContributorDTO>>;
