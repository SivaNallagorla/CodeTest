using CodeTest;

namespace CodeTest.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CodeTest.Interfaces;

    public class ValidateTestlet : IValidateTestlet
    {
        private const int FixedNumberOfItemsAllowed = 10;
        private const int NumberOfOperationalItemsAllowed = 6;
        private const int NumberOfPretestItemsAllowed = 4;

        public void ValidateTestletCreationInput(string testletId, IReadOnlyList<Item> items)
        {
            _ = testletId ?? throw new ArgumentNullException(nameof(testletId));
            _ = items ?? throw new ArgumentNullException(nameof(items));

            if (items.Count != FixedNumberOfItemsAllowed)
            {
                throw new FixedNumberOfItemsException(FixedNumberOfItemsAllowed);
            }

            var exceptions = new List<FixedNumberOfItemsException>();
            var itemsByType = items.ToLookup(i => i.Type);

            TryAddExceptionIfItemsHaveDifferentCount(
                exceptions,
                expectedCount: NumberOfOperationalItemsAllowed,
                items: itemsByType[ItemType.Operational].ToList(),
                ofType: ItemType.Operational);

            TryAddExceptionIfItemsHaveDifferentCount(
                exceptions,
                expectedCount: NumberOfPretestItemsAllowed,
                items: itemsByType[ItemType.Pretest].ToList(),
                ofType: ItemType.Pretest);

            if (exceptions.Count > 0)
            {
                throw new CodeTest.AggregateException(exceptions);
            }
        }

        private bool TryAddExceptionIfItemsHaveDifferentCount(
            ICollection<FixedNumberOfItemsException> exceptions,
            int expectedCount,
            IReadOnlyList<Item> items,
            ItemType? ofType = default)
        {
            if (items.Count != expectedCount)
            {
                exceptions.Add(new FixedNumberOfItemsException(expectedCount, ofType));
                return true;
            }

            return false;
        }
    }
}
