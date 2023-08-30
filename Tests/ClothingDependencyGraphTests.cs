using ConsoleApp;
using FluentAssertions;

namespace Tests;

public class ClothingDependencyGraphTests : IClassFixture<ClothingDependencyGraphFixture>
{
    private readonly ClothingDependencyGraphFixture _clothingDependencyGraphFixture;

    public ClothingDependencyGraphTests(ClothingDependencyGraphFixture clothingDependencyGraphFixture)
    {
        _clothingDependencyGraphFixture = clothingDependencyGraphFixture;
    }

    [Fact]
    public void ReadDependencyInput_Should_Not_Throw_Exception_With_Valid_Input()
    {
        var exception = Record.Exception(() => _clothingDependencyGraphFixture.Graph.ReadDependencyInput(_clothingDependencyGraphFixture.ExampleDependencyArray));
        exception.Should().Be(null);
    }

    [Fact]
    public void ReadDependencyInput_Should_Generate_Nine_ClothingItemNodes()
    {
        _clothingDependencyGraphFixture.Graph.ReadDependencyInput(_clothingDependencyGraphFixture.ExampleDependencyArray);
        _clothingDependencyGraphFixture.Graph.ClothingItemNodes.Count.Should().Be(9);
    }
    
     [Fact]
    public void ReadDependencyInput_Should_Have_First_ClothingItemNode_As_DressShirt()
    {
        _clothingDependencyGraphFixture.Graph.ReadDependencyInput(_clothingDependencyGraphFixture.ExampleDependencyArray);
        _clothingDependencyGraphFixture.Graph.ClothingItemNodes.ElementAt(0).ClothingItemName.Should().Be("dress shirt");
    }
}