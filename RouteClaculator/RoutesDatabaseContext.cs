using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteClaculator
{
    public static class RoutesDatabaseContext
    {
        public static List<Cities> GetCities()
        {
            using (RoutesDBEntities routesDB = new RoutesDBEntities())
            {
                return routesDB.Cities.ToList();
            }
        }

        public static void AddCity(string cityName)
        {
            using (RoutesDBEntities routesDB = new RoutesDBEntities())
            {
                routesDB.Cities.Add(new Cities(cityName));
                routesDB.SaveChanges();
            }
        }

        public static List<Locations> GetLocations()
        {
            using (RoutesDBEntities routesDB = new RoutesDBEntities())
            {
                return routesDB.Locations.ToList();
            }
        }

        public static List<Locations> GetLocationsByCity(Cities city)
        {
            using (RoutesDBEntities routesDB = new RoutesDBEntities())
            {
                return routesDB.Locations.Where(x => x.City == city.Id).ToList();
            }
        }

        public static Locations GetLocationById(int id)
        {
            using (RoutesDBEntities routesDB = new RoutesDBEntities())
            {
                return routesDB.Locations.Where(x => x.Id == id).FirstOrDefault();
            }
        }

        public static void AddLocation(Locations location)
        {
            using (RoutesDBEntities routesDB = new RoutesDBEntities())
            {
                routesDB.Locations.Add(location);
                routesDB.SaveChanges();
            }
        }

        public static List<Routes> GetRoutes()
        {
            using (RoutesDBEntities routesDB = new RoutesDBEntities())
            {
                return routesDB.Routes.ToList();
            }
        }

        public static List<Path> GetRoutesWithLength(decimal length, Cities city)
        {
            List<Routes> routes = GetRoutes();
            return GetRoutesWithLength(length, routes.Where(x => x.City == city.Id).ToList());
        }

        private static List<Path> GetRoutesWithLength(decimal length, List<Routes> routes, Routes startingPoint = null)
        {
            List<Routes> routesWithStartingLocation;
            List<Path> returnPaths = new List<Path>();

            if (length < -1)
                return null;
            if (length > -1 && length < 1)
                return new List<Path>(new[] { new Path() });

            if (startingPoint == null)
                routesWithStartingLocation = new List<Routes>(routes);
            else
                routesWithStartingLocation = new List<Routes>(
                    routes.Where(x => x.LocationStart == startingPoint.LocationEnd));

            foreach (Routes route in routesWithStartingLocation)
            {
                List<Path> paths = GetRoutesWithLength(
                    length - route.RouteLength,
                    routes.Where(x => x != route).ToList(),
                    route);
                if(paths != null)
                {
                    foreach (Path path in paths)
                        path.Routes.Add(route);
                    returnPaths.AddRange(paths);
                }
            }

            return returnPaths;
        }

        public static void AddRoute(Routes route)
        {
            using (RoutesDBEntities routesDB = new RoutesDBEntities())
            {
                routesDB.Routes.Add(route);
                routesDB.SaveChanges();
            }
        }
    }
}
