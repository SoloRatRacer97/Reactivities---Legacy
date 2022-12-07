using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Activity Activity { get; set; }
        }

            public class Handler : IRequestHandler<Command>
            {
                public readonly DataContext _context;
                private readonly IMapper _mapper;
                public Handler(DataContext context, IMapper mapper)
                {
                    _mapper = mapper;
                    _context = context;
                }
                  public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
                  {
                        var activity = await _context.Activities.FindAsync(request.Activity.Id);

                        // Now this is a goofy way fo doing things since we are only updating the activity title and nothing else, but we will add more later on
                        // activity.Title = request.Activity.Title ?? activity.Title;

                        // Here, we map the activity we got from our request to the activity that we have in our database:
                        _mapper.Map(request.Activity, activity);

                        // Saving changes...
                        await _context.SaveChangesAsync();

                        return Unit.Value;
                  }
            }
      }
}