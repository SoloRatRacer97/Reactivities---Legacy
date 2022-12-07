using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Activities
{
    public class List
    {
        // This is using MediatR to make a class inside of a class and bringing in IRequest from MediatoR:
            // The class in MediatR that we are inheriting from must be an interface. We are using it to extend a class called Query for our method. That interface has all the predefined methods that we need
        // Then, we are returning the activity from the list in the <>'s

        // Recall that paramters go inside the {}
        public class Query : IRequest<List<Activity>> {}

        // Bringing in a handler and passing it the query, and returning a list of activities
        // Again, we are inheriting properties from the interface, "IRequestHandler"
            // Down below, we impliment this interface 
        public class Handler : IRequestHandler<Query, List<Activity>>
        {
            // I still do not know for sure why we are doing this:
                // We needed to get access to _context from DataContext... 
            private readonly DataContext _context;

            public Handler(DataContext context)
            {

                _context = context;
            }

            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                // No idea where the ToListAsync comes in from....
                return await _context.Activities.ToListAsync(cancellationToken);
            }
        }
    }
}