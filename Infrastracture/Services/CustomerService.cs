using Dapper;
using Domain.Models;
using Infrastracture.DataContext;

namespace Infrastracture.Services;

public class CustomerService
{
    private readonly DapperContext _db;

    public CustomerService()
    {
        _db = new DapperContext();
    }

    public async Task<List<Customers>> GetCustomersAsync()
    {
        var sql = "select * from Customers";
        var rez = await _db.Connection().QueryAsync<Customers>(sql);
        return rez.ToList();
    }

    public async Task AddCustomerAsync(Customers customers)
    {
        var sql = "insert into Customers(FullName,Email,Address)values (@FullName,@Email,@Address)";
        await _db.Connection().ExecuteAsync(sql, customers);
    }

    public async Task UpdateCustomerAsync(Customers customers)
    {
        var sql = "update Customers set FullName = @FullName,Email = @Email,Address = @Address where id = @id";
        await _db.Connection().ExecuteAsync(sql, customers);
    }

    public async Task DeleteCustomerAsync(int id)
    {
        var sql = "delete from customers where Id = @id";
        await _db.Connection().ExecuteAsync(sql, new { Id = id });
    }

    public async Task<List<Customers>> GetHasOrderCustomerAsync(DateTime from, DateTime to)
    {
        var sql =
            "select distinct c.id,c.FullName from customers as c  join orders as o on c.id = o.customer_id where o.order_date between @from and @to";
        var rez = await _db.Connection().QueryAsync<Customers>(sql, new { From = from, To = to });
        return rez.ToList();
    }
}