using CarShopFinal.Domain.ValueObjects;

namespace CarShopFinal.Domain.Models;

public class OrderItem
{
    public Guid Id { get; private set; }
    public Money price { get; private set; }

    private OrderItem() { }
    
    public OrderItem(Money price)
    {
        Id = Guid.NewGuid();
        this.price = price;
    }
}