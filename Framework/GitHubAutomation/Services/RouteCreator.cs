using Framework.Models;
using GitHubAutomation.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Services
{
    class RouteCreator
    {
        public static Route WithAllProperties()
        {
            return new Route(TestDataReader.GetRouteData("DepartureCity"), TestDataReader.GetRouteData("ArrivalCity"), DateTime.Now.AddDays(1).ToString("dd.MM.yyyy"));
        }

        public static Route WithEqualCities()
        {
            return new Route(TestDataReader.GetRouteData("ArrivalCity"), TestDataReader.GetRouteData("ArrivalCity"), DateTime.Now.AddDays(1).ToString("dd.MM.yyyy"));
        }

        public static Route WithPastDate()
        {
            return new Route(TestDataReader.GetRouteData("DepartureCity"), TestDataReader.GetRouteData("ArrivalCity"), DateTime.Now.AddDays(-1).ToString("dd.MM.yyyy"));
        }

        
    }
}
