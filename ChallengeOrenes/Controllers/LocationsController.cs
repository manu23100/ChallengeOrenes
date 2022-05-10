#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChallengeOrenes.Data;
using ChallengeOrenes.Entities;
using AutoMapper;
using ChallengeOrenes.DTO;
using ChallengeOrenes.Services;

namespace ChallengeOrenes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
       private readonly ILocationService _locationService;
        private readonly IVehicleService _vehicleService;

        public LocationsController(ILocationService locationService, IVehicleService vehicleService)
        {
            _locationService = locationService;
            _vehicleService = vehicleService;
        }



   
        [HttpGet]
        public List<LocationDTO>  locations()
        {
            return _locationService.getAll();
        }

  
        [HttpGet("{id}")]
        public ActionResult<LocationDTO> GetLocation(int id)
        {
            var location = _locationService.getById(id);

            if (location == null)
            {
                return NotFound("Location with id " + id + " not found");
            }

            return location;
        }

        

       
        [HttpPost]
        public ActionResult<LocationDTO> newLocation(LocationDTO location)
        {

            VehicleDTO v = _vehicleService.getById(location.vehicleId);

            if (v == null)
                return BadRequest("Vehicle with id " + location.vehicleId + " not found");

            try
            {
                _locationService.add(location);
            }
            catch (Exception ex)
            {
                return BadRequest("Couldn't insert location ");
            }

            return Ok();
        }
        
    }
}
