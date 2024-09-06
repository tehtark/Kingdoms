using Kingdoms.Server.Domain.Entities;
using Kingdoms.Server.Infrastructure.Data;
using MediatR;

namespace Kingdoms.Server.Application.Common.Test.Commands;

public class TestCommand : IRequest
{
}

internal class TestCommandHandler(DatabaseContext databaseContext) : IRequestHandler<TestCommand>
{
    public async Task Handle(TestCommand request, CancellationToken cancellationToken)
    {
        databaseContext.Players.Add(new Player() { Username = "Tark"});
        databaseContext.SaveChanges();
    }
}