namespace Core.Annotations;

using System.Collections.Generic;

public interface IPathFinder<TEntry>
{
    IReadOnlyList<TEntry> Invoke(TEntry from, TEntry to);
}
