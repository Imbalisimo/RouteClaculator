using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteClaculator
{
    public static class RoutesDatabaseContext
    {
        public static List<City> GetCities()
        {
            using (RoutesDBEntities routesDB = new RoutesDBEntities())
            {
                return routesDB.Cities.ToList();
            }
        }

        public static City GetCityByName(string cityName)
        {
            using (RoutesDBEntities routesDB = new RoutesDBEntities())
            {
                return routesDB.Cities.Where(x => x.CityName == cityName).FirstOrDefault();
            }
        }

        public static void AddCity(string cityName)
        {
            using (RoutesDBEntities routesDB = new RoutesDBEntities())
            {
                routesDB.Cities.Add(new City(cityName));
                routesDB.SaveChanges();
            }
        }

        public static List<Route> GetRoutes()
        {
            using (RoutesDBEntities routesDB = new RoutesDBEntities())
            {
                return routesDB.Routes.ToList();
            }
        }
        public static List<Route> GetRoutesByCity(City city)
        {
            using (RoutesDBEntities routesDB = new RoutesDBEntities())
            {
                return routesDB.Routes.Where(x => x.City == city.CityName).ToList();
            }
        }

        public static List<Path> GetRandomRoutesWithLength(decimal length, City city)
        {
            List<Route> routes = GetRoutes();
            return Knapsack(routes, length, city).ToList().Shuffle().Take(5).ToList();
        }

        private static List<Path> Knapsack(List<Route> routes, decimal length, City city)
        {
            if (length < -1)
                return null;
            if (length <= 1)
                return new List<Path>() { new Path() };

            List<Route> potentialRoutes = new List<Route>(routes);
            List<Path> existingPaths = new List<Path>();
            foreach(Route route in routes)
            {
                potentialRoutes.Remove(route);
                List<Path> returnPaths = Knapsack(potentialRoutes, length - route.RouteLength, city);
                if (returnPaths != null)
                {
                    foreach (Path path in returnPaths)
                        path.Routes.Add(route);
                    existingPaths.AddRange(returnPaths);

                }
            }
            return existingPaths;
        }

        private static Random rng = new Random();
        private static IList<T> Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            return list;
        }

        public static void AddRoute(RouteModel route)
        {
            using (RoutesDBEntities routesDB = new RoutesDBEntities())
            {
                Route newRoute = new Route();
                RouteMapper.Map(newRoute, route);
                routesDB.Routes.Add(newRoute);
                routesDB.SaveChanges();
            }
        }

        public static void EditRoute(RouteModel route)
        {
            using (RoutesDBEntities routesDB = new RoutesDBEntities())
            {
                Route r = routesDB.Routes.Where(x => x.Id == route.Id).FirstOrDefault();
                RouteMapper.Map(r, route);
                routesDB.SaveChanges();
            }
        }

        public static void DeleteRoute(Route route)
        {
            using (RoutesDBEntities routesDB = new RoutesDBEntities())
            {
                routesDB.Routes.Attach(route);
                routesDB.Routes.Remove(route);
                routesDB.SaveChanges();
            }
        }
    }
}
