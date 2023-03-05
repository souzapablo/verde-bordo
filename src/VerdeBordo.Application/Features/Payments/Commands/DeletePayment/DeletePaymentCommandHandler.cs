using MediatR;
using VerdeBordo.Core.Repositories;

namespace VerdeBordo.Application.Features.Payments.Commands.DeletePayment;

public class DeletePaymentCommandHandler : IRequestHandler<DeletePaymentCommand, Unit>
{
    private readonly IPaymentRepository _paymentRepository;

    public DeletePaymentCommandHandler(IPaymentRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }

    public async Task<Unit> Handle(DeletePaymentCommand request, CancellationToken cancellationToken)
    {
        var payment = await _paymentRepository.GetByIdAsync(request.Id);

        if (payment is null)
            throw new Exception("Payment not found");
        
        payment.Delete();

        await _paymentRepository.UpdateAsync(payment);

        return Unit.Value;
    }
}