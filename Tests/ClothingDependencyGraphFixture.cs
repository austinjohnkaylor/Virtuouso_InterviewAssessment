using ConsoleApp;

namespace Tests;

public class ClothingDependencyGraphFixture : IDisposable
{
    public ClothingDependencyGraph Graph { get; } = new(ExampleDependencyArray);

    public static string[,] ExampleDependencyArray { get; } = {
        //dependency    //item
        { "t-shirt", "dress shirt" },
        { "dress shirt", "pants" },
        { "dress shirt", "suit jacket" },
        { "tie", "suit jacket" },
        { "pants", "suit jacket" },
        { "belt", "suit jacket" },
        { "suit jacket", "overcoat" },
        { "dress shirt", "tie" },
        { "suit jacket", "sun glasses" },
        { "sun glasses", "overcoat" },
        { "left sock", "pants" },
        { "pants", "belt" },
        { "suit jacket", "left shoe" },
        { "suit jacket", "right shoe" },
        { "left shoe", "overcoat" },
        { "right sock", "pants" },
        { "right shoe", "overcoat" },
        { "t-shirt", "suit jacket" }
    };

    public void Dispose()
    {
        Graph.ClothingItemNodes.Clear(); // clear all the nodes in the graph
    }
}