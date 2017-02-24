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
    public class StatesController : ApiController
    {
		private IStateRepository repository;

		public StatesController(IStateRepository repo) 
		{
			repository = repo;
		}

        [ResponseType(typeof(List<StateApiModel>))]
        public List<StateApiModel> GetStates()
        {
            return StateApiModel.MapForClient(repository.Items);
        }

        [ResponseType(typeof(StateApiModel))]
        public async Task<IHttpActionResult> GetState(int id)
        {
			State state = await repository.RetrieveAsync(id);
            if (state == null)
            {
                return NotFound();
            }

            return Ok(StateApiModel.MapForClient(state));
        }

        public async Task<IHttpActionResult> PutState(int id, StateApiModel apiModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != apiModel.StateID)
            {
                return BadRequest();
            }
            State state = await repository.RetrieveAsync(id);
            StateApiModel.MapForServer(apiModel, state);

			await repository.UpdateAsync(state, state.StateID);

            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(StateApiModel))]
        public async Task<IHttpActionResult> PostState(StateApiModel apiModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            State state = new State();
            StateApiModel.MapForServer(apiModel, state);

			await repository.AddAsync(state);

            return CreatedAtRoute("DefaultApi", new { id = state.StateID }, StateApiModel.MapForClient(state));
        }

        [ResponseType(typeof(StateApiModel))]
        public async Task<IHttpActionResult> DeleteState(int id)
        {
			State state = await repository.RetrieveAsync(id);
            if (state == null)
            {
                return NotFound();
            }

			await repository.DeleteAsync(state);

            return Ok(StateApiModel.MapForClient(state));
        }
    }
}