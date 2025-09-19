using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities.Commands
{
    public class EditActivity
    {
        public class Command : IRequest<bool>
        {
            public required Activity Activity { get; set; }
        }

        public class Handler(AppDbContext appDbContext, IMapper mapper) : IRequestHandler<Command, bool>
        {
            public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await appDbContext.Activities.FindAsync(new object?[] { request.Activity.Id }, cancellationToken);
                if (activity == null) return false;
                //activity.Title = request.Activity.Title;
                //activity.Description = request.Activity.Description;
                //activity.Category = request.Activity.Category;
                //activity.Date = request.Activity.Date;
                //activity.City = request.Activity.City;
                //activity.Venue = request.Activity.Venue;
                // OR
                mapper.Map(request.Activity, activity);
                return await appDbContext.SaveChangesAsync(cancellationToken) > 0;
            }
        }
    }
}
