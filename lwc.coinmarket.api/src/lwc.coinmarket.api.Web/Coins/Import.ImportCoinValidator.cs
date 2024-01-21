using FastEndpoints;
using FluentValidation;

namespace lwc.coinmarket.api.Web.Coins;

public class ImportCoinValidator : Validator<ImportCoinRequest>
{
  public ImportCoinValidator()
  {
    RuleFor(x => x.Limit)
      .NotEmpty()
      .GreaterThan(0)
      .WithMessage("Limit is required and greater than 0");
  }
}
