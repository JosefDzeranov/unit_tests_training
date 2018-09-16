namespace Cashes
{
    public class Money
    {
        private readonly decimal _amount;

        public string Currency { get; }

        public Money(decimal amount, string currency)
        {
            Currency = currency;
            _amount = amount;
        }

        public Money Times(int multiplier)
        {
            return new Money(_amount * multiplier, Currency);
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
            var money = (Money) other;
            return money != null && _amount == money._amount && Currency == money.Currency;
        }

        public override string ToString()
        {
            return $"{_amount} {Currency}";
        }
    }
}