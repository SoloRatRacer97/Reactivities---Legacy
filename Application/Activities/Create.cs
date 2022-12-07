using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Create
    {
        public class Command : IRequest
        {
            public Activity Activity { get; set; }
        }


            public class Handler : IRequestHandler<Command>
            {
                private readonly DataContext _context;

                public Handler(DataContext context)
                {
                    _context = context;
                }
                  public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
                  {
                        // This isnt actually saving changes in the database, its just storing it in memory for now
                        _context.Activities.Add(request.Activity);
                        // To save it in the database, we need to save it asyncronously. 
                        await _context.SaveChangesAsync();
                        // The api needs to know when this finsihed, so we have to retrun Uinit.Value
                        return Unit.Value;
                  }
            }
      }
}