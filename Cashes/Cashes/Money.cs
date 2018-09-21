namespace Cashes
{
    public class Money : IExpression
    {
        public string Currency { get; }

        public decimal Amount { get; }

        public Money(decimal amount, string currency)
        {
            Currency = currency;
            Amount = amount;
        }

        public Money Times(int multiplier)
        {
            return new Money(Amount * multiplier, Currency);
        }

        public static Money Dollar(decimal amount)
        {
            return new Money(amount, "USD");
        }

        public static Money Franc(decimal amount)
        {
            return new Money(amount, "CHF");
        }

        public override bool Equals(object other)
        {
            var money = (Money)other;
            return money != null && Amount == money.Amount && Currency == money.Currency;
        }

        public Money Reduce(string toCurrency)
        {
            return this;
        }

        public override string ToString()
        {
            return $"{Amount} {Currency}";
        }

        public IExpression Plus(Money addend)
        {
            return new Sum(this, addend);
        }
    }
}