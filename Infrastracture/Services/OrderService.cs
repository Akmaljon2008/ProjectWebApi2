using Dapper;

namespace Infrastracture.Services;
using Domain.Models;
using Infrastracture.DataContext;
public class OrderService
{
    private readonly DapperContext _db;

    public OrderService()
    {
        _db = new DapperContext();
    }

    public async Task<List<Orders>> GetOrdersAsync()
    {
        var sql = "select * from Orders";
        var rez = await _db.Connection().QueryAsync<Orders>(sql);
        return rez.ToList();
    }

    public async Task AddOrderAsync(Orders orders)
    {
        var sql = "insert into Orders(Customer_Id,Order_Date,TotalAmount)values (@Customer_Id,@Order_Date,@TotalAmount)";
        await _db.Connection().ExecuteAsync(sql, orders);
    }

    public async Task UpdateOrderAsync(Orders orders)
    {
        var sql = "update Orders set Order_Id = @Order_Id,Order_Date = @Order_Date,TotalAmount = @TotalAmount where id = @id";
        await _db.Connection().ExecuteAsync(sql, orders);
    }

    public async Task DeleteOrderAsync(int id)
    {
        var sql = "delete from Orders where Id = @id";
        await _db.Connection().ExecuteAsync(sql, new { Id = id });
    }

    public async Task<List<OrderDatails>> GetSumOfOrdersAsync()
    {
        var sql =
            "select p.id,p.product_name,SUM(od.quantity) as total_quantity from products as p join orderDatails as od ON p.id = od.productid group by p.id,p.product_name;";
        var rez = await _db.Connection().QueryAsync<OrderDatails>(sql);
        return rez.ToList();
    }
}