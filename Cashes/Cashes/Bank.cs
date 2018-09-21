namespace Cashes
{
    public class Bank
    {
        public Money Reduce(IExpression source, string currency)
        {
            if (source is Money)
                return (Money) source.Reduce(currency);

            var sum = (Sum)source;

            return sum.Reduce(currency);
        }
    }
}