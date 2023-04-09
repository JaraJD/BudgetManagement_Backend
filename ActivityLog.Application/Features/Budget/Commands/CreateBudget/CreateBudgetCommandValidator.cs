using FluentValidation;

namespace ActivityLog.Application.Features.Budget.Commands.CreateBudget
{
	public class CreateBudgetCommandValidator : AbstractValidator<CreateBudgetCommand>
	{

		public CreateBudgetCommandValidator()
		{
			RuleFor(p => p.IdUser)
				.NotEmpty().WithMessage("{IdUser} no puede estar vacio")
				.NotNull().WithMessage("{IdUser} no puede ser null");

			RuleFor(p => p.Name)
					.NotEmpty().WithMessage("{Name} no puede estar vacio")
					.NotNull().WithMessage("{Name} no puede ser null");

			RuleFor(p => p.TargetMonth)
					.NotEmpty().WithMessage("{TargetMonth} no puede estar vacio")
					.NotNull().WithMessage("{TargetMonth} no puede ser null");

			RuleFor(p => p.Balance)
					.NotEmpty().WithMessage("{Balance} El valor no puede ser nulo o vacío.")
					.NotNull().WithMessage("{Balance} no puede ser null")
					.InclusiveBetween(0, 999999999999).WithMessage("{Balance} El valor debe estar entre 0 y 999,999,999,999")
					.GreaterThan(0).WithMessage("{Balance} El valor debe ser mayor que cero.");

			RuleFor(p => p.State)
					.NotEmpty().WithMessage("{State} no puede estar vacio")
					.NotNull().WithMessage("{State} no puede ser null");
		}
		
	}
}
