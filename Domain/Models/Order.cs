using CarShopFinal.Domain.Enums;
using CarShopFinal.Domain.ValueObjects;

namespace CarShopFinal.Domain.Models;

public class Order : AggregateRoot
{
    public Guid CustomerId { get; private set; }
    public OrderStatus Status { get; private set; }
    
    private readonly List<OrderItem> _orderItems = new ();
    private readonly List<PaymentItem> _paymentItems = new ();
    
    public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();
    public IReadOnlyCollection<PaymentItem> PaymentItems => _paymentItems.AsReadOnly();
    
    private Order() { }
    
    public Order(Guid customerId)
    {
        Id = Guid.NewGuid();
        CustomerId = customerId;
        Status = OrderStatus.Pending;
        
        SetCreatedAt();
    }

    public void AddItem(Guid CarId, Money Price)
    {
        if (Status != OrderStatus.Pending)
        {
            throw new InvalidOperationException("Cannot add an order to a pending order");
        }
    }

    public Money GetTotal()
    {
        var totalAmount = _orderItems.Sum(i=>i.price.Amount); 
        //return _orderItems.Select(i => i.price).Aggregate((total, price) => total.Amount + price.Amount);
        //TODO: LINQ
        return new Money(totalAmount , "USD");
    }

    public void Cancel()
    {
        if (Status == OrderStatus.Delivered)
        {
            throw new InvalidOperationException("Delivered orders can not be cancelled.");
        }
        
        Status = OrderStatus.Canceled;
        SetUpdatedAt();
    }

    public void MArkUsPaid()
    {
        if (Status != OrderStatus.Reserved)
        {
            throw new InvalidOperationException($"Order with status {Status} cannot be marked as paid.");
        }
        // TODO: Implement error handler
        Status = OrderStatus.Paid;
        SetUpdatedAt();
    }
    
    public void Payment(PaymentItem paymentItem)
    {
        if (Status != OrderStatus.Paid)
        {
            throw new InvalidOperationException("Only paid orders can be processed for payment.");
        }
        
        _paymentItems.Add(paymentItem);
    }
    
    
}