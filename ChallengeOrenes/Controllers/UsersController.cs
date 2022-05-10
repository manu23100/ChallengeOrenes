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
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IOrderService _orderService;
        private readonly IVehicleService _vehicleService;

        public UsersController(IUserService userService,IOrderService orderService,IVehicleService vehicleService)
        {
            _userService = userService;
            _orderService = orderService;
            _vehicleService = vehicleService;
        }

        // GET: api/Users
        [HttpGet]
        public List<UserDTO> users()
        {
            return _userService.getAll();
        }

        
        // GET: api/Users/5
        [HttpGet("{id}")]
        public ActionResult<UserDTO> GetUser(int id)
        {
            var user = _userService.getById(id);

            if (user == null)
            {
                return NotFound("User with id " + id + " not found");
            }

            return user;
        }

        


        
        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<UserDTO> newUser(UserChildDTO user)
        {

            try
            {
                _userService.add(user);
            }catch(Exception ex)
            {
                return BadRequest("Couldn't add user");
            }

            return Ok();
        }



        [HttpGet("getOrderInfo/{id}/{orderNumber}")]
        public ActionResult<OrderInfoUserDTO> getOrderInfo(int id, int orderNumber)
        {
            UserDTO u = _userService.getById(id);

            if (u == null)
                return BadRequest("User with id " + id + " not found");

            OrderDTO o = _orderService.getByOrderNumber(orderNumber);

            if (o == null)
                return BadRequest("Order with number " + orderNumber + " not found");

            VehicleDTO v = _vehicleService.getById(o.vehicleId);

            if (v == null)
                return BadRequest("Couldn't get the vehicle of the order " + orderNumber);

            LocationDTO loc = _vehicleService.getCurrentLocation(v.Id);

            if (loc == null)
                return BadRequest("The vehicle hasn't a location");

            return new OrderInfoUserDTO { coordX = loc.coordX, coordY = loc.coordY, licensePlateVehicle = v.licensePlate };

        }


    }
}
