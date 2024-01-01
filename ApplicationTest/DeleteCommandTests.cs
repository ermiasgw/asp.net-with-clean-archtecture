

using Application;
using Application.Tasks.Delete;
using Domain.Repositories;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace ApplicationTest;

public class DeleteCommandTests
{
    private static readonly DeleteTaskCommand Command = new(new Guid());
    private readonly DeleteTaskCommandHandler _handler;
    private readonly ITaskRepository _TaskRepositoryMock;
    private readonly IUnitofWork _UnitofWorkMock;

    public DeleteCommandTests()
    {
        _TaskRepositoryMock = Substitute.For<ITaskRepository>();
        _UnitofWorkMock = Substitute.For<IUnitofWork>();

        _handler = new DeleteTaskCommandHandler(_TaskRepositoryMock, _UnitofWorkMock);

    }

    [Fact]
    public async void Handler_Must_Return_Error_When_There_is_No_Task()
    {
        //Arange
        DeleteTaskCommand command = Command with { TaskId = new Guid() };

        //Act
        Assert.ThrowsAsync<ArgumentException>(async () => await _handler.Handle(command, default));


    }
}
