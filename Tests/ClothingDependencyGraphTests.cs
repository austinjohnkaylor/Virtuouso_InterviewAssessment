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
    public void GenerateGraph_Should_Not_Throw_Exception_With_Valid_Input()
    {
        _clothingDependencyGraphFixture.Graph.GenerateNodes();
        var exception = Record.Exception(() => _clothingDependencyGraphFixture.Graph.GenerateRelationshipsBetweenNodes());
        exception.Should().Be(null);
    }
    
    [Fact]
    public void GenerateGraph_Should_Have_All_Clothing_Items_As_Nodes()
    {
        _clothingDependencyGraphFixture.Graph.GenerateNodes();
        _clothingDependencyGraphFixture.Graph.GenerateRelationshipsBetweenNodes();
        _clothingDependencyGraphFixture.Graph.ClothingItemNodes.Exists(a => a.ClothingItemName == "left sock").Should().Be(true);
        _clothingDependencyGraphFixture.Graph.ClothingItemNodes.Exists(a => a.ClothingItemName == "right sock").Should().Be(true);
        _clothingDependencyGraphFixture.Graph.ClothingItemNodes.Exists(a => a.ClothingItemName == "dress shirt").Should().Be(true);
        _clothingDependencyGraphFixture.Graph.ClothingItemNodes.Exists(a => a.ClothingItemName == "tie").Should().Be(true);
        _clothingDependencyGraphFixture.Graph.ClothingItemNodes.Exists(a => a.ClothingItemName == "t-shirt").Should().Be(true);
        _clothingDependencyGraphFixture.Graph.ClothingItemNodes.Exists(a => a.ClothingItemName == "pants").Should().Be(true);
        _clothingDependencyGraphFixture.Graph.ClothingItemNodes.Exists(a => a.ClothingItemName == "suit jacket").Should().Be(true);
        _clothingDependencyGraphFixture.Graph.ClothingItemNodes.Exists(a => a.ClothingItemName == "overcoat").Should().Be(true);
        _clothingDependencyGraphFixture.Graph.ClothingItemNodes.Exists(a => a.ClothingItemName == "belt").Should().Be(true);
        _clothingDependencyGraphFixture.Graph.ClothingItemNodes.Exists(a => a.ClothingItemName == "sun glasses").Should().Be(true);
        _clothingDependencyGraphFixture.Graph.ClothingItemNodes.Exists(a => a.ClothingItemName == "left shoe").Should().Be(true);
        _clothingDependencyGraphFixture.Graph.ClothingItemNodes.Exists(a => a.ClothingItemName == "right shoe").Should().Be(true);
    }
    
    [Fact]
    public void SortGraphUsingKahnsAlgorithm_Should_Return_Correct_Clothing_Operation_Order()
    {
        _clothingDependencyGraphFixture.Graph.GenerateNodes();
        _clothingDependencyGraphFixture.Graph.GenerateRelationshipsBetweenNodes();
        var orderOfOperations = _clothingDependencyGraphFixture.Graph.SortGraphUsingKahnsAlgorithm();
        orderOfOperations.Should().BeEquivalentTo(new List<string>
        {
            "left sock",
            "right sock", 
            "t-shirt",
            "dress shirt",
            "pants",
            "tie",
            "belt",
            "suit jacket",
            "left shoe", 
            "right shoe", 
            "sun glasses",
            "overcoat"
        });

    }
    
}