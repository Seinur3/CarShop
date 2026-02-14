using CarShopFinal.Domain.Enums;
using CarShopFinal.Domain.ValueObjects;

namespace CarShopFinal.Domain.Models;

public class PaymentItem
{
    public Guid Id { get; }
    public Money Price { get; }
    public PaymentStatus Status { get; private set; }
    public DateTime PaidAt { get; private set; }
}