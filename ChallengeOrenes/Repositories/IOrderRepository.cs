using ChallengeOrenes.Entities;

namespace ChallengeOrenes.Repositories
{
    public interface IOrderRepository
    {
        public List<Order> getAll();

        public Order getById(int id);
        public Order getByOrderNumber(int orderNumber);
        public void insert(Order order);

        public void delete(int id);
    }
}
