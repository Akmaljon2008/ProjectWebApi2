using Dapper;

namespace Infrastracture.Services;
using Domain.Models;
using Infrastracture.DataContext;
public class ProductService
{
    private readonly DapperContext _db;

    public ProductService()
    {
        _db = new DapperContext();
    }

    public async Task<List<Products>> GetProducts()
    {
        var sql = "select * from Products";
        var rez = await _db.Connection().QueryAsync<Products>(sql);
        return rez.ToList();
    }

    public async Task AddProduct(Products products)
    {
        var sql = "insert into Products(Product_Name,Price,Stock_Quantity)values (@Product_Name,@Price,@Stock_Quantity)";
        await _db.Connection().ExecuteAsync(sql, products);
    }

    public async Task UpodateProduct(Products products)
    {
        var sql = "update Products set Product_Name = @Product_Name,Price = @Price,Stock_Quantity = @Stock_Quantity where id = @id";
        await _db.Connection().ExecuteAsync(sql, products);
    }

    public async Task DeleteProduct(int id)
    {
        var sql = "delete from Products where Id = @id";
        await _db.Connection().ExecuteAsync(sql, new { Id = id });
    }
}