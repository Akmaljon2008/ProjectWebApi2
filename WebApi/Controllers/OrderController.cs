using Domain.Models;
using Infrastracture.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("controller")]

public class OrderController
{
    private readonly OrderService _orderService;

    public OrderController()
    {
        _orderService = new OrderService();
    }

    [HttpGet("get-orders")]
    public async Task<List<Orders>> GetOrdersAsync()
    {
        return await _orderService.GetOrdersAsync();
    }

    [HttpPost("add-order")]
    public async Task AddOrderAsync([FromForm] Orders orders)
    {
        await _orderService.AddOrderAsync(orders);
    }

    [HttpPut("update-order")]
    public async Task UpdateOrderAsync([FromForm] Orders orders)
    {
        await _orderService.UpdateOrderAsync(orders);
    }

    [HttpDelete("delete-order")]
    public async Task DeleteOrderAsync([FromForm] int id)
    {
        await _orderService.DeleteOrderAsync(id);
    }
}