using ConsoleApp;
using FluentAssertions;

namespace Tests;

public class ClothingDependencyGraphTests
{
    [Fact]
    public void ReadDependencyInput_Should_Not_Throw_Exception_With_Valid_Input()
    {
        var input = new[,]
        {
            //dependency    //item
            {"t-shirt", "dress shirt"},
            {"dress shirt", "pants"},
            {"dress shirt", "suit jacket"},
            {"tie", "suit jacket"},
            {"pants", "suit jacket"},
            {"belt", "suit jacket"},
            {"suit jacket", "overcoat"},
            {"dress shirt", "tie"},
            {"suit jacket", "sun glasses"},
            {"sun glasses", "overcoat"},
            {"left sock", "pants"},
            {"pants", "belt"},
            {"suit jacket", "left shoe"},
            {"suit jacket", "right shoe"},
            {"left shoe", "overcoat"},
            {"right sock", "pants"},
            {"right shoe",  "overcoat"},
            {"t-shirt", "suit jacket"}
        };
        
        var cd = new ClothingDependencyGraph();
        var exception = Record.Exception(() => cd.ReadDependencyInput(input));

        exception.Should().Be(null);
    }

    [Fact]
    public void ReadDependencyInput_Should_Generate_Nine_ClothingItemNodes()
    {
        var input = new[,]
        {
            //dependency    //item
            {"t-shirt", "dress shirt"},
            {"dress shirt", "pants"},
            {"dress shirt", "suit jacket"},
            {"tie", "suit jacket"},
            {"pants", "suit jacket"},
            {"belt", "suit jacket"},
            {"suit jacket", "overcoat"},
            {"dress shirt", "tie"},
            {"suit jacket", "sun glasses"},
            {"sun glasses", "overcoat"},
            {"left sock", "pants"},
            {"pants", "belt"},
            {"suit jacket", "left shoe"},
            {"suit jacket", "right shoe"},
            {"left shoe", "overcoat"},
            {"right sock", "pants"},
            {"right shoe",  "overcoat"},
            {"t-shirt", "suit jacket"}
        };
        
        var cd = new ClothingDependencyGraph();
        cd.ReadDependencyInput(input);

        cd.ClothingItemNodes.Count.Should().Be(9);
    }
}