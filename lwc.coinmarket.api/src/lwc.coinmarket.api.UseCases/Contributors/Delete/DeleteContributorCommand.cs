using Ardalis.Result;
using Ardalis.SharedKernel;

namespace lwc.coinmarket.api.UseCases.Contributors.Delete;

public record DeleteContributorCommand(int ContributorId) : ICommand<Result>;
