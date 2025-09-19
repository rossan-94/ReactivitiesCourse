using Application.Activities.Commands;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        /// <summary>
        /// GetActivities
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetActivities()
        {
            var activities = await Mediator.Send(new Application.Activities.Queries.GetActivityList.Query());
            return Ok(activities);
        }

        /// <summary>
        /// GetActivity
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetActivity(string id)
        {
            var activity = await Mediator.Send(new Application.Activities.Queries.GetActivityDetails.Query { Id = id });
            if (activity == null) return NotFound();
            return Ok(activity);
        }

        [HttpPost]
        public async Task<IActionResult> CreateActivity(Activity activity)
        {
            var activityId = await Mediator.Send(new CreateActivity.Command { Activity = activity });
            if (string.IsNullOrEmpty(activityId)) return BadRequest("Failed to create activity");
            return new OkObjectResult(activityId);
        }


        [HttpPut]
        public async Task<IActionResult> EditActivity(Activity activity)
        {
            var result = await Mediator.Send(new EditActivity.Command { Activity = activity });
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(string id)
        {
            var result = await Mediator.Send(new Application.Activities.Commands.DeleteActivity.Command { Id = id });
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
