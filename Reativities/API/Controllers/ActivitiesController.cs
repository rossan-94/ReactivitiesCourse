using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class ActivitiesController(AppDbContext appDbContext) : BaseApiController
    {
        /// <summary>
        /// GetActivities
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetActivities()
        {
            var activities = await appDbContext.Activities.ToListAsync();
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
            var activity = await appDbContext.Activities.FindAsync(id);
            if (activity == null) return NotFound();
            return Ok(activity);
        }
    }
}
