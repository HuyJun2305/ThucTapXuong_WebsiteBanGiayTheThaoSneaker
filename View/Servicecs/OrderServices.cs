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
			var orderRes = await _httpClient.GetStringAsync($"https://localhost:7170/api/Orders/{OrderId}");
			var orderData = JsonConvert.DeserializeObject<Order>(orderRes);
			var data = JsonConvert.DeserializeObject<IEnumerable<OrderHistory>>(response);
			var StatusValue = "";

			if(data.Where(ph => ph.OrderId == OrderId).Count() == 1) StatusValue = "Tạo đơn hàng";
			else StatusValue = data
				.Where(ph => ph.OrderId == OrderId)
				.OrderByDescending(ph => ph.TimeStamp)
				.Skip(1).FirstOrDefault().StatusType;

			OrderHistory orderHistory = new OrderHistory()
			{
				Id = Guid.NewGuid(),
				StatusType = StatusValue,
				TimeStamp = DateTime.Now,
				UpdatedByUserId = UserIdCreateThis,
				OrderId = OrderId,
			};
			orderData.Status = StatusValue;
			await _httpClient.PutAsJsonAsync($"https://localhost:7170/api/Orders/{OrderId}", orderData);
			await _httpClient.PostAsJsonAsync("https://localhost:7170/api/OrderHistories", orderHistory);
		}

		public async Task ChangeStatus(Guid UserIdCreateThis, Guid OrderId)
		{
			var response = await _httpClient.GetStringAsync($"https://localhost:7170/api/Orders/{OrderId}");
			var data = JsonConvert.DeserializeObject<Order>(response);
			var result = "";
			switch (data.Status.ToString())
			{
				case "Tạo đơn hàng":
					result = "Chờ xác nhận";
					break;
				case "Chờ xác nhận":
					result = "Chờ giao hàng";
					break;
				case "Chờ giao hàng":
					result = "Đang vận chuyển";
					break;
				case "Đang vận chuyển":
					result = "Đã giao hàng";
					break;
				case "Đã giao hàng":
					result = "Hoàn thành";
					break;
			}
			OrderHistory orderHistory = new OrderHistory()
			{
				Id = Guid.NewGuid(),
				StatusType = result,
				TimeStamp = DateTime.Now,
				UpdatedByUserId = UserIdCreateThis,
				OrderId = OrderId,
			};
			data.Status = result;
			await _httpClient.PutAsJsonAsync($"https://localhost:7170/api/Orders/{OrderId}", data);
			await _httpClient.PostAsJsonAsync("https://localhost:7170/api/OrderHistories", orderHistory);
		}

		public async Task Create(Guid UserIdCreateThis, Order order)
		{
			if (order.UserId == null) order.UserId = "Khách lẻ";
			if (order.Status == null) order.Status = "Tạo đơn hàng";
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

		public async Task<IEnumerable<OrderDetail>?> GetAllOrderDetailsByOrderId(Guid id)
		{
			var response = await _httpClient.GetStringAsync($"https://localhost:7170/api/OrderDetails/OrderId/{id}");
			var result = JsonConvert.DeserializeObject<IEnumerable<OrderDetail>>(response);
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
