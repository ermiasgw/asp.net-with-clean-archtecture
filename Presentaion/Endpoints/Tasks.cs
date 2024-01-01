
using Application.Tasks.Create;
using Application.Tasks.Delete;
using Application.Tasks.Get;
using Application.Tasks.Update;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Presentation.Endpoints;

public class Tasks : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("tasks", async (ISender sender) =>
        {
            return Results.Ok(await sender.Send(new GetAllTaskQuery()));
        });

        app.MapGet("tasks/{id:guid}", async (Guid id, ISender sender) =>
        {
            var task = await sender.Send(new GetTaskQuery(id));
            if (task != null)
            {
                return Results.Ok(task);
            }
            return Results.BadRequest();
            
        });

        app.MapPost("tasks", async (CreateTaskCommand command, ISender sender) =>
        {
            await sender.Send(command);

            return Results.Ok();
        });

        app.MapDelete("tasks/{id:guid}", async (Guid id, ISender sender) =>
        {
            try
            {
                await sender.Send(new DeleteTaskCommand(id));
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
            
        });

        app.MapPut("tasks/{id:guid}", async (Guid id, [FromBody] UpdateTaskRequest request, ISender sender) =>
        {
            var command = new UpdateTaskCommand(
                id,
                request.Name,
                request.Description,
                request.DueDate);
            try
            {
                await sender.Send(command);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
             
        });
    }

}
