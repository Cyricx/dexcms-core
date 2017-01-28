using DexCMS.Core.Interfaces;
using DexCMS.Core.Models;
using DexCMS.Core.WebApi.ApiModels;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace DexCMS.Core.WebApi.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CountriesController : ApiController
    {
		private ICountryRepository repository;

		public CountriesController(ICountryRepository repo) 
		{
			repository = repo;
		}

        // GET api/Countries
        public List<CountryApiModel> GetCountries()
        {
			var items = repository.Items.Select(x => new CountryApiModel {
				CountryID = x.CountryID,
				Name = x.Name,
                StateCount = x.States.Count
			}).ToList();

			return items;
        }

        // GET api/Countries/5
        [ResponseType(typeof(Country))]
        public async Task<IHttpActionResult> GetCountry(int id)
        {
			Country country = await repository.RetrieveAsync(id);
            if (country == null)
            {
                return NotFound();
            }

			CountryApiModel model = new CountryApiModel()
			{
				CountryID = country.CountryID,
				Name = country.Name,
                StateCount = country.States.Count
			
			};

            return Ok(model);
        }

        // PUT api/Countries/5
        public async Task<IHttpActionResult> PutCountry(int id, Country country)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != country.CountryID)
            {
                return BadRequest();
            }

			await repository.UpdateAsync(country, country.CountryID);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Countries
        [ResponseType(typeof(Country))]
        public async Task<IHttpActionResult> PostCountry(Country country)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

			await repository.AddAsync(country);

            return CreatedAtRoute("DefaultApi", new { id = country.CountryID }, country);
        }

        // DELETE api/Countries/5
        [ResponseType(typeof(Country))]
        public async Task<IHttpActionResult> DeleteCountry(int id)
        {
			Country country = await repository.RetrieveAsync(id);
            if (country == null)
            {
                return NotFound();
            }

			await repository.DeleteAsync(country);

            return Ok(country);
        }

    }



}