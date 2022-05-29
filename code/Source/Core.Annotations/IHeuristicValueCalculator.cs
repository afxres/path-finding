namespace Core.Annotations;

using System.Collections.Generic;

public interface IHeuristicValueCalculator<TEntry, TValue> where TValue : IComparer<TValue>
{
    TValue Add(TValue a, TValue b);

    TValue GetHeuristicValue(TEntry from, TEntry to);
}
