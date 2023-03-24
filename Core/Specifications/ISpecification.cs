using System.Linq.Expressions;

namespace Core.Specifications
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria {get; } // public bool Func<T>(T i)
        List<Expression<Func<T, object>>> Includes{get; } // List of public object Func<T>(T i)
    }
}