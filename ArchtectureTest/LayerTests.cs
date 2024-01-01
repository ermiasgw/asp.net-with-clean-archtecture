

using Domain.Entities;
using NetArchTest.Rules;
using System.Reflection;


namespace ApplicationTest;

public class LayerTests
{
    protected static readonly Assembly assembly = typeof(TaskEntity).Assembly;
    [Fact]
    public void Domain_Should_not_Have_Dependency_on_Application()
    {
        var result = Types.InAssembly(assembly)
            .Should()
            .NotHaveDependencyOn("Application")
            .GetResult();

        result.IsSuccessful.Equals(true);
    }
}
