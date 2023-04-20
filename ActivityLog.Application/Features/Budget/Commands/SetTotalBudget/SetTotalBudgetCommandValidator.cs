using FluentValidation;

namespace ActivityLog.Application.Features.Budget.Commands.SetTotalBudget
{
	public class SetTotalBudgetCommandValidator : AbstractValidator<SetTotalBudgetCommand>
	{
		public SetTotalBudgetCommandValidator()
		{
			RuleFor(p => p.Id)
				.NotEmpty().WithMessage("{Id} no puede estar vacio")
				.NotNull().WithMessage("{Id} no puede ser null");

			RuleFor(p => p.Amount)
				.NotEmpty().WithMessage("{Amount} El valor no puede ser nulo o vacío.")
				.NotNull().WithMessage("{Amount} no puede ser null");
				//.InclusiveBetween(0, 999999999999).WithMessage("{Amount} El valor debe estar entre 0 y 999,999,999,999")
				//.GreaterThan(0).WithMessage("{Amount} El valor debe ser mayor que cero.");
		}
	}
}
