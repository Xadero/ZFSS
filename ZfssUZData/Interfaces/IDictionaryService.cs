using System;
using System.Collections.Generic;
using System.Text;

namespace ZfssUZData.Interfaces
{
    public interface IDictionaryService
    {
        T Get<T>(int id) where T : class;
    }
}
