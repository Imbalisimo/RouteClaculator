using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteClaculator
{
    public class Path
    {
        public Path()
        {
            Routes = new List<Route>();
        }

        public List<Route> Routes { get; set; }

        public decimal PathLength()
        {
            decimal returnLength = 0;
            foreach (Route route in Routes)
                returnLength += route.RouteLength;

            return returnLength;
        }

        public override string ToString()
        {
            string returnString = "";
            foreach (Route route in Routes)
                returnString += route.ToString() + "\n";
            returnString += "Total: " + PathLength() + "km";

            return returnString;
        }
    }
}
