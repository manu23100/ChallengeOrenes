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
   
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IVehicleService _vehicleService;
        private readonly IUserService _userService;

        public OrdersController(IOrderService orderService, IVehicleService vehicleService, IUserService userService)
        {
            _orderService = orderService;
            _vehicleService = vehicleService;
            _userService = userService;
        }


        // GET: api/Orders
        [HttpGet]
        public List<OrderDTO>  allOrders()
        {
            return _orderService.getAll();
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public  ActionResult<OrderDTO> GetOrder(int id)
        {
            var order = _orderService.getById(id);

            if (order == null)
            {
                return NotFound("Order with id " + id + " not found");
            }

            return order;
        }

        [HttpDelete("{id}")]
        public ActionResult delete(int id)
        {
            try
            {
                _orderService.delete(id);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        } 
        


     
        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<OrderDTO> newOrder(OrderDTO order)
        {

            VehicleDTO v = _vehicleService.getById(order.vehicleId);

            if (v == null)
                return BadRequest("Vehicle with id " + order.vehicleId + " not found");

            UserDTO u = _userService.getById(order.userId);

            if (u == null)
                return BadRequest("User with id " + order.userId + " not found");

            try
            {
                _orderService.add(order);
            }
            catch (Exception ex)
            {
                return BadRequest("Couldn't save the order");
            }

            return Ok();
        }

    }
}
