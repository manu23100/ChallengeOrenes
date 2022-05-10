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

        /// <summary>
        /// Delete an order from the db
        /// </summary>
        /// <param name="id"></param>
        public void delete(int id)
        {
            Order o = _context.orders.Find(id);
            _context.orders.Remove(o);
            _context.SaveChanges();
        }

        /// <summary>
        /// Get all orders in the db
        /// </summary>
        /// <returns>A list of orders</returns>
        public List<Order> getAll()
        {
            return _context.orders.ToList();
        }

        /// <summary>
        /// Get an order with an id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Order with the specified id</returns>
        public Order getById(int id)
        {
            return _context.orders.Find(id);
        }

        /// <summary>
        /// Get an order with an order number
        /// </summary>
        /// <param name="orderNumber"></param>
        /// <returns>The order with the specified order number</returns>
        public Order getByOrderNumber(int orderNumber)
        {
            return _context.orders.Where(o => o.orderNumber == orderNumber).FirstOrDefault();   
        }

        /// <summary>
        /// Insert a new order in the db
        /// </summary>
        /// <param name="order"></param>
        public void insert(Order order)
        {
            _context.orders.Add(order);
            _context.SaveChanges();
        }
    }
}
