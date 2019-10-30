using CCR.Echo.MiniWeb.Persistence.Abstractions;
using CCR.Echo.MiniWeb.Persistence.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CCR.Echo.MiniWeb.Persistence
{
    public class CountryRepository : ICountryRepository
    {
        private static IList<Country> _countries;

        #region PRIVATE

        private static void EnsureCountriesAreLoaded()
        {
            if (_countries == null)
                _countries = LoadCountriesFromStream();
        }

        private static IList<Country> LoadCountriesFromStream()
        {
            var json = File.ReadAllText("countries.json");
            var countries = JsonConvert.DeserializeObject<Country[]>(json);

            return countries.OrderBy(c => c.CountryName).ToList();
        }

        #endregion


        public IQueryable<Country> All()
        {
            EnsureCountriesAreLoaded();

            return _countries.AsQueryable();
        }

        public IQueryable<Country> AllBy(string filter)
        {
            var normalized = filter.ToLower();
            return string.IsNullOrEmpty(filter)
                ? All()
                : All().Where(c => c.CountryName.ToLower().StartsWith(normalized));
        }

        public Country Find(string code)
        {
            return (from c in All()
                    where c.CountryCode.Equals(code, StringComparison.CurrentCultureIgnoreCase)
                    select c).FirstOrDefault();
        }
    }
}
