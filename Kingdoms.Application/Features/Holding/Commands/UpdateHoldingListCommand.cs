using Kingdoms.Infrastructure.Database;
using MediatR;

namespace Kingdoms.Application.Features.Holding.Commands;
public record UpdateHoldingListCommand(List<Domain.Entities.Holding> Holdings) : IRequest;

internal class UpdateHoldingListCommandHandler : IRequestHandler<UpdateHoldingListCommand>
{
    public Task Handle(UpdateHoldingListCommand request, CancellationToken cancellationToken)
    {
        using var databaseContext = new DatabaseContext();

        var currentHoldings = request.Holdings;
        var updatedHoldings = databaseContext.Holdings.ToList();

        foreach (var currentHolding in currentHoldings) {
            foreach (var updatedHolding in updatedHoldings) {
                //Resources
                if (currentHolding.Id == updatedHolding.Id) {
                    if (currentHolding.Resources.Id == updatedHolding.Resources.Id) {
                        if (currentHolding.Resources.Wood != updatedHolding.Resources.Wood) {
                            currentHolding.Resources.Wood = updatedHolding.Resources.Wood;
                        }
                    }
                }
            }
        }
        return Task.CompletedTask;
    }
}