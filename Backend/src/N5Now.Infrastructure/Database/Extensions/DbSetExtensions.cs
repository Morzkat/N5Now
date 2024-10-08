﻿using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace N5Now.Infrastructure.Database.Extensions
{
    public static class DbSetExtensions
    {
        public static IQueryable<TEntity> Include<TEntity>(this IQueryable<TEntity> source, IEnumerable<string> entitiesToInclude) where TEntity : class
        {
            if (entitiesToInclude != null && entitiesToInclude.Any())
                foreach (var entity in entitiesToInclude)
                    source = source.Include(entity);

            return source;
        }

        public static IQueryable<TEntity> Filter<TEntity>(this IQueryable<TEntity> source, IEnumerable<Expression<Func<TEntity, bool>>> predicates) where TEntity : class
        {
            if (predicates != null && predicates.Any())
                foreach (var predicate in predicates)
                    source = source.Where(predicate);

            return source;
        }
    }
}
