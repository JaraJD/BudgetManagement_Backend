using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityLog.Application.Features.Budget.Commands.UpdateBudget
{
	public class UpdateBudgetCommandValidator : AbstractValidator<UpdateBudgetCommand>
	{
		public UpdateBudgetCommandValidator()
		{
			RuleFor(p => p.Id)
				.NotEmpty().WithMessage("{Id} no puede estar vacio")
				.NotNull().WithMessage("{Id} no puede ser null");

			RuleFor(p => p.Name)
				.NotEmpty().WithMessage("{Name} no puede estar vacio")
				.NotNull().WithMessage("{Name} no puede ser null");

			//RuleFor(p => p.TargetMonth)
			//	.NotEmpty().WithMessage("{TargetMonth} no puede estar vacio")
			//	.NotNull().WithMessage("{TargetMonth} no puede ser null");

			RuleFor(p => p.State)
					.NotEmpty().WithMessage("{State} no puede estar vacio")
					.NotNull().WithMessage("{State} no puede ser null");
		}
	}
}
