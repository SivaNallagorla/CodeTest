using System.Collections.Generic;

namespace CodeTest.Interfaces
{
    public interface ITestletItemsRandomizer
    {
        IReadOnlyList<Item> Randomize(IReadOnlyList<Item> items);
    }
}
