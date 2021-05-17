using System;

namespace Enums
{
    [Flags]
    public enum DayOfWeek
    {
        None = 0,
                        /* B7 B6 B5 B4 B3 B2 B1 B0 */
        Monday = 1,     /* 0  0  0  0  0  0  0  1 */
        Tuesday = 2,    /* 0  0  0  0  0  0  1  0 */
        Wednesday = 4,  /* 0  0  0  0  0  1  0  0 */
        Thursday = 8,   /* 0  0  0  0  1  0  0  0 */
        Friday = 16,    /* 0  0  0  1  0  0  0  0 */
        Saturday = 32,  /* 0  0  1  0  0  0  0  0 */
        Sunday = 64     /* 0  1  0  0  0  0  0  0 */
        /*  ----------------------------------------- */
                        /* 0  1  1  0  0  0  0  0 */

    }
}
