using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFTCalculator.Data
{
    public class ListData
    {
        public static List<string> unitlist = new()
        {
            "list2",
            "Jinx",
            "Karma"
        };

        public List<string> UNITLIST { get { return unitlist; } }
    }
}
