using ChallengeOrenes.DTO;
using AutoMapper;
using ChallengeOrenes.Repositories;
using ChallengeOrenes.Entities;


namespace ChallengeOrenes.Services.ServiceImpl
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Add a new order
        /// </summary>
        /// <param name="order"></param>
        public void add(OrderDTO order)
        {
            _orderRepository.insert(_mapper.Map<Order>(order));
        }

        /// <summary>
        /// Delete a order by id
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="Exception">If the order doesn't exist</exception>
        public void delete(int id)
        {
            if (_orderRepository.getById(id) == null)
                throw new Exception("Order with id " + id + " not found");

            _orderRepository.delete(id);
        }

        /// <summary>
        /// Get all orders
        /// </summary>
        /// <returns>A list of orders</returns>
        public List<OrderDTO> getAll()
        {
            return _mapper.Map<List<OrderDTO>>(_orderRepository.getAll());
        }

        /// <summary>
        /// Get a order by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The order with the specified id</returns>
        public OrderDTO getById(int id)
        {
            return _mapper.Map<OrderDTO>(_orderRepository.getById(id));
        }

        /// <summary>
        /// Get a order by an order number
        /// </summary>
        /// <param name="orderNumber"></param>
        /// <returns>The order with the specified order number</returns>
        public OrderDTO getByOrderNumber(int orderNumber)
        {
            return _mapper.Map<OrderDTO>(_orderRepository.getByOrderNumber(orderNumber));
        }
    }
}
