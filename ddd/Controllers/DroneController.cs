using ddd.Commands.CreateDron;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ddd.Controllers
{
    [ApiController]
    [Route("drone")]
    public class DroneController : Controller
    {
        private readonly IMediator mediator;

        public DroneController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDronRequest request)
        {
            var result = await mediator.Send(request);

            return Ok(result);
        }

        [HttpDelete("{dronId:Guid}")]
        public async Task<IActionResult> Delete(Guid dronId)
        {
            var response = await mediator.Send(new DeleteDronRequest()
            {
                DronId = dronId
            });

            return Ok(response);
        }
    }
}
