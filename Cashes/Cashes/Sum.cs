namespace Cashes
{
    public class Sum : IExpression
    {
        public Money Augend { get; }
        public Money Addend { get; }

        public Sum(Money augend, Money addend)
        {
            Augend = augend;
            Addend = addend;
        }

        public Money Reduce(string toCurrency)
        {
            return new Money(Augend.Amount + Addend.Amount, toCurrency);
        }
    }
}