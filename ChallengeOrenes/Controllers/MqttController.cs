using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ChallengeOrenes.Services;
using ChallengeOrenes.MQTT;
using ChallengeOrenes.DTO;

namespace ChallengeOrenes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MqttController : ControllerBase
    {

        private readonly ILocationService _locationService;
        private readonly IVehicleService _vehicleService;

        private Suscriber _suscriber;
        private Publisher _publisher;

        public MqttController(ILocationService locationService,IVehicleService vehicleService)
        {
            _locationService = locationService;
            _suscriber = new Suscriber();
            _publisher = new Publisher();
            _vehicleService = vehicleService;
        }

        [HttpPost("connect")]
        public async Task connect()
        {
            try
            {
                await _suscriber.Connect();   
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error when connecting with suscriber");
            }

           
        }

        [HttpPost("newLocation")]
        public async Task<ActionResult> newLocation(LocationDTO location)
        {
            try
            {

                VehicleDTO v = _vehicleService.getById(location.vehicleId);

                if (v == null)
                    return BadRequest("Vehicle with id " + location.vehicleId + " not found");

               await _publisher.Connect();
               await _publisher.PublishMessageAsync(location);

               _locationService.add(location);

            }catch (Exception ex)
            {
                Console.WriteLine("Error when sending message");
            }

            return Ok();
        }
        
    }
}
