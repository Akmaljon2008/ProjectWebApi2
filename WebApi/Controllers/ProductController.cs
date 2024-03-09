using Domain.Models;
using Infrastracture.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("controller")]

public class ProductController
{
    private readonly ProductService _productService;

    public ProductController()
    {
        _productService = new ProductService();
    }

    [HttpGet("get-products")]
    public async Task<List<Products>> GetProducts()
    {
        return await _productService.GetProducts();
    }

    [HttpPost("add-product0")]
    public async Task AddProduct([FromForm] Products products)
    {
        await _productService.AddProduct(products);
    }

    [HttpPut("update-product")]
    public async Task UpdateProduct([FromForm] Products products)
    {
        await _productService.UpodateProduct(products);
    }

    [HttpDelete("delete-product")]
    public async Task DeleteProduct([FromForm] int id)
    {
        await _productService.DeleteProduct(id);
    }
}