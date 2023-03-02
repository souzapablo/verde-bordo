using MediatR;
using VerdeBordo.Core.Entities;
using VerdeBordo.Core.Repositories;

namespace VerdeBordo.Application.Features.Orders.Commands.CreateOrder;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
{
    private readonly IOrderRepository _oderRepository;
    private readonly ICustomerRepository _customerRepository;

    public CreateOrderCommandHandler(IOrderRepository orderRepository, ICustomerRepository customerRepository)
    {
        _oderRepository = orderRepository;
        _customerRepository = customerRepository;
    }

    public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdAsync(request.CustomerId);

        if (customer is null)
            throw new Exception("Customer not found");
        
        var order = new Order(customer.Id, request.DueDate, request.PaymentMethod);

        await _oderRepository.CreateAsync(order);

        return order.Id;
    }
}