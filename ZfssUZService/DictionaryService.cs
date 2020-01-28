using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;
using ZfssUZData;
using ZfssUZData.Interfaces;

namespace ZfssUZService
{
    public class DictionaryService : IDictionaryService
    {
        private ApplicationDbContext applicationDbContext;

        public dynamic Get<TEntity>(int id)
        {
            var entity = typeof(TEntity);
            var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == entity.Name);
            var yxxx = typeof(TEntity).GetType();
            var x = applicationDbContext.Find(yxxx);
             
            Type targetType = Type.GetType(entity.GetType().Name);
            var model = GetType().GetRuntimeProperties().Where(o =>
                o.PropertyType.IsGenericType &&
                o.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>) &&
                o.PropertyType.GenericTypeArguments.Contains(targetType)).FirstOrDefault();

            return model.GetValue(this);
        }
    }
}
