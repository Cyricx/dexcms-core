using DexCMS.Core.Interfaces;
using DexCMS.Core.Models;
using DexCMS.Core.WebApi.ApiModels;
using System.Collections.Generic;
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

        [ResponseType(typeof(List<CountryApiModel>))]
        public List<CountryApiModel> GetCountries()
        {
            return CountryApiModel.MapForClient(repository.Items);
        }

        [ResponseType(typeof(CountryApiModel))]
        public async Task<IHttpActionResult> GetCountry(int id)
        {
			Country country = await repository.RetrieveAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            return Ok(CountryApiModel.MapForClient(country));
        }

        public async Task<IHttpActionResult> PutCountry(int id, CountryApiModel apiModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != apiModel.CountryID)
            {
                return BadRequest();
            }

            Country country = await repository.RetrieveAsync(id);
            CountryApiModel.MapForServer(apiModel, country);

			await repository.UpdateAsync(country, country.CountryID);

            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(CountryApiModel))]
        public async Task<IHttpActionResult> PostCountry(CountryApiModel apiModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var country = new Country();
            CountryApiModel.MapForServer(apiModel, country);

            await repository.AddAsync(country);

            return CreatedAtRoute("DefaultApi", new { id = country.CountryID }, CountryApiModel.MapForClient(country));
        }

        [ResponseType(typeof(CountryApiModel))]
        public async Task<IHttpActionResult> DeleteCountry(int id)
        {
			Country country = await repository.RetrieveAsync(id);
            if (country == null)
            {
                return NotFound();
            }

			await repository.DeleteAsync(country);

            return Ok(CountryApiModel.MapForClient(country));
        }
    }
}