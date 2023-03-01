namespace VerdeBordo.Core.Entities;

public class Payment : BaseEntity
{
    public Payment() { }

    public Payment(Guid orderId, decimal amount, DateTime dueDate)
    {
        OrderId = orderId;
        Amount = amount;
        DueDate = dueDate;
    }

    public Guid OrderId { get; private set; }
    public Order Order { get; private set; }
    public DateTime DueDate { get; private set; }
    public DateTime? PaymentDate { get; private set; }
    public decimal Amount { get; private set; }
    public bool HasPaid { get; private set; }

    public void Pay()
    {
        if (HasPaid)
            throw new Exception("Payment already processed");
        
        PaymentDate = DateTime.Now;
        HasPaid = true;
        Update();
    }
}