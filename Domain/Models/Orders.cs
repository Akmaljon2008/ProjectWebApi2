namespace Domain.Models;

public class Orders
{
    public int Id { get; set; }
    public int Customer_Id { get; set; }
    public DateTime Order_Date { get; set; }
    public decimal TotalAmount { get; set; }
}