using System.Linq.Expressions;

namespace ProjectTemplate.Application
{
    public abstract class ConditionalSpecification<T> : Specification<T>
    {
        protected readonly Specification<T> _left;
        protected readonly Specification<T> _right;

        public ConditionalSpecification(Specification<T> left, Specification<T> right)
        {
            _right = right;
            _left = left;
        }

        public abstract override Expression<Func<T, bool>> ToExpression();
    }

    public class AndSpecification<T> : ConditionalSpecification<T>
    {
        public AndSpecification(Specification<T> left, Specification<T> right)
            : base(left, right)
        { }

        public override Expression<Func<T, bool>> ToExpression()
        {
            Expression<Func<T, bool>> leftExpression = _left.ToExpression();
            Expression<Func<T, bool>> rightExpression = _right.ToExpression();

            BinaryExpression andExpression = Expression.AndAlso(
                leftExpression.Body, rightExpression.Body);

            return Expression.Lambda<Func<T, bool>>(
                andExpression, leftExpression.Parameters.Single());
        }
    }

    public class OrSpecification<T> : ConditionalSpecification<T>
    {
        public OrSpecification(Specification<T> left, Specification<T> right)
            : base(left, right)
        { }

        public override Expression<Func<T, bool>> ToExpression()
        {
            Expression<Func<T, bool>> leftExpression = _left.ToExpression();
            Expression<Func<T, bool>> rightExpression = _right.ToExpression();

            BinaryExpression andExpression = Expression.OrElse(
                leftExpression.Body, rightExpression.Body);

            return Expression.Lambda<Func<T, bool>>(
                andExpression, leftExpression.Parameters.Single());
        }
    }

}
