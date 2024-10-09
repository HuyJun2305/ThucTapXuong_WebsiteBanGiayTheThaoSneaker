using DataProcessing.Models;
using Newtonsoft.Json;
using View.IServices;

namespace View.Servicecs
{
	public class OrderServices : IOrderServices
	{
		private readonly HttpClient _httpClient;
		public OrderServices(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task AddPayment(PaymentHistory payment)
		{
			await _httpClient.PostAsJsonAsync("https://localhost:7170/api/PaymentHistories/", payment);
		}

		public async Task BackStatus(Guid UserIdCreateThis, Guid OrderId)
		{
			var response = await _httpClient.GetStringAsync("https://localhost:7170/api/OrderHistories");
			var data = JsonConvert.DeserializeObject<IEnumerable<OrderHistory>>(response);
			var StatusValue = data
				.Where(ph => ph.OrderId == OrderId)
				.OrderByDescending(ph => ph.TimeStamp)
				.Skip(1).FirstOrDefault().StatusType;
			if (StatusValue is null) StatusValue = "Tạo đơn hàng";

			OrderHistory orderHistory = new OrderHistory()
			{
				Id = Guid.NewGuid(),
				StatusType = StatusValue,
				TimeStamp = DateTime.Now,
				UpdatedByUserId = UserIdCreateThis,
				OrderId = OrderId,
			};
			await _httpClient.PostAsJsonAsync("https://localhost:7170/api/OrderHistories", orderHistory);
		}

		public async Task ChangeStatus(string StatusValue, Guid UserIdCreateThis, Guid OrderId)
		{
			OrderHistory orderHistory = new OrderHistory()
			{
				Id = Guid.NewGuid(),
				StatusType = StatusValue,
				TimeStamp = DateTime.Now,
				UpdatedByUserId = UserIdCreateThis,
				OrderId = OrderId,
			};
			await _httpClient.PostAsJsonAsync("https://localhost:7170/api/OrderHistories", orderHistory);
		}

		public async Task Create(Guid UserIdCreateThis, Order order)
		{
			await _httpClient.PostAsJsonAsync("https://localhost:7170/api/Orders", order);
			OrderHistory orderHistory = new OrderHistory()
			{
				Id = Guid.NewGuid(),
				StatusType = "Tạo đơn hàng",
				TimeStamp = order.CreatedDate,
				UpdatedByUserId = UserIdCreateThis,
				OrderId = order.Id,
			};
			await _httpClient.PostAsJsonAsync("https://localhost:7170/api/OrderHistories", orderHistory);
		}

		public async Task Delete(Guid id)
		{
			var response = await _httpClient.GetStringAsync($"https://localhost:7170/api/Orders/{id}");
			var data = JsonConvert.DeserializeObject<Order>(response);
			if (data.TotalPrice == 0) await _httpClient.DeleteAsync($"https://localhost:7170/api/Orders/{id}");
		}

		public async Task<IEnumerable<Order>?> GetAllOrderByUserId(Guid id)
		{
			var response = await _httpClient.GetStringAsync($"https://localhost:7170/api/Orders/UserId/{id}");
			var result = JsonConvert.DeserializeObject<IEnumerable<Order>>(response);
			return result;
		}

		public async Task<IEnumerable<Order>?> GetAllOrdersByStatus()
		{
			var response = await _httpClient.GetStringAsync("https://localhost:7170/api/Orders");
			var result = JsonConvert.DeserializeObject<IEnumerable<Order>>(response);
			return result!=null ? result.OrderBy(x => x.Status) : result;
		}

		public async Task<Order?> GetOrderById(Guid id)
		{
			var response = await _httpClient.GetStringAsync($"https://localhost:7170/api/Orders/{id}");
			var result = JsonConvert.DeserializeObject<Order>(response);
			return result;
		}

		public async Task<IEnumerable<OrderHistory>?> GetOrderHistoriesByOrderId(Guid id)
		{
			var response = await _httpClient.GetStringAsync($"https://localhost:7170/api/OrderHistories/OrderId/{id}");
			var result = JsonConvert.DeserializeObject<IEnumerable<OrderHistory>>(response);
			return result;
		}

		public async Task<IEnumerable<PaymentHistory>?> GetPaymentHistoriesByOrderId(Guid id)
		{
			var response = await _httpClient.GetStringAsync($"https://localhost:7170/api/PaymentHistories/OrderId/{id}");
			var result = JsonConvert.DeserializeObject<IEnumerable<PaymentHistory>>(response);
			return result;
		}

		public async Task Update(Order order)
		{
			await _httpClient.PutAsJsonAsync("https://localhost:7170/api/Orders", order);
		}
	}
}
