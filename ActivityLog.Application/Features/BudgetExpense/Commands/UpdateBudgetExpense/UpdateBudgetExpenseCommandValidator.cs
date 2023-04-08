using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityLog.Application.Features.BudgetExpense.Commands.UpdateBudgetExpense
{
	public class UpdateBudgetExpenseCommandValidator : AbstractValidator<UpdateBudgetExpenseCommand>
	{
		public UpdateBudgetExpenseCommandValidator()
		{
			RuleFor(p => p.Id)
				.NotEmpty().WithMessage("{Id} no puede estar vacio")
				.NotNull().WithMessage("{Id} no puede ser null")
				.GreaterThan(0).WithMessage("{Id} El valor debe ser mayor que cero.");

			RuleFor(p => p.CategoryId)
				.NotEmpty().WithMessage("{CategoryId} no puede estar vacio")
				.NotNull().WithMessage("{CategoryId} no puede ser null")
				.GreaterThan(0).WithMessage("{CategoryId} El valor debe ser mayor que cero.");

			RuleFor(p => p.Amount)
				.NotEmpty().WithMessage("{Amount} El valor no puede ser nulo o vacío.")
				.NotNull().WithMessage("{Amount} no puede ser null")
				.InclusiveBetween(0, 999999999999).WithMessage("{Amount} El valor debe estar entre 0 y 999,999,999,999")
				.GreaterThan(0).WithMessage("{Amount} El valor debe ser mayor que cero.");

			RuleFor(p => p.Description)
				.NotEmpty().WithMessage("{Description} El valor no puede ser nulo o vacío.")
				.MinimumLength(3).WithMessage("{Description} El valor debe tener al menos 3 caracteres.")
				.MaximumLength(50).WithMessage("{Description} El valor no puede tener más de 50 caracteres.");
			//.Matches(@"^[a-zA-Z]+$").WithMessage("El valor solo puede contener letras del alfabeto.");
		}
	}
}
