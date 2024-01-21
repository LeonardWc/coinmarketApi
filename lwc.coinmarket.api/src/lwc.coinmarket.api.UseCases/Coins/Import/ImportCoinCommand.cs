using Ardalis.Result;

namespace lwc.coinmarket.api.UseCases.Coins.Import;
public record ImportCoinCommand(int numbefOfCoins) : Ardalis.SharedKernel.ICommand<Result<bool>>;
