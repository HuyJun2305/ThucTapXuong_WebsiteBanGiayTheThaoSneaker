using DataProcessing.Models;

namespace API.IRepositories
{
	public interface IOrderRepo
	{
		Task<List<Order>> GetAllOrders();
		Task<Order> GetOrderById(Guid id);
		Task<List<Order>> GetAllOrderByUser(Guid userId);
		Task Create(Order order);
		Task Update(Order order);
		Task Delete(Guid id);
		Task SaveChanges();
	}

	public interface IOrderHistoryRepo
	{
		Task<List<OrderHistory>> GetAllHistories();
		Task<OrderHistory> GetHistoryById(Guid id);
		Task<List<OrderHistory>> GetAllHistoriesByOrderId(Guid id);
		Task Create(OrderHistory orderHistory);
		Task Update(OrderHistory orderHistory);
		Task Delete(Guid id);
		Task SaveChanges();
	}
}
