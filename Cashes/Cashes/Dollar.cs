namespace Cashes
{
    public class Dollar : Money
    {
        public Dollar(decimal amount, string currency) : base(amount, currency)
        { }

        public new Money Times(int multiplier)
        {
            return new Dollar(_amount * multiplier, _currency);
        }
    }
}