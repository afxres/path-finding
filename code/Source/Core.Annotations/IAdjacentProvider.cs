namespace Core.Annotations;

using System.Collections.Generic;

public interface IAdjacentProvider<TEntry>
{
    IReadOnlyCollection<TEntry> GetAdjacent(TEntry entry);
}
