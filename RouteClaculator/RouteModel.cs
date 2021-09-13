using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteClaculator
{
    public class RouteModel
    {
        public int Id { get; set; }
        public string LocationStart { get; set; }
        public string LocationEnd { get; set; }
        public decimal RouteLength { get; set; }
        public City City { get; set; }
        public string CityName {
            get {
                return City.CityName;
            }
            set {
                City = RoutesDatabaseContext.GetCityByName(value);
            } }
        public bool IsEdit => Id != 0;
        public string Mode => IsEdit ? "Edit" : "Add";

        public bool IsFilled => LocationStart != null && LocationEnd != null;
    }
}
