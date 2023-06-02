using System.Collections.Generic;

namespace CodeTest.Interfaces
{
    public interface ICreateTestletItem
    {
        /// <exception cref="FixedNumberOfItemsException"></exception>
        /// <exception cref="AggregateException"></exception>
        Testlet CreateTestlet(string testletId, IReadOnlyList<Item> items);
    }
}
