namespace Application.Activities.Commands
{
    public class DeleteActivity
    {
        public class Command : MediatR.IRequest<bool>
        {
            public required string Id { get; set; }
        }
        public class Handler(Persistence.AppDbContext appDbContext) : MediatR.IRequestHandler<Command, bool>
        {
            public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await appDbContext.Activities.FindAsync(new object?[] { request.Id }, cancellationToken);
                if (activity == null) return false;
                appDbContext.Activities.Remove(activity);
                return await appDbContext.SaveChangesAsync(cancellationToken) > 0;
            }
        }
    }
}
