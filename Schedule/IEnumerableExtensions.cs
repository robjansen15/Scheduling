using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schedule
{
    public static class IEnumerableExtensions
    {
        private static Random r = new Random();
        public static List<t> Randomize<t>(this List<t> target)
        {
            return target.OrderBy(x => (r.Next())).ToList();
        }
    }
}
