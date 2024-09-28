using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.DTO;
using API.Data;
using DataProcessing.Models;
using API.IRepositories;
using API.Repositories;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailController : ControllerBase
    {
        private readonly IProductDetailRepos _productDetailRepos;

        public ProductDetailController (IProductDetailRepos productDetailRepos)
        {
           _productDetailRepos = productDetailRepos;
        }

        // GET: api/ProductDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDetail>>> GetProductDetailsDTO()
        {
                return await  _productDetailRepos.GetAllProductDetail();
        }

        // GET: api/ProductDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDetail>> GetProductDetail(string id)
        {
                return await _productDetailRepos.GetProductDetailById(id);  
        }

        // PUT: api/ProductDetail/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductDetail(string id, ProductDetailDTO productDetailDTO)
        {
            try
            {
                ProductDetail productDetail = new ProductDetail()
                {
                    Id = productDetailDTO.Id,
                    Price = productDetailDTO.Price,
                    Stock = productDetailDTO.Stock,
                    Weight = productDetailDTO.Weight,

                    ProductId = productDetailDTO.ProductId,
                    ColorId = productDetailDTO.ColorId,
                    SizeId = productDetailDTO.SizeId

                };
                await _productDetailRepos.Update(productDetail);
                await _productDetailRepos.SaveChanges();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

            return CreatedAtAction("GetProductDetailDTO", new { id = productDetailDTO.Id }, productDetailDTO);
        }

        // POST: api/ProductDetail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductDetailDTO>> PostProductDetail(ProductDetailDTO productDetailDTO)
        {
            try
            {
                ProductDetail productDetail = new ProductDetail()
                {
                    Id = productDetailDTO.Id,
                    Price = productDetailDTO.Price,
                    Stock = productDetailDTO.Stock,
                    Weight = productDetailDTO.Weight,

                    ProductId = productDetailDTO.ProductId,
                    ColorId = productDetailDTO.ColorId,
                    SizeId = productDetailDTO.SizeId

                };
                await _productDetailRepos.Create(productDetail);
                await _productDetailRepos.SaveChanges();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

            return CreatedAtAction("GetProductDetailDTO", new { id = productDetailDTO.Id }, productDetailDTO);
        }

        // DELETE: api/ProductDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductDetail(string id)
        {
            try
            {
                await _productDetailRepos.Delete(id);
                _productDetailRepos.SaveChanges();
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
            return NoContent();
        }


    }
}
