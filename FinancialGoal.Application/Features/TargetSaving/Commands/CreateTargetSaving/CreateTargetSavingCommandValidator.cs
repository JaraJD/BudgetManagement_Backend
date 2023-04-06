using FluentValidation;

namespace FinancialGoal.Application.Features.TargetSaving.Commands.CreateTargetSaving
{
    public class CreateTargetSavingCommandValidator : AbstractValidator<CreateTargetSavingCommand>
    {
        public CreateTargetSavingCommandValidator()
        {
            RuleFor(p => p.IdUser)
                .NotEmpty().WithMessage("{IdUser} no puede estar vacio")
                .NotNull().WithMessage("{IdUser} no puede ser null");

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
