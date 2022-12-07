using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Details
    {
        // Again, making query from the interface IRequest. IRequest is kind of like the template for the query class that we are making. Kind of like a shell.
        public class Query : IRequest<Activity>
        {
            public Guid Id { get; set; }
        }

            public class Handler : IRequestHandler<Query, Activity>
            {
                // Recall that constructors are what is called when the class is used to create an object. You pass the object certain parameters that are then used by the class to create the object. Here, we are passing it the Datacontext as context. And, initializing it from the parameter....
                    private readonly DataContext _context;
                  public Handler(DataContext context)
                  {
                    _context = context;

                  }

                  public async Task<Activity> Handle(Query request, CancellationToken cancellationToken)
                  {
                        return await _context.Activities.FindAsync(request.Id);
                  }
            }
      }
}