namespace CodeTest
{
    using System.Collections.Generic;

    public class AggregateException : ValidationException
    {
        public AggregateException(IReadOnlyCollection<FixedNumberOfItemsException> exceptions)
            : base()
        {
            this.Exceptions = exceptions;
        }

        public IReadOnlyCollection<FixedNumberOfItemsException> Exceptions { get; }
    }
}
