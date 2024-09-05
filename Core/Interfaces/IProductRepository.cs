using System;
using Core.Entities;

namespace Core.Interfaces;

public interface IProductRepository
{
   Task<IReadOnlyList<Product>> GetProducts(string? brand, string? type);  
   Task<Product?> GetProductByIdAsync(int id);

   Task<IReadOnlyList<string>> GetBrandsAsync();
   Task<IReadOnlyList<string>> GetTypeAsync();

   void AddProduct(Product product);
   void UpdateProduct(Product product);
   void DeleteProduct(Product product);
   bool ProductExists(int Id);
   Task<bool> SaveChangesAsync();
    Task<object?> GetProductsAsync();
    Task<object?> GetProductsAsync(string? brand, string? type);
    Task<object?> GetProductsAsync(string? brand, string? type, string sort);
}
