using ChallengeOrenes.DTO;

namespace ChallengeOrenes.Services
{
    public interface IOrderService
    {
        public List<OrderDTO> getAll();

        public OrderDTO getById(int id);
        public OrderDTO getByOrderNumber(int orderNumber);

        public void add(OrderDTO order);
        public void delete(int id);
    }
}
