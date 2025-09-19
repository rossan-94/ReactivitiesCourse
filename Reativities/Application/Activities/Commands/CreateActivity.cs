using Domain;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Application.Activities.Commands
{
    public class CreateActivity
    {
        public class Command : IRequest<string>
        {
            public required Activity Activity { get; set; }
        }

        public class Handler(AppDbContext appDbContext) : IRequestHandler<Command, string>
        {
            public async Task<string> Handle(Command request, CancellationToken cancellationToken)
            {
                appDbContext.Activities.Add(request.Activity);
                return await appDbContext.SaveChangesAsync(cancellationToken) > 0 ? request.Activity.Id : string.Empty;
            }
        }
    }
}
