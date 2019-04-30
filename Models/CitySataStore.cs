using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core2Api.Models
{
    public class CityDataStore
    {
        public static CityDataStore Current { get; } = new CityDataStore();
        public List<City> Cities { get; set; }

        public CityDataStore()
        {
            Cities = new List<City>()
            {
                new City{id=1,Name="Kolkata",Description="Best City"},
                  new City{id=2,Name="Kolkata2",Description="Best City"},
                    new City{id=3,Name="Kolkata3",Description="Best City"}
            };
        }
    }
}
