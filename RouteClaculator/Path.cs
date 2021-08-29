using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteClaculator
{
    public class Path
    {
        public List<Routes> Routes { get; }
        public Path()
        {
            Routes = new List<Routes>();
        }

        public Path(List<Routes> routes)
        {
            Routes = routes;
        }

        public Path(Routes route)
        {
            Routes = new List<Routes>();
            Routes.Add(route);
        }

        public override string ToString()
        {
            string returnString = "";
            foreach(Routes route in Routes)
            {
                returnString += route.ToString() + "\n";
            }
            return returnString;
        }
    }
}
