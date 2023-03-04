using MediatR;
using VerdeBordo.Core.Repositories;

namespace VerdeBordo.Application.Features.Payments.UpdatePayment;

public class UpdatePaymentCommandHandler : IRequestHandler<UpdatePaymentCommand, Unit>
{
    private readonly IPaymentRepository _paymentRepository;

    public UpdatePaymentCommandHandler(IPaymentRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }

    public async Task<Unit> Handle(UpdatePaymentCommand request, CancellationToken cancellationToken)
    {
        var payment = await _paymentRepository.GetByIdAsync(request.Id);

        if (payment is null)
            throw new Exception("Payment not found");

        payment.Pay();

        await _paymentRepository.UpdateAsync(payment);

        return Unit.Value;
    }
}