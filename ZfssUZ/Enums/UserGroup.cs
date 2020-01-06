using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ZfssUZ.Enums
{
    public enum eUserGroup
    {
        [Description("Administracja")]
        Administration = 1,

        [Description("Dział socjalny")]
        SocialService = 2,

        [Description("Pracownik UZ")]
        UzEmpoloyee = 3,

    }
}
