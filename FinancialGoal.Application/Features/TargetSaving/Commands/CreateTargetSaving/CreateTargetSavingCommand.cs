using MediatR;

namespace FinancialGoal.Application.Features.TargetSaving.Commands.CreateTargetSaving
{
    public class CreateTargetSavingCommand : IRequest<int>
    {
        public string IdUser { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal TargetAmount { get; set; }

    }
}
