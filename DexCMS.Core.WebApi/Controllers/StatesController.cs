using DexCMS.Core.Infrastructure.Interfaces;
using DexCMS.Core.Infrastructure.Models;
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
    public class StatesController : ApiController
    {
		private IStateRepository repository;

		public StatesController(IStateRepository repo) 
		{
			repository = repo;
		}

        // GET api/States
        public List<StateApiModel> GetStates()
        {
			var items = repository.Items.Select(x => new StateApiModel {
				StateID = x.StateID,
				Name = x.Name,
				CountryID = x.CountryID,
				Abbreviation = x.Abbreviation,
                CountryName = x.Country.Name
			}).ToList();

			return items;
        }

        // GET api/States/5
        [ResponseType(typeof(State))]
        public async Task<IHttpActionResult> GetState(int id)
        {
			State state = await repository.RetrieveAsync(id);
            if (state == null)
            {
                return NotFound();
            }

			StateApiModel model = new StateApiModel()
			{
				StateID = state.StateID,
				Name = state.Name,
				CountryID = state.CountryID,
				Abbreviation = state.Abbreviation
			};

            return Ok(model);
        }

        // PUT api/States/5
        public async Task<IHttpActionResult> PutState(int id, State state)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != state.StateID)
            {
                return BadRequest();
            }

			await repository.UpdateAsync(state, state.StateID);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/States
        [ResponseType(typeof(State))]
        public async Task<IHttpActionResult> PostState(State state)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

			await repository.AddAsync(state);

            return CreatedAtRoute("DefaultApi", new { id = state.StateID }, state);
        }

        // DELETE api/States/5
        [ResponseType(typeof(State))]
        public async Task<IHttpActionResult> DeleteState(int id)
        {
			State state = await repository.RetrieveAsync(id);
            if (state == null)
            {
                return NotFound();
            }

			await repository.DeleteAsync(state);

            return Ok(state);
        }

    }


}