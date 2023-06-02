using System.Collections.Generic;

namespace CodeTest.Interfaces
{
    public interface IValidateTestlet
    {
        /// <exception cref="FixedNumberOfItemsException"></exception>
        /// <exception cref="AggregateException"></exception>
        void ValidateTestletCreationInput(string testletId, IReadOnlyList<Item> items);
    }
}
