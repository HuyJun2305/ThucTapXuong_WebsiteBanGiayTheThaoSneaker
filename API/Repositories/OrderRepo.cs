using API.Data;
using API.IRepositories;
using DataProcessing.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
	public class OrderRepo : IOrderRepo
	{
		private readonly ApplicationDbContext _context;
        public OrderRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Create(Order order)
		{
			if (await GetOrderById(order.Id) != null) throw new DuplicateWaitObjectException("This order already exist!");
			await _context.Orders.AddAsync(order);
		}

		public async Task Delete(Guid id)
		{
			var data = await GetOrderById(id);
			if (data == null) throw new KeyNotFoundException("Not found this Id");
			_context.Orders.Remove(data);
		}

		public async Task<List<Order>> GetAllOrders()
		{
			return await _context.Orders.ToListAsync();
		}

		public async Task<Order?> GetOrderById(Guid id)
		{
			return await _context.Orders.Where(o => o.Id == id)
				.Include(o => o.User)
				.Include(o => o.Voucher)
				.FirstOrDefaultAsync();
		}

		public async Task SaveChanges()
		{
			await _context.SaveChangesAsync();
		}

		public async Task Update(Order order)
		{
			if (await GetOrderById(order.Id) == null) throw new KeyNotFoundException("Not found this Id");
			_context.Entry(order).State = EntityState.Modified;
		}

		public async Task<List<Order>> GetAllOrdersByUserId(Guid id)
		{
			return await _context.Orders.Where(o => o.UserId == id)
				.Include(o => o.User)
				.Include(o => o.Voucher)
				.ToListAsync();
		}
	}

	public class OrderHistoryRepo : IOrderHistoryRepo
	{
		private readonly ApplicationDbContext _context;
        public OrderHistoryRepo(ApplicationDbContext context)
        {
			_context = context;
        }
        public async Task Create(OrderHistory orderHistory)
		{
			if (await GetOrderHistoryById(orderHistory.Id) != null) throw new DuplicateWaitObjectException("This orderhistory already exist!");
			await _context.OrderHistories.AddRangeAsync(orderHistory);
		}

		public async Task Delete(Guid id)
		{
			if (await GetOrderHistoryById(id) == null) throw new KeyNotFoundException("Not found this Id");
			_context.OrderHistories.Remove(GetOrderHistoryById(id).Result);
		}

		public async Task<List<OrderHistory>?> GetAllOrderHistoriesById(Guid id)
		{
			return await _context.OrderHistories.Where(oh => oh.OrderId == id).ToListAsync();
		}

		public async Task<List<OrderHistory>> GetOrderHistories()
		{
			return await _context.OrderHistories
				.Include(oh => oh.Order)
				.ToListAsync();
		}

		public async Task<OrderHistory?> GetOrderHistoryById(Guid id)
		{
			return await _context.OrderHistories.Where(oh => oh.Id == id).Include(oh => oh.Order).FirstOrDefaultAsync();
		}

		public async Task SaveChanges()
		{
			await _context.SaveChangesAsync();
		}

		public async Task Update(OrderHistory orderHistory)
		{
			if (await GetOrderHistoryById(orderHistory.Id) == null) throw new KeyNotFoundException("Not found this Id");
			_context.Entry(orderHistory).State = EntityState.Modified;
		}
	}
}
