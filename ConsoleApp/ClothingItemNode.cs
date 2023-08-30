namespace ConsoleApp;

public class ClothingItemNode
{
    /// <summary>
    /// The name of the clothing item
    /// </summary>
    public string ClothingItemName { get; set; }

    /// <summary>
    /// The clothes that go on before this clothing item
    /// </summary>
    public List<string> ClothesThatGoOnBefore { get; set; }
}