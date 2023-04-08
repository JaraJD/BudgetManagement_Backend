﻿using FluentValidation;

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
					.NotEmpty().WithMessage("{Balance} no puede estar vacio")
					.NotNull().WithMessage("{Balance} no puede ser null");
		}
		
	}
}
