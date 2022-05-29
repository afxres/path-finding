namespace Core.AStarAlgorithms;

public class AStarCellComparer<TEntry, TValue> : IComparer<AStarCell<TEntry, TValue>>
{
    private readonly IComparer<TValue> comparer;

    public AStarCellComparer(IComparer<TValue> comparer)
    {
        this.comparer = comparer ?? throw new ArgumentNullException(nameof(comparer));
    }

    public int Compare(AStarCell<TEntry, TValue>? x, AStarCell<TEntry, TValue>? y)
    {
        ArgumentNullException.ThrowIfNull(x);
        ArgumentNullException.ThrowIfNull(y);
        return this.comparer.Compare(x.F, y.F);
    }
}
