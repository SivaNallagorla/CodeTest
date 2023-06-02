using CodeTest;

namespace CodeTest.Implementations
{
    using System;
    using System.Collections.Generic;
    using CodeTest.Interfaces;

    public class CreateTestletItem : ICreateTestletItem
    {
        private readonly IValidateTestlet validator;
        private readonly ITestletItemsRandomizer randomizer;

        public CreateTestletItem(IValidateTestlet validator, ITestletItemsRandomizer randomizer)
        {
            this.validator = validator ?? throw new ArgumentNullException(nameof(validator));
            this.randomizer = randomizer ?? throw new ArgumentNullException(nameof(randomizer));
        }

        public Testlet CreateTestlet(string testletId, IReadOnlyList<Item> items)
        {
            validator.ValidateTestletCreationInput(testletId, items);
            var randomItems = randomizer.Randomize(items);
            return new Testlet(testletId, randomItems);
        }
    }
}
