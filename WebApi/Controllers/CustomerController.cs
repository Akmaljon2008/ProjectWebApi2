using Domain.Models;
using Infrastracture.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("controller")]
public class CustomerController : ControllerBase
{
    private readonly CustomerService _customerService;

    public CustomerController()
    {
        _customerService = new CustomerService();
    }

    [HttpGet("get-customers")]
    public async Task<List<Customers>> GetCustomersAsync()
    {
        return await _customerService.GetCustomersAsync();
    }

    [HttpPost("add-customer")]
    public async Task AddCustomerAsync([FromForm] Customers customers)
    {
        await _customerService.AddCustomerAsync(customers);
    }

    [HttpPut("update-customer")]
    public async Task UpdateCustomerAsync([FromForm] Customers customers)
    {
        await _customerService.UpdateCustomerAsync(customers);
    }

    [HttpDelete("delete-customer/{id}")]
    public async Task DeleteCustomerAsync(int id)
    {
        await _customerService.DeleteCustomerAsync(id);
    }

    [HttpGet("get-has-order-customers")]
    public async Task<List<Customers>> GetHasOrderCustomerAsync(DateTime from, DateTime to)
    {
        return await _customerService.GetHasOrderCustomerAsync(from, to);
    }
    

}