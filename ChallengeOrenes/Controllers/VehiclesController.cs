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
using ChallengeOrenes.DTO;
using AutoMapper;
using ChallengeOrenes.Services;

namespace ChallengeOrenes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehiclesController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }



        // GET: api/Vehicles
        [HttpGet]
        public List<VehicleDTO> vehicles()
        {
            return _vehicleService.getAll();
        }

        
        [HttpGet("locationHistory/{id}")]
        public ActionResult<List<LocationDTO>> locationHistory(int id)
        {
            var r = _vehicleService.getLocations(id);

            if (r == null)
                return NotFound("Vehicle with id " + id + " not found");

            return r;
        }

        
        [HttpGet("currentLocation/{id}")]
        public ActionResult<LocationDTO> currentLocation(int id)
        {
            var r = _vehicleService.getById(id);

            if (r == null)
                return NotFound("Vehicle with id " + id + " not found");

            var location = _vehicleService.getCurrentLocation(id);

            if (location == null)
                return BadRequest("Vehicle with id " + id + " hasn't locations");

            return location;
        }

        
        // POST: api/Vehicles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<VehicleDTO>  insert(VehicleChildDTO vehicle)
        {

            try
            {
                _vehicleService.add(vehicle);
            }catch(Exception ex)
            {
                return BadRequest("Couldn't insert vehicle");
            }

            return Ok();
          
        }

        [HttpGet("{id}")]
        public ActionResult<VehicleDTO> GetVehicle(int id)
        {
            var v = _vehicleService.getById(id);

            if (v == null)
            {
                return NotFound("Vehicle with id " + id + " not found");
            }

            return v;
        }

        
    }
}
