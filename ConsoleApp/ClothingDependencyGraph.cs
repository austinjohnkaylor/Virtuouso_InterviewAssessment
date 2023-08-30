namespace ConsoleApp;

/// <summary>
/// Contains the dependency relationship between clothing items
/// </summary>
public class ClothingDependencyGraph
{
    /// <summary>
    /// The clothing items that make up the graph of clothing dependencies
    /// </summary>
    public List<ClothingItemNode> ClothingItemNodes { get; set; } = new();

    public void ReadDependencyInput(string[,] dependencyInput)
    {
        for (var i = 0; i < dependencyInput.GetLength(0); i++)
        {
            var clothingItemThatNeedsToGoOnBefore = dependencyInput[i, 0];
            var clothingItem = dependencyInput[i, 1];
            
            // create a new node from the data above
            var newNode = new ClothingItemNode
            {
                ClothingItemName = clothingItem,
                ClothesThatGoOnBefore = new List<string>
                {
                    clothingItemThatNeedsToGoOnBefore
                }
            };

            if (ClothingItemNodes.Any(a => a.ClothingItemName == clothingItem))
            {
                // Add the new relationship for the existing clothing item
                ClothingItemNodes.First(a => a.ClothingItemName == clothingItem).ClothesThatGoOnBefore.AddRange(newNode.ClothesThatGoOnBefore);
            }
            else
                ClothingItemNodes.Add(newNode);
            
        }
    }
}