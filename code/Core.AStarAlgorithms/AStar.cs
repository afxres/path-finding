namespace Core.AStarAlgorithms;

using System;

public class AStar<TEntry, TValue>
{
    private readonly IAStarInfoProvider<TEntry, TValue> provider;

    private readonly IEqualityComparer<TEntry> equality;

    private readonly AStarCellComparer<TEntry, TValue> comparer;

    public AStar(IAStarInfoProvider<TEntry, TValue> provider, IEqualityComparer<TEntry> equality, IComparer<TValue> comparer)
    {
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(equality);
        ArgumentNullException.ThrowIfNull(comparer);
        this.provider = provider;
        this.equality = equality;
        this.comparer = new AStarCellComparer<TEntry, TValue>(comparer);
    }

    public AStarCell<TEntry, TValue>? Calculate(TEntry from, TEntry to)
    {
        var provider = this.provider;
        var closedList = new HashSet<TEntry>(this.equality);
        var openList = new PriorityQueue<TValue, AStarCell<TEntry, TValue>>(this.comparer);

        void Add(AStarCell<TEntry, TValue>? next, TEntry item, TValue cost)
        {
            var g = provider.AddValue(next is null ? provider.ZeroValue : next.G, cost);
            var h = provider.GetHeuristicValue(item, to);
            var f = provider.AddValue(g, h);
            var cell = new AStarCell<TEntry, TValue>(next, item, provider.AddValue(g, h), g, h);
            openList.Enqueue(f, cell);
        }

        Add(null, from, provider.ZeroValue);
        while (openList.TryDequeue(out var _, out var cell))
        {
            if (closedList.Add(cell.Item) is false)
                continue;
            if (this.equality.Equals(cell.Item, to))
                return cell;
            var dictionary = provider.GetAdjacentDictionary(cell.Item);
            foreach (var i in dictionary)
                Add(cell, i.Key, i.Value);
        }
        return null;
    }
}
