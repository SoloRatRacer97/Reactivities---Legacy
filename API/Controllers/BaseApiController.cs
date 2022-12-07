using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        // We took the _mediator code out of ActivitiesController and put it in here to clean up that file.
        // I know what we are doing with it now, but what is Mediator doing....? Middle man for erving HTTP requests? Seems like it... 
        private IMediator _mediator;

        // Recall that protected makes it usable for this class, the BaseApuController, and any classes that are made from this oen. 

        // This ??= operator means that if the former is null, _mediator in this case, then we will assign it to whatever is to the right of the operator
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}