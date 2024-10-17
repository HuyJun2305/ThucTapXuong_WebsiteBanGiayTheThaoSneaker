using DataProcessing.Models;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using View.IServices;
using View.Servicecs;

namespace View.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartServices _cartServices;

        public CartController(ICartServices cartServices)
        {
            _cartServices = cartServices;
        }
        public ActionResult Index(Guid cartId)
        {
            var token = HttpContext.Session.GetString("AuthToken");
            Guid userId = Guid.Empty;

            if (!string.IsNullOrEmpty(token))
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadJwtToken(token);

                var claims = jwtToken.Claims.ToList();
                var userIdClaim = claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

                // ép kiểu userid từ string sang guid
                if (Guid.TryParse(userIdClaim, out Guid parsedUserId))
                {
                    userId = parsedUserId;
                }
            }
            // Kiểm tra userId hợp lệ và lấy thông tin giỏ hàng của người dùng
            if (userId != Guid.Empty)
            {
                var cart = _cartServices.GetCartByUserId(userId).Result;

                if (cart != null)
                {
                    return View(_cartServices.GetCartDetailByCartId(cart.Id).Result);
                }
            }
            return View("Error");
        }
        public async Task<IActionResult> AddToCart(CartDetail cartDetail , Guid CartId , string productDetail , int quantity , decimal price)
        {
            try
            {
                cartDetail = new CartDetail()
                {
                    Id = Guid.NewGuid(),
                    Quanlity = quantity,
                    TotalPrice = quantity * price,
                    CartId = CartId,
                    ProductDetailId = productDetail
                };
                await _cartServices.Create(cartDetail);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
            return RedirectToAction("Index","Cart");
        }
    }
}
