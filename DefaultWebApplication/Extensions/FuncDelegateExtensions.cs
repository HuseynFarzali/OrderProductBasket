using System;
using System.Linq.Expressions;

namespace DefaultWebApplication.Extensions
{
    public static class Function
    {
        public static Expression<Func<TElement, bool>> ToExpression<TElement>(this Func<TElement, bool> criteria)
        {
            Expression<Func<TElement, bool>> expCriteria = element => criteria(element);
            return expCriteria;
        }
    }
}
