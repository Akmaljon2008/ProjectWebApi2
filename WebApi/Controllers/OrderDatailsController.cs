using Domain.Models;
using Infrastracture.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("controller")]

public class OrderDatailsController
{
    private readonly OrderDatailsService _orderDatailsService;

    public OrderDatailsController()
    {
        _orderDatailsService = new OrderDatailsService();
    }

    [HttpGet("get-orderdatails")]
    public async Task<List<OrderDatails>> GetOrderDatailsAsync()
    {
        return await _orderDatailsService.GetOrderDatailsAsync();
    }

    [HttpPost("add-orderdatail")]
    public async Task AddOrderDatailAsync([FromForm]OrderDatails orderDatails)
    {
        await _orderDatailsService.AddOrderDatailsAsync(orderDatails);
    }

    [HttpPut("update-orderdatails")]
    public async Task UpdateOrderDatailAsync([FromForm] OrderDatails orderDatails)
    {
        await _orderDatailsService.UpdateOrderAsync(orderDatails);
    }

    [HttpDelete("delete-orderdtail")]
    public async Task DeleteOrderDatail([FromForm] int id)
    {
        await _orderDatailsService.DeleteOrderAsync(id);
    }

    [HttpGet("get-orderdatail-by-amount")]
    public async Task<List<OrderDatails>> GetOrderdatailByAmount(decimal amount)
    {
        return await _orderDatailsService.getOrderBySum(amount);
    }
}