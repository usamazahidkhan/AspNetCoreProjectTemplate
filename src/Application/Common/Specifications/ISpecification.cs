using System.Linq.Expressions;

namespace ProjectTemplate.Application
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> ToExpression();
    }
}
