using VerdeBordo.Core.Enums;

namespace VerdeBordo.Core.Entities;

public class Embroidery : BaseEntity
{
    public Embroidery() { }
    
    public Embroidery(Guid orderId, string description, EmbroideryDetails details, EmbroiderySize size, decimal price, bool hasFrame)
    {
        OrderId = orderId;
        Description = description;
        Details = details;
        Size = size;
        Price = price;
        HasFrame = hasFrame;
    }

    public Guid OrderId { get; private set; }
    public Order Order { get; private set; }
    public string Description { get; private set; }
    public EmbroideryDetails Details { get; private set; }
    public EmbroiderySize Size { get; private set;}
    public decimal Price { get; private set; }
    public bool HasFrame { get; private set; }
}