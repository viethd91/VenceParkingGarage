using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VenceParkingGarage.Core.Application.Features.Commands;

namespace VenceParkingGarage.Presentation.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParkingController : ControllerBase
    {
        private readonly ILogger<ParkingController> _logger;
        private IMediator _mediator;

        public ParkingController(ILogger<ParkingController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Park(ParkCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
