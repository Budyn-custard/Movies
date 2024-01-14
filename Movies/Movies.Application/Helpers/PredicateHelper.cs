using Movies.Data.Entities;
using System.Linq.Expressions;

namespace Movies.Application.Helpers
{
    public static class PredicateHelper
    {
        public static bool IsValidColumn(string columnName)
        {
            var movieType = typeof(Movie);
            var properties = movieType.GetProperties().Select(p => p.Name);
            return properties.Contains(columnName);
        }

        public static Expression<Func<Movie, bool>> BuildPredicate(string filterColumn, string filterValue)
        {
            var parameter = Expression.Parameter(typeof(Movie), "movie");
            var property = Expression.Property(parameter, filterColumn);
            var constant = Expression.Constant(filterValue);
            var equality = Expression.Equal(property, constant);

            return Expression.Lambda<Func<Movie, bool>>(equality, parameter);
        }

        public static Expression<Func<IQueryable<Movie>, IOrderedQueryable<Movie>>> BuildSortingExpression(string orderBy)
        {
            var movieType = typeof(Movie);
            var parameter = Expression.Parameter(typeof(IQueryable<Movie>), "movies");

            // Get the property to sort by based on the 'orderBy' string
            var property = Expression.Property(parameter, orderBy);

            // Create a lambda expression for sorting
            var lambda = Expression.Lambda<Func<IQueryable<Movie>, IOrderedQueryable<Movie>>>(
                Expression.Call(
                    typeof(Queryable),
                    "OrderBy",
                    new[] { typeof(Movie), property.Type },
                    parameter,
                    Expression.Quote(Expression.Lambda(property, parameter))
                ),
                parameter
            );

            return lambda;
        }
    }
}
