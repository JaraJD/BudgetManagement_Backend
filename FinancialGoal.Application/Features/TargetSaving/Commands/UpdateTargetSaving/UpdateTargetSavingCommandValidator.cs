using FluentValidation;

namespace FinancialGoal.Application.Features.TargetSaving.Commands.UpdateTargetSaving
{
	public class UpdateTargetSavingCommandValidator : AbstractValidator<UpdateTargetSavingCommand>
	{
		public UpdateTargetSavingCommandValidator()
		{
			RuleFor(p => p.Id)
				.NotEmpty().WithMessage("{Id} no puede estar vacio")
				.NotNull().WithMessage("{Id} no puede ser null");

			RuleFor(p => p.StartDate)
				.NotEmpty().WithMessage("{StartDate} no puede estar vacio")
				.NotNull().WithMessage("{StartDate} no puede ser null");

			RuleFor(p => p.EndDate)
				.NotEmpty().WithMessage("{EndDate} no puede estar vacio")
				.NotNull().WithMessage("{EndDate} no puede ser null");

			RuleFor(p => p.TargetAmount)
				.NotEmpty().WithMessage("{TargetAmount} no puede estar vacio")
				.NotNull().WithMessage("{TargetAmount} no puede ser null");
		}
	}
}
