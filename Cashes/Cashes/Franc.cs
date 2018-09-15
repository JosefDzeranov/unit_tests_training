namespace Cashes
{
    public class Franc : Money
    {
        public Franc(decimal amount, string currency) : base(amount, currency)
        { }

        public new Money Times(int multiplier)
        {
            return new Money(_amount * multiplier, _currency);
        }
    }
}