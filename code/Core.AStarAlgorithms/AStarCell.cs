namespace Core.AStarAlgorithms;

public class AStarCell<TEntry, TValue>
{
    public AStarCell<TEntry, TValue>? Next { get; }

    public TEntry Item { get; }

    public TValue F { get; }

    public TValue G { get; }

    public TValue H { get; }

    public AStarCell(AStarCell<TEntry, TValue>? next, TEntry item, TValue f, TValue g, TValue h)
    {
        Next = next;
        Item = item;
        F = f;
        G = g;
        H = h;
    }
}
