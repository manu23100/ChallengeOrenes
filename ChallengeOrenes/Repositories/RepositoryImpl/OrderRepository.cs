using ChallengeOrenes.Entities;
using ChallengeOrenes.Data;

namespace ChallengeOrenes.Repositories.RepositoryImpl
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public void delete(int id)
        {
            Order o = _context.orders.Find(id);
            _context.orders.Remove(o);
            _context.SaveChanges();
        }

        public List<Order> getAll()
        {
            return _context.orders.ToList();
        }

        public Order getById(int id)
        {
            return _context.orders.Find(id);
        }

        public Order getByOrderNumber(int orderNumber)
        {
            return _context.orders.Where(o => o.orderNumber == orderNumber).FirstOrDefault();   
        }

        public void insert(Order order)
        {
            _context.orders.Add(order);
            _context.SaveChanges();
        }
    }
}
