﻿using DataProcessing.Models;
using MailKit.Search;
using Newtonsoft.Json;
using View.IServices;

namespace View.Servicecs
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly HttpClient _httpClient;
        public ProductDetailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task Create(ProductDetail productDetail)
        {
            await _httpClient.PostAsJsonAsync("https://localhost:7170/api/ProductDetail", productDetail);
        }

        public async Task Delete(string id)
        {
            await _httpClient.DeleteAsync($"https://localhost:7170/api/ProductDetail/{id}");
        }

        public async Task<IEnumerable<ProductDetail>?> GetAllProductDetail()
        {
            var response = await _httpClient.GetStringAsync("https://localhost:7170/api/ProductDetail");
            var productDetails = JsonConvert.DeserializeObject<IEnumerable<ProductDetail>>(response);
            return productDetails;
        }



        public async Task<ProductDetail?> GetProductDetailById(string id)
        {
            var response = await _httpClient.GetStringAsync($"https://localhost:7170/api/ProductDetail/{id}");
            var productDetails = JsonConvert.DeserializeObject<ProductDetail>(response);
            return productDetails;
        }


        




        public async Task Update(ProductDetail productDetail)
        {
            await _httpClient.PutAsJsonAsync($"https://localhost:7170/api/ProductDetail/{productDetail.Id}", productDetail);
        }

        public async Task<List<ProductDetail>> GetFilteredProductDetails( string? searchQuery = null, Guid? colorId = null, Guid? sizeId = null, Guid? categoryId = null, Guid? brandId = null, Guid? soleId = null, Guid? materialId = null)
        {
            // Xây dựng URL cho request
            var url = $"https://localhost:7170/api/ProductDetail/filterAndsearch?";

            // Thêm tham số searchQuery vào URL nếu không null
            if (!string.IsNullOrEmpty(searchQuery))
            {
                url += $"searchQuery={Uri.EscapeDataString(searchQuery)}&";
            }

            // Thêm các tham số vào URL nếu chúng không null
            if (colorId.HasValue)
            {
                url += $"colorId={colorId.Value}&";
            }
            if (sizeId.HasValue)
            {
                url += $"sizeId={sizeId.Value}&";
            }
            if (categoryId.HasValue)
            {
                url += $"categoryId={categoryId.Value}&";
            }
            if (brandId.HasValue)
            {
                url += $"brandId={brandId.Value}&";
            }
            if (soleId.HasValue)
            {
                url += $"soleId={soleId.Value}&";
            }
            if (materialId.HasValue)
            {
                url += $"materialId={materialId.Value}&";
            }

            // Xóa dấu '&' cuối cùng
            url = url.TrimEnd('&');
            // Thực hiện gọi đến API
            var response = await _httpClient.GetStringAsync(url);

            // Deserialize kết quả từ JSON thành danh sách ProductDetail
            var productDetails = JsonConvert.DeserializeObject<IEnumerable<ProductDetail>>(response);

            return productDetails?.ToList(); // Trả về danh sách sản phẩm

        }

        public async Task<ProductDetail> GetProductDetailByProductId(Guid productId)
        {
            var response = await _httpClient.GetStringAsync($"https://localhost:7170/api/ProductDetail/product/{productId}");
            var productDetails = JsonConvert.DeserializeObject<ProductDetail>(response);
            return productDetails;
        }
    }
}
