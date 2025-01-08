using Web_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Web_Api.Controllers
{
    public class CountryController : ApiController
    {
        private static List<Country> countries = new List<Country>
        {
            new Country { ID = 1, CountryName = "Japan", Capital = "Tokyo" },
            new Country { ID = 2, CountryName = "Italy", Capital = "Rome" }
        };

        // GET: api/country
        public IEnumerable<Country> GetCountries()
        {
            return countries;
        }

        // GET: api/country/1
        public IHttpActionResult GetCountry(int id)
        {
            var country = countries.FirstOrDefault(c => c.ID == id);
            if (country == null)
            {
                return NotFound();
            }
            return Ok(country);
        }

        // POST: api/country
        public IHttpActionResult PostCountry(Country country)
        {
            country.ID = countries.Max(c => c.ID) + 1;
            countries.Add(country);
            return CreatedAtRoute("DefaultApi", new { id = country.ID }, country);
        }

        // PUT: api/country/1
        public IHttpActionResult PutCountry(int id, Country updatedCountry)
        {
            var country = countries.FirstOrDefault(c => c.ID == id);
            if (country == null)
            {
                return NotFound();
            }
            country.CountryName = updatedCountry.CountryName;
            country.Capital = updatedCountry.Capital;
            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }

        // DELETE: api/country/1
        public IHttpActionResult DeleteCountry(int id)
        {
            var country = countries.FirstOrDefault(c => c.ID == id);
            if (country == null)
            {
                return NotFound();
            }
            countries.Remove(country);
            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }
    }
}