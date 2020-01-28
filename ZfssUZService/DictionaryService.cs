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

        public DictionaryService(ApplicationDbContext context)
        {
            applicationDbContext = context;
        }

        public T Get<T>(int id) where T : class
        {
            return applicationDbContext.Set<T>().Find(id);
        }
    }
}
