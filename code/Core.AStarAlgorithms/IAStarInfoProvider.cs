namespace Core.AStarAlgorithms;

public interface IAStarInfoProvider<TEntry, TValue>
{
    TValue ZeroValue { get; }

    TValue AddValue(TValue a, TValue b);

    TValue GetHeuristicValue(TEntry from, TEntry to);

    IReadOnlyDictionary<TEntry, TValue> GetAdjacentDictionary(TEntry entry);
}
