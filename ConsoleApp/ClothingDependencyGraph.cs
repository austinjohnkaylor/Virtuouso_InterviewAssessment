namespace ConsoleApp;

/// <summary>
/// Contains the dependency relationship between clothing items
/// </summary>
public class ClothingDependencyGraph
{
    /// <summary>
    /// The clothing items that make up the graph of clothing dependencies
    /// </summary>
    public List<ClothingItemNode> ClothingItemNodes { get; }

    public List<ClothingItemRelationship> ClothingItemRelationships { get; }

    private string[,] ClothingDependencyInput;

    public ClothingDependencyGraph(string[,] clothingDependencyInput)
    {
        ClothingDependencyInput = clothingDependencyInput;
        ClothingItemNodes = new List<ClothingItemNode>();
        ClothingItemRelationships = new List<ClothingItemRelationship>();
    }

    public void GenerateRelationshipsBetweenNodes()
    {
        for (var i = 0; i < ClothingDependencyInput.GetLength(0); i++)
        {
            var clothingItemThatNeedsToGoOnBefore = ClothingDependencyInput[i, 0];
            var clothingItem = ClothingDependencyInput[i, 1];
            
            ClothingItemRelationships.Add(new ClothingItemRelationship
            {
                GoesOnAfter = clothingItem,
                GoesOnBefore = clothingItemThatNeedsToGoOnBefore
            });
        }
    }

    /// <summary>
    /// Generates a distinct list of nodes for the clothing dependency graph
    /// </summary>
    /// <param name="dependencyInput"> 2d array of clothing item dependencies
    /// <example>
    /// var input = new[,]
    /// {
    /// //dependency    //item
    /// {"t-shirt", "dress shirt"},
    /// {"dress shirt", "pants"},
    /// }
    /// </example>
    /// </param>
    public void GenerateNodes()
    {
        var distinctClothingItemsFromInput = ClothingDependencyInput.Cast<string>().Distinct().ToList();

        foreach (var distinctClothingItem in distinctClothingItemsFromInput)        
        {
            ClothingItemNodes.Add(new ClothingItemNode
            {
                ClothingItemName = distinctClothingItem
            });
        }
    }

    /// <summary>
    /// Sorts the graph Topologically using Kahn's Algorithm
    /// </summary>
    /// <remarks>https://en.wikipedia.org/wiki/Topological_sorting</remarks>
    /// <returns>The order to put the clothes on</returns>
    public List<string> SortGraphUsingKahnsAlgorithm()
    {
        /*
            Kahns Algorithm
            L ← Empty list that will contain the sorted elements
            S ← Set of all nodes with no incoming edge

            while S is not empty do
                remove a node n from S
                add n to L
                for each node m with an edge e from n to m do
                    remove edge e from the graph
                    if m has no other incoming edges then
                        insert m into S

            if graph has edges then
                return error   (graph has at least one cycle)
            else
                return L   (a topologically sorted order)
        */
        
        var L = new List<ClothingItemNode>();
        // Get clothing with no dependencies on other clothing
        var S = ClothingItemNodes.Where(node => ClothingItemRelationships.All(cir => cir.GoesOnAfter == node.ClothingItemName == false)).ToList();

        while (S.Any())
        {
            var n = S.First();
            S.Remove(n);
            L.Add(n);

            foreach (var clothingItemRelationship in ClothingItemRelationships.Where(cir => cir.GoesOnBefore == n.ClothingItemName).ToList())
            {
                var m = clothingItemRelationship.GoesOnAfter;

                ClothingItemRelationships.Remove(clothingItemRelationship);

                if (ClothingItemRelationships.All(cir => cir.GoesOnAfter == m == false))
                {
                    S.Add(new ClothingItemNode
                    {
                        ClothingItemName = m
                    });
                }
            }
        }

        return L.Select(lClothingItemNode => lClothingItemNode.ClothingItemName).ToList();
    }
}