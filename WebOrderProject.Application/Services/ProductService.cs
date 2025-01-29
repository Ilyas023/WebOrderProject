using WebOrderProject.Application.DTOs;
using WebOrderProject.Application.Exceptions;
using WebOrderProject.Application.Interfaces;
using WebOrderProject.Domain.Models;
using WebOrderProject.Infrastructure.Persistence.Repositories;

namespace WebOrderProject.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Guid> CreateProductAsync(CutProductDto productDto)
    {
        var product = new Product
        {
            Name = productDto.Name,
            Price = productDto.Price,
            Quantity = productDto.Quantity,
        };

        await _productRepository.AddAsync(product);
        return product.ProductId;
    }

    public async Task DeleteProductAsync(Guid productId)
    {
        var product = await _productRepository.GetByIdAsync(productId);
        if (product == null)
            throw new NotFoundException($"Product with ID {productId} not found.");

        await _productRepository.DeleteAsync(productId);
    }

    public async Task<List<ProductDto>> GetAllProductsAsync()
    {
        var products = await _productRepository.GetAllAsync();
        return products.Select(product => new ProductDto
        {
            ProductId = product.ProductId,
            Name = product.Name,
            Price = product.Price,
            Quantity = product.Quantity,
        }).ToList();
    }

    public async Task<ProductDto?> GetProductByIdAsync(Guid productId)
    {
        var product = await _productRepository.GetByIdAsync(productId);
        if (product == null)
            throw new NotFoundException($"Product with ID {productId} not found.");

        return new ProductDto
        {
            ProductId = product.ProductId,
            Name = product.Name,
            Price = product.Price,
            Quantity = product.Quantity,
        };
    }

    public async Task UpdateProductAsync(CutProductDto productDto, Guid productId)
    {
        var product = await _productRepository.GetByIdAsync(productId);
        if (product == null)
            throw new NotFoundException($"Product with ID {productId} not found.");

        product.Name = productDto.Name;
        product.Price = productDto.Price;
        product.Quantity = productDto.Quantity;

        await _productRepository.UpdateAsync(product);
    }
}
