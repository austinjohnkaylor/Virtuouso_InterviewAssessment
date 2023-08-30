namespace ConsoleApp;

public class ClothingItemRelationship
{
    /// <summary>
    /// The clothing item that needs to go on before <see cref="GoesOnAfter"/>
    /// </summary>
    public string GoesOnBefore { get; set; }
    /// <summary>
    /// The clothing item that goes on after <see cref="GoesOnBefore"/>
    /// </summary>
    public string GoesOnAfter { get; set; }
}