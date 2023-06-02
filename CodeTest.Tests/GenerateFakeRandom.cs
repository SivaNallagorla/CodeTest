namespace CodeTest.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GenerateFakeRandom : Random
    {
        private readonly List<int> pseudoRandomIntegers;

        public GenerateFakeRandom(IReadOnlyList<int> pseudoRandomIntegers)
        {
            this.pseudoRandomIntegers = pseudoRandomIntegers.ToList();
        }

        public override int Next(int maxValue)
        {
            var result = this.pseudoRandomIntegers[0];
            this.pseudoRandomIntegers.RemoveAt(0);
            return result;
        }
    }
}
