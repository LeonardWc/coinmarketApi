using Ardalis.Result;
using Ardalis.SharedKernel;

namespace lwc.coinmarket.api.UseCases.Contributors.Update;

public record UpdateContributorCommand(int ContributorId, string NewName) : ICommand<Result<ContributorDTO>>;
