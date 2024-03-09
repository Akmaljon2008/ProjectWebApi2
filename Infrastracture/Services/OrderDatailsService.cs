using Dapper;

namespace Infrastracture.Services;
using Domain.Models;
using Infrastracture.DataContext;
public class OrderDatailsService
{
    private readonly DapperContext _db;

    public OrderDatailsService()
    {
        _db = new DapperContext();
    }

    public async Task<List<OrderDatails>> GetOrderDatailsAsync()
    {
        var sql = "SELECT o.id,p.product_name,od.quantity,od.unitprice FROM orders o JOIN OrderDatails as od ON o.id = od.orderid JOIN products p ON od.productid = p.id;\n";
        var rez = await _db.Connection().QueryAsync<OrderDatails>(sql);
        return rez.ToList();
    }

    public async Task AddOrderDatailsAsync(OrderDatails orderDatails)
    {
        var sql = "insert into OrderDatails(Order_Id,ProductId,Quantity,UnitPrice)values (@Order_Id,@ProductId,@Quantity,@UnitPrice)";
        await _db.Connection().ExecuteAsync(sql, orderDatails);
    }

    public async Task UpdateOrderAsync(OrderDatails orderDatails)
    {
        var sql = "update OrderDatails set Order_Id = @Order_Id,ProductId = @ProductId,Quantity = @Quantity,UnitPrice = @UnitPrice where id = @id";
        await _db.Connection().ExecuteAsync(sql, orderDatails);
    }

    public async Task DeleteOrderAsync(int id)
    {
        var sql = "delete from OrderDatails where Id = @id";
        await _db.Connection().ExecuteAsync(sql, new { Id = id });
    }

    public async Task<List<OrderDatails>> getOrderBySum(decimal amount)
    {
        var sql =
            "select o.id,c.FullName,o.order_date,SUM(od.quantity * od.unitprice) as total_order_amount from orders o join OrderDatails od on o.id = od.orderid join customers c on o.customer_id = c.id group by o.id,c.FullName,o.order_date having SUM(od.quantity * od.unitprice) > @amount";
        var rez = await _db.Connection().QueryAsync<OrderDatails>(sql, new { Amount = amount });
        return rez.ToList();
    }
}