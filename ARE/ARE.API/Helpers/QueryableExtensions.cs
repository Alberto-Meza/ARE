using System;
using System.Linq.Expressions;
using ARE.Shared.DTOs;
using ARE.Shared.Entities;

namespace ARE.API.Helpers
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable,PaginationDTO pagination)
        {
            return queryable
                .Skip((pagination.Page - 1) * pagination.RecordsNumber)
                .Take(pagination.RecordsNumber);
        }

        public static IQueryable<T> ContaintAll<T>(this IQueryable<T> queryable,PaginationDTO pagination,Object Entity)
        {
            Func<T, bool> predicate = null!;

            if (string.IsNullOrEmpty(pagination.Filter))
                return queryable;
            else {
                Entity.GetType().GetProperties().ToList().ForEach(x => {

                    if (!x.PropertyType.IsGenericType && x.PropertyType.Namespace == "System")
                        ArmarPredicado(ref predicate, c => c.GetType().GetProperty(x.Name.ToString()).GetValue(c).ToString().ToLower().Contains(pagination.Filter.ToLower()));

                });
            }

            return queryable.Where(predicate).AsQueryable();
        }

        public static void ArmarPredicado<T>(ref Func<T, bool> predicate, Func<T, bool> newPredicate)
        {
            if (predicate == null)
            {
                predicate = newPredicate;
                return;
            }
            var oldPredicate = predicate;
            predicate = s => oldPredicate(s) || newPredicate(s);

        }
    }

}

