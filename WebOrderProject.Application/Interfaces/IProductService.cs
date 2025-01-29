using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebOrderProject.Application.DTOs;

namespace WebOrderProject.Application.Interfaces;

public interface IProductService
{
    Task<ProductDto?> GetProductByIdAsync(Guid productId);
    Task<List<ProductDto>> GetAllProductsAsync();
    Task<Guid> CreateProductAsync(CutProductDto productDto);
    Task UpdateProductAsync(CutProductDto productDto, Guid productId);
    Task DeleteProductAsync(Guid productId);
}
