using DataProcessing.Models;

namespace API.IRepositories
{
	public interface IOrderRepo
	{
		Task<List<Order>> GetAllOrders();
		Task<Order> GetOrderById(Guid id);
		Task<List<Order>> GetAllOrdersByUserId(Guid id);
		Task Create(Order order);
		Task Update(Order order);
		Task Delete(Guid id);
		Task SaveChanges();
	}

	public interface IOrderHistoryRepo
	{
		Task<List<OrderHistory>> GetOrderHistories();
		Task<OrderHistory> GetOrderHistoryById(Guid id);
		Task<List<OrderHistory>> GetAllOrderHistoriesById(Guid id);
		Task Create(OrderHistory orderHistory);
		Task Update(OrderHistory orderHistory);
		Task Delete(Guid id);
		Task SaveChanges();
	}
}
