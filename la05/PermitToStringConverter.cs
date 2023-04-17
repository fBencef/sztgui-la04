using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace la05
{
    public static class PermitToStringConverter
    {
        public static object Convert(bool hasPermit)
        {
            string output = "VAN";

            if (!hasPermit) output = "NINCS";

            return output;
        }
    }
}
