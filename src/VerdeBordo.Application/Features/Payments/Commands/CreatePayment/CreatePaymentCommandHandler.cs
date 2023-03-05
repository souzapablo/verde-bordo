using MediatR;
using VerdeBordo.Core.Entities;
using VerdeBordo.Core.Repositories;

namespace VerdeBordo.Application.Features.Payments.Commands.CreatePayment;

public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, Guid>
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IOrderRepository _orderRepository;

    public CreatePaymentCommandHandler(IPaymentRepository paymentRepository, IOrderRepository orderRepository)
    {
        _paymentRepository = paymentRepository;
        _orderRepository = orderRepository;
    }

    public async Task<Guid> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(request.OrderId, x => x.Embroideries);

        if (order is null)
            throw new Exception("Order not found");

        if (!order.Embroideries.Any())
            throw new Exception("Order has no embroidery");

        if (request.Amount > order.GetTotalValue())
            throw new Exception("Payment amount is higher than order total value");
        
        var payment = new Payment(order.Id, request.Amount, request.DueDate);

        await _paymentRepository.CreateAsync(payment);

        return order.Id;
    }
}