namespace LayoutDesigner.Models;
// Models/Margin.cs
public class Margin
{
    public int Left { get; set; }
    public int Top { get; set; }
    public int Right { get; set; }
    public int Bottom { get; set; }

    public override string ToString() => $"{Top}px {Right}px {Bottom}px {Left}px";
}