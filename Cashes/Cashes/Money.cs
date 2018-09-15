namespace Cashes
{
    public class Money
    {
        protected readonly decimal _amount;

        protected readonly string _currency;

        public Money Times(int multiplier)
        {
            return null;
        }

        public Money(decimal amount, string currency)
        {
            _currency = currency;
            _amount = amount;
        }

        public string Currency => _currency;

        public static Money Dollar(decimal amount)
        {
            return new Dollar(amount, "USD");
        }

        public static Money Franc(decimal amount)
        {
            return new Franc(amount, "CHF");
        }

        public override bool Equals(object other)
        {
            var money = (Money)other;
            return _amount == money._amount && GetType().Equals(other.GetType());
        }

        public override string ToString()
        {
            return $"{_amount} {_currency}";
        }
    }
}