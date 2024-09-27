﻿using API.Data;
using API.IRepositories;
using DataProcessing.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class ProductDetailRepos : IProductDetailRepos
    {
        private readonly ApplicationDbContext _context;
        public ProductDetailRepos(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(ProductDetail productDetail)
        {
            if(await GetProductDetailById(productDetail.Id) != null ) throw new DuplicateWaitObjectException($"Product Detail : {productDetail.Id} is existed!");
            await _context.ProductDetails.AddAsync(productDetail);
        }

        public async Task Delete(Guid id)
        {
            var productDetail = await GetProductDetailById(id);
            if (productDetail == null) throw new KeyNotFoundException("Not found this Id!");
            _context.ProductDetails.Remove(productDetail);
        }

        public async Task<List<ProductDetail>> GetAllProductDetail()
        {
            return await _context.ProductDetails.ToListAsync();
        }

        public async Task<ProductDetail> GetProductDetailById(Guid id)
        {
            return await _context.ProductDetails.FindAsync(id);
        }

        public async Task SaveChanges()
        {
             await _context.SaveChangesAsync();
        }

        public async Task Update(ProductDetail productDetail)
        {
            if (await GetProductDetailById(productDetail.Id) == null) throw new KeyNotFoundException("Not found this Id!");
            _context.Entry(productDetail).State = EntityState.Modified;

        }
    }
}