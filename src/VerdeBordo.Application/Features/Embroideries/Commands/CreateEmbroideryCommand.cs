using MediatR;
using VerdeBordo.Core.Enums;

namespace VerdeBordo.Application.Features.Embroideries.Commands;

public class CreateEmbroideryCommand : IRequest<Guid>
{
    public CreateEmbroideryCommand(Guid orderId, string description, EmbroideryDetails details, EmbroiderySize size, decimal price, bool hasFrame)
    {
        OrderId = orderId;
        Description = description;
        Details = details;
        Size = size;
        Price = price;
        HasFrame = hasFrame;
    }

    public Guid OrderId { get; }
    public string Description { get; }
    public EmbroideryDetails Details { get; }
    public EmbroiderySize Size { get; }   
    public decimal Price { get; }      
    public bool HasFrame { get; }  
}