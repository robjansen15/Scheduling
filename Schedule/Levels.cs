using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Schedule
{
    public static class Levels
    {
        public static int GetLevel(string levelName)
        {
            return Lvls.FirstOrDefault(x => x.Name == levelName).Lvl;
        }

        public static List<Level> Lvls = new List<Level>
        {
            new Level("PRE-PRIMARY", 1),
            new Level("PRIMARY I", 2),
            new Level("PRIMARY", 2),
            new Level("PRIMARY A", 2),
            new Level("PRIMARY II", 3),
            new Level("PRIMARY B", 3),
            new Level("PRIMARY III", 4),
            new Level("PRIMARY C", 4),
            new Level("PRIMARY IV", 5),
            new Level("PRIMARY D", 5),
            new Level("PRIMARY V", 6),
            new Level("PRIMARY E", 6),
            new Level("ELEMENTARY", 7),
            new Level("ELEMENTARY I", 7),
            new Level("CLASS 1", 7),
            new Level("CLASS I", 7),
            new Level("CLASS II", 8),
            new Level("ELEMENTARY II", 8),
            new Level("ELEMENTARY III", 9),
            new Level("ELEMENTARY IV", 10),
            new Level("CLASS V", 11),
            new Level("MEDIUM", 12),
            new Level("MEDIUM II", 13),
            new Level("MODERATELY DIFFICULT I", 14),
            new Level("MODERATELY DIFFICULT II", 15),
            new Level("MODERATELY DIFFICULT 1", 16),
            new Level("MODERATELY DIFFICULT 2", 17),
            new Level("MODERATELY DIFFICULT 3", 18),
            new Level("DIFFICULT II", 19),
            new Level("ADVANCED CLASS", 20)
        };
    }
}
