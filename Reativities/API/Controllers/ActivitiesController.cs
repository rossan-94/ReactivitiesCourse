using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class ActivitiesController(AppDbContext appDbContext) : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetActivities()
        {
            var activities = await appDbContext.Activities.ToListAsync();
            return Ok(activities);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetActivity(string id)
        {
            var activity = await appDbContext.Activities.FindAsync(id);
            if (activity == null) return NotFound();
            return Ok(activity);
        }
    }
}
