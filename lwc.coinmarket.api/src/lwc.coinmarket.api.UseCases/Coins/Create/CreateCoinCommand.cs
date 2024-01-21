using Ardalis.Result;
using lwc.coinmarket.api.Core.Models;

namespace lwc.coinmarket.api.UseCases.Coins.Create;
public record CreateCoinCommand(CoinDto coin) : Ardalis.SharedKernel.ICommand<Result<int>>;
