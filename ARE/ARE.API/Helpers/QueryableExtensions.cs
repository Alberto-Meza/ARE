using System;
using System.Linq.Expressions;
using ARE.Shared.DTOs;
using ARE.Shared.Entities;
using ARE.Shared.Enums;
using Microsoft.EntityFrameworkCore;

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


        public static IQueryable<T> WhereCondition<T>(this IQueryable<T> queryable, List<FilterDTO> filters, Object Entity)
        {
            Func<T, bool> predicate = null!;
            Func<T, bool> predicateResult = null!;


            if (filters.Count() == 0 )
                return queryable;
            else
            {


                filters.ForEach(x => {

                    switch (x.Operator)
                    {
                        case OperatorType.Contenga: //Contenga
                            predicate = c => c.GetType().GetProperty(x.Campo.ToString()).GetValue(c).ToString().ToLower().Contains(x.Valor.ToString().ToLower());
                            break;
                        case OperatorType.Igual: //IGUAL 
                            predicate = c => c.GetType().GetProperty(x.Campo.ToString()).GetValue(c).ToString() == x.Valor.ToString();
                            break;
                        case OperatorType.Diferente: //Diferente
                            predicate = c => c.GetType().GetProperty(x.Campo.ToString()).GetValue(c).ToString() != x.Valor.ToString();
                            break;
                        default:
                            break;
                    }


                    AddPredicado(ref predicateResult, predicate);

                });
            }

            return queryable.Where(predicate).AsQueryable();
        }


        public static IQueryable<T> IncluidAll<T>(this IQueryable<T> queryable, PaginationDTO pagination, Object Entity) where T : class
        {
          
            if (string.IsNullOrEmpty(pagination.Filter))
                return queryable;
            else
            {
                Entity.GetType().GetProperties().ToList().Where(x=>x.Name.Contains("Id")).ToList().ForEach(x => {

                    var prop = x.Name.Replace("Id", "");
                    if (!string.IsNullOrEmpty(prop)) {
                        queryable = queryable.Include(prop).AsQueryable();
                    }

                });
            }

            return queryable.ContaintAll(pagination,Entity).AsQueryable();
        }

        /*public static IIncludableQueryable<TEntity, TProperty> Include<TEntity, TProperty>(this IQueryable<TEntity> source, Expression<Func<TEntity, TProperty>> navigationPropertyPath) where TEntity : class
        {
            Check.NotNull(navigationPropertyPath, "navigationPropertyPath");
            return new IncludableQueryable<TEntity, TProperty>((IQueryable<TEntity>)((source.Provider is EntityQueryProvider) ?
                ((IQueryable<object>)source.Provider.CreateQuery<TEntity>(Expression.Call(null, IncludeMethodInfo.MakeGenericMethod(typeof(TEntity), typeof(TProperty)), new Expression[2] {
        source.Expression,Expression.Quote (navigationPropertyPath)})))

    : ((IQueryable<object>)source)));
        }*/


        public static void AddPredicado<T>(ref Func<T, bool> predicate, Func<T, bool> newPredicate)
        {
            if (predicate == null)
            {
                predicate = newPredicate;
                return;
            }
            var oldPredicate = predicate;
            predicate = s => oldPredicate(s) && newPredicate(s);

        }

    }

}

