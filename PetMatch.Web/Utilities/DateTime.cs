using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetMatch.Web.Utilities
{
    public static class SqlDateTime
    {
        public static DateTime Truncate(this DateTime dateTime, TimeSpan timeSpan){
            if (timeSpan == TimeSpan.Zero)
                return dateTime;

            return dateTime.AddTicks(-(dateTime.Ticks % timeSpan.Ticks));
        }
    }
}
