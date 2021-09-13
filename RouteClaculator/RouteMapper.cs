using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteClaculator
{
    class RouteMapper
    {
        public static void Map(Route destination, RouteModel source)
        {
            destination.LocationStart = source.LocationStart;
            destination.LocationEnd = source.LocationEnd;
            destination.RouteLength = source.RouteLength;
            destination.City = source.CityName;
        }

        public static void Map(RouteModel destination, Route source)
        {
            destination.Id = source.Id;
            destination.LocationStart = source.LocationStart;
            destination.LocationEnd = source.LocationEnd;
            destination.RouteLength = source.RouteLength;
            destination.CityName = source.City;
        }
    }
}
