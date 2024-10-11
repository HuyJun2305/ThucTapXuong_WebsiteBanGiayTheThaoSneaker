﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using API.Data;
using DataProcessing.Models;
using View.IServices;
using View.ViewModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace View.Controllers
{
	public class OrdersController : Controller
	{
		private readonly IOrderServices _orderServices;
		private readonly IShippingUnitServices _shippingUnitServices;
		private readonly IVoucherServices _voucherServices;
		public OrdersController(IOrderServices orderServices, IShippingUnitServices shippingUnitServices, IVoucherServices voucherServices)
		{
			_orderServices = orderServices;
			_shippingUnitServices = shippingUnitServices;
			_voucherServices = voucherServices;
		}

		// GET: Orders
		public async Task<IActionResult> Index()
		{
			return View(_orderServices.GetAllOrdersByStatus().Result);
		}

		// GET: Orders/Details/5
		public async Task<IActionResult> Details(Guid id)
		{
			var orderVM = new OrderVM()
			{
				Orders = _orderServices.GetOrderById(id).Result,
				OrderHistories = _orderServices.GetOrderHistoriesByOrderId(id).Result,
				PaymentHistories = _orderServices.GetPaymentHistoriesByOrderId(id).Result,
				OrderDetails = _orderServices.GetAllOrderDetailsByOrderId(id).Result
			};

			return View(orderVM);
		}

		// GET: Orders/Create
		public IActionResult Create()
		{
			ViewData["ShippingUnitID"] = new SelectList(_shippingUnitServices.GetAllShippingUnit().Result, "ShippingUnitID", "Address");
			ViewData["VoucherId"] = new SelectList(_voucherServices.GetAllVouchers().Result, "Id", "Condittion");
			return View();
		}

		// POST: Orders/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		public async Task<IActionResult> Create([Bind("Id,CreatedDate,TotalPrice,PaymentMethod,Status,AddressId,UserId,VoucherId,ShippingUnitID")] Order order)
		{
			var token = HttpContext.Session.GetString("AuthToken");
			var userId = "";
			if (!string.IsNullOrEmpty(token))
			{
				var tokenHandler = new JwtSecurityTokenHandler();
				var jwtToken = tokenHandler.ReadJwtToken(token);

				var claims = jwtToken.Claims.ToList();
				userId = claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
			}
			if (ModelState.IsValid)
			{
				order.Id = Guid.NewGuid();
				await _orderServices.Create(Guid.Parse(userId), order);
				return RedirectToAction(nameof(Index));
			}
			ViewData["ShippingUnitID"] = new SelectList(_shippingUnitServices.GetAllShippingUnit().Result, "ShippingUnitID", "Address", order.ShippingUnitID);
			ViewData["VoucherId"] = new SelectList(_voucherServices.GetAllVouchers().Result, "Id", "Condittion", order.VoucherId);
			return View(order);
		}

		// GET: Orders/Edit/5
		public async Task<IActionResult> Edit(Guid id)
		{
			var order = await _orderServices.GetOrderById(id);
			if (order == null)
			{
				return NotFound();
			}
			ViewData["ShippingUnitID"] = new SelectList(_shippingUnitServices.GetAllShippingUnit().Result, "ShippingUnitID", "Address", order.ShippingUnitID);
			ViewData["VoucherId"] = new SelectList(_voucherServices.GetAllVouchers().Result, "Id", "Condittion", order.VoucherId);
			return View(order);
		}

		// POST: Orders/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(Guid id, [Bind("Id,CreatedDate,TotalPrice,PaymentMethod,Status,AddressId,UserId,VoucherId,ShippingUnitID")] Order order)
		{
			if (id != order.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					await _orderServices.Update(order);
				}
				catch (Exception ex)
				{
					return Problem(ex.Message);
				}
				return RedirectToAction(nameof(Index));
			}
			ViewData["ShippingUnitID"] = new SelectList(_shippingUnitServices.GetAllShippingUnit().Result, "ShippingUnitID", "Address", order.ShippingUnitID);
			ViewData["VoucherId"] = new SelectList(_voucherServices.GetAllVouchers().Result, "Id", "Condittion", order.VoucherId);
			return View(order);
		}

		// GET: Orders/Delete/5
		public async Task<IActionResult> Delete(Guid id)
		{
			if (id == null || _orderServices.GetAllOrdersByStatus() == null)
			{
				return NotFound();
			}

			var order = await _orderServices.GetOrderById(id);
			if (order == null)
			{
				return NotFound();
			}

			return View(order);
		}

		// POST: Orders/Delete/5
		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeleteConfirmed(Guid id)
		{
			try
			{
				await _orderServices.Delete(id);
			}
			catch (Exception ex)
			{
				return Problem(ex.Message);
			}
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> ChangeStatus(Guid id)
		{
			try
			{
				var token = HttpContext.Session.GetString("AuthToken");
				var userId = "";
				if (!string.IsNullOrEmpty(token))
				{
					var tokenHandler = new JwtSecurityTokenHandler();
					var jwtToken = tokenHandler.ReadJwtToken(token);

					var claims = jwtToken.Claims.ToList();
					userId = claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
				}
				await _orderServices.ChangeStatus(Guid.Parse(userId), id);
			}catch (Exception ex)
			{
				return Problem(ex.Message);
			}

			return RedirectToAction("Details", new { id });
		}

		public async Task<IActionResult> BackStatus(Guid id)
		{
			try
			{
				var token = HttpContext.Session.GetString("AuthToken");
				var userId = "";
				if (!string.IsNullOrEmpty(token))
				{
					var tokenHandler = new JwtSecurityTokenHandler();
					var jwtToken = tokenHandler.ReadJwtToken(token);

					var claims = jwtToken.Claims.ToList();
					userId = claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
				}
				await _orderServices.BackStatus(Guid.Parse(userId), id);
			}
			catch (Exception ex)
			{
				return Problem(ex.Message);
			}

			return RedirectToAction("Details", new { id });
		}
	}
}
