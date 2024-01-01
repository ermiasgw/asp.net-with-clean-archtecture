
using Application.Tasks.Create;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Presentation.Endpoints;

public class Tasks : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("products", async (CreateTaskCommand command, ISender sender) =>
        {
            await sender.Send(command);

            return Results.Ok("hello");
        });
    }
}
