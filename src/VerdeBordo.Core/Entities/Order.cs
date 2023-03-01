using VerdeBordo.Core.Enums;

namespace VerdeBordo.Core.Entities;

public class Order : BaseEntity
{
    public Order() { }
    
    public Order(Guid customerId, Guid embroideryId, DateTime dueDate, decimal? shipment, PaymentMethod paymentMethod)
    {
        CustomerId = customerId;
        EmbroideryId = embroideryId;
        DueDate = dueDate;
        Shipment = shipment;
        PaymentMethod = paymentMethod;
        Status = OrderStatus.Created;

        Payments = new();        
    }

    public Guid CustomerId { get; private set; }
    public Customer Customer { get; private set; }
    public Guid EmbroideryId { get; private set; }
    public Embroidery Embroidery { get; private set; }

    public DateTime DueDate { get; private set; }
    public decimal? Shipment { get; private set; }
    public PaymentMethod PaymentMethod { get; private set; }
    public List<Payment> Payments { get; private set; }
    public OrderStatus Status { get; private set;}

    public decimal GetTotalValue() => Embroidery.Price + Shipment.GetValueOrDefault();

    public void StartDraft()
    {
        if (Status is not OrderStatus.Created)
            throw new Exception("Invalid status");

        Status = OrderStatus.Draft;
        Update();
    }
    public void CompleteDraft()
    {
        if (Status is not OrderStatus.Draft)
            throw new Exception("Invalid status");

        Status = OrderStatus.AwaitingDraftApproval;
        Update();
    }

    public void ApproveDraft()
    {
        if (Status is not OrderStatus.AwaitingDraftApproval)
            throw new Exception("Invalid status");

        Status = OrderStatus.Embroidering;
        Update();
    }

    public void ReproveDraft()
    {
        if (Status is not OrderStatus.AwaitingDraftApproval)
            throw new Exception("Invalid status");

        Status = OrderStatus.Draft;
        Update();
    }

    public void CompleteEmbroidery()
    {
        if (Status is not OrderStatus.Embroidering)
            throw new Exception("Invalid status");

        Status = OrderStatus.Finishing;
        Update();
    }

    public void CompleteFinishing()
    {
        if (Status is not OrderStatus.Finishing)
            throw new Exception("Invalid status");

        Status = OrderStatus.Delivering;
        Update();
    }

    public void Deliver()
    {
        if (Status is not OrderStatus.Delivering)
            throw new Exception("Invalid status");

        Status = OrderStatus.Finished;
        Update();
    }

    public void SetDueDate(DateTime dueDate)
    {
        DueDate = dueDate;
        Update();
    }    
}