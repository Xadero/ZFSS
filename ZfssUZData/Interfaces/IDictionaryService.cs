using System;
using System.Collections.Generic;
using System.Text;

namespace ZfssUZData.Interfaces
{
    public interface IDictionaryService
    {
        dynamic Get<T>(int id);
    }
}
