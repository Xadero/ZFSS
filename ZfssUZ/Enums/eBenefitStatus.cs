using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZfssUZ.Enums
{
    public enum eBenefitStatus
    {
        /// <summary>
        /// Przekazany
        /// </summary>
        Passed = 1,

        /// <summary>
        /// W trakcie weryfikacji
        /// </summary>
        InVeryfication = 2,

        /// <summary>
        /// Zaakceptowany
        /// </summary>
        Accepted = 3,

        /// <summary>
        /// Odrzucony
        /// </summary>
        Rejected = 4
    }
}
