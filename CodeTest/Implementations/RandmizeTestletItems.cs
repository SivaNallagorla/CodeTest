using CodeTest;

namespace CodeTest.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CodeTest.Interfaces;

    public class RandmizeTestletItems : ITestletItemsRandomizer
    {
        private readonly int numberOfFirstPretestItems;
        private readonly Random random;

        public RandmizeTestletItems(int numberOfFirstPretestItems, Random? random = default)
        {
            this.numberOfFirstPretestItems = numberOfFirstPretestItems;
            this.random = random ?? new Random();
        }

        public IReadOnlyList<Item> Randomize(IReadOnlyList<Item> items)
        {
            _ = items ?? throw new ArgumentNullException(nameof(items));

            var shuffledItems = ShuffleItems(items);

            MovePretestItemsToStart(shuffledItems);

            return shuffledItems;
        }

        private List<Item> ShuffleItems(IEnumerable<Item> items)
        {
            var shuffledItems = items.ToList();

            for (var i = shuffledItems.Count - 1; i >= 0; i--)
            {
                int randomIndex = random.Next(i + 1);
                shuffledItems.Swap(randomIndex, i);
            }

            return shuffledItems;
        }

        private void MovePretestItemsToStart(IList<Item> items)
        {
            var numberOfPretestItemsMovedToStart = 0;
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Type != ItemType.Pretest)
                {
                    continue;
                }

                items.Swap(i, numberOfPretestItemsMovedToStart++);

                if (numberOfPretestItemsMovedToStart >= numberOfFirstPretestItems)
                {
                    break;
                }
            }
        }
    }
}
