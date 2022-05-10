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

        public void add(OrderDTO order)
        {
            _orderRepository.insert(_mapper.Map<Order>(order));
        }

        public void delete(int id)
        {
            if (_orderRepository.getById(id) == null)
                throw new Exception("Order with id " + id + " not found");

            _orderRepository.delete(id);
        }

        public List<OrderDTO> getAll()
        {
            return _mapper.Map<List<OrderDTO>>(_orderRepository.getAll());
        }

        public OrderDTO getById(int id)
        {
            return _mapper.Map<OrderDTO>(_orderRepository.getById(id));
        }

        public OrderDTO getByOrderNumber(int orderNumber)
        {
            return _mapper.Map<OrderDTO>(_orderRepository.getByOrderNumber(orderNumber));
        }
    }
}
