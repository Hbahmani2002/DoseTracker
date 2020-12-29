using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;

namespace TIF.DAL.Linq
{
    //https://www.codeproject.com/Questions/987016/How-to-build-dynamic-order-by-clause-in-LINQ-query
    public static class QueryableExtensions
    {
        public enum Order
        {
            Asc = 0,
            Desc = 1
        }

        public static IQueryable<T> OrderByDynamic<T>(
            this IQueryable<T> query,
            string orderByMember,
            Order direction)
        {
            var queryElementTypeParam = Expression.Parameter(typeof(T));

            var memberAccess = Expression.PropertyOrField(queryElementTypeParam, orderByMember);

            var keySelector = Expression.Lambda(memberAccess, queryElementTypeParam);

            var orderBy = Expression.Call(
                typeof(Queryable),
                direction == Order.Asc ? "OrderBy" : "OrderByDescending",
                new Type[] { typeof(T), memberAccess.Type },
                query.Expression,
                Expression.Quote(keySelector));

            return query.Provider.CreateQuery<T>(orderBy);
        }

        public static IQueryable<TResult> SelectDynamic<TResult>(this IQueryable source, string[] columns)
        {
            var sourceType = source.ElementType;
            var resultType = typeof(TResult);
            var parameter = Expression.Parameter(sourceType, "e");
            var bindings = columns.Select(column => Expression.Bind(
                resultType.GetProperty(column), Expression.PropertyOrField(parameter, column)));
            var body = Expression.MemberInit(Expression.New(resultType), bindings);
            var selector = Expression.Lambda(body, parameter);
            return source.Provider.CreateQuery<TResult>(
                Expression.Call(typeof(Queryable), "Select", new Type[] { sourceType, resultType },
                    source.Expression, Expression.Quote(selector)));
        }

    }
   
}
