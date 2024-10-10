using DataProcessing.Models;

namespace View.IServices
{
	public interface IOrderServices
	{
		Task<IEnumerable<Order>> GetAllOrdersByStatus();
		Task<IEnumerable<Order>> GetAllOrderByUserId(Guid id);
		Task<Order> GetOrderById(Guid id);
		Task Create(Guid UserIdCreateThis, Order order);
		Task Update(Order order);
		Task Delete(Guid id);
		Task<IEnumerable<PaymentHistory>> GetPaymentHistoriesByOrderId(Guid id);
		Task AddPayment(PaymentHistory payment);
		Task ChangeStatus(string StatusValue, Guid UserIdCreateThis, Guid OrderId); // OrderHistory
		Task BackStatus(Guid UserIdCreateThis, Guid OrderId); // OrderHistory
		Task<IEnumerable<OrderHistory>> GetOrderHistoriesByOrderId(Guid id);
	}
}
