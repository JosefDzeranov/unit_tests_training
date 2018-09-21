namespace Cashes
{
    public interface IExpression
    {
        Money Reduce(string toCurrency);
    }
}