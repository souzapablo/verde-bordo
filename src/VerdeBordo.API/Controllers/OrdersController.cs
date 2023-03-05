using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VerdeBordo.Application.Features.Embroideries.Commands.CreateEmbroideiry;
using VerdeBordo.Application.Features.Embroideries.Commands.DeleteEmbroidery;
using VerdeBordo.Application.Features.Orders.Commands.ApproveDraft;
using VerdeBordo.Application.Features.Orders.Commands.CompleteDraft;
using VerdeBordo.Application.Features.Orders.Commands.CompleteEmbroidery;
using VerdeBordo.Application.Features.Orders.Commands.CompleteFinishing;
using VerdeBordo.Application.Features.Orders.Commands.CreateOrder;
using VerdeBordo.Application.Features.Orders.Commands.DeleteOrder;
using VerdeBordo.Application.Features.Orders.Commands.Deliver;
using VerdeBordo.Application.Features.Orders.Commands.ReproveDraft;
using VerdeBordo.Application.Features.Orders.Commands.StartDraft;
using VerdeBordo.Application.Features.Orders.Queries.GetOrderById;
using VerdeBordo.Application.Features.Orders.Queries.GetOrders;
using VerdeBordo.Application.Features.Payments.Commands.CreatePayment;
using VerdeBordo.Application.Features.Payments.Commands.DeletePayment;
using VerdeBordo.Application.Features.Payments.UpdatePayment;
using VerdeBordo.Application.InputModels.Embroideries;
using VerdeBordo.Application.InputModels.Orders;
using VerdeBordo.Application.InputModels.Payments;

namespace VerdeBordo.API.Controllers;

[ApiController]
[Route("api/v1/orders")]
[Authorize]
public class OrdersController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrdersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllOrders()
    {
        var query = new GetOrdersQuery();

        return Ok(await _mediator.Send(query));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetOrderById(Guid id)
    {
        var query = new GetOrderByIdQuery(id);

        return Ok(await _mediator.Send(query));
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderInputModel input)
    {
        var command = new CreateOrderCommand(input.CustomerId, input.DueDate, input.PaymentMethod);

        var id = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetOrderById), new { Id = id }, input);
    }

    [HttpPost("{id:guid}/embroideiry")]
    public async Task<IActionResult> CreateEmbroideiry(Guid id, [FromBody] CreateEmbroideryInputModel input)
    {
        var command = new CreateEmbroideryCommand(
            id, 
            input.Description, 
            input.Details, 
            input.Size, 
            input.Price, 
            input.HasFrame);

        var orderId = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetOrderById), new { Id = orderId }, input);
    }

    [HttpPost("{id:guid}/payment")]
    public async Task<IActionResult> CreatePayment(Guid id, [FromBody] CreatePaymentInputModel input)
    {
        var command = new CreatePaymentCommand(id, input.Amount, input.DueDate);

        var orderId = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetOrderById), new { Id = orderId }, input);
    }

    [HttpPatch("payment/{id:guid}/pay")]
    public async Task<IActionResult> CreatePayment(Guid id)
    {
        var command = new UpdatePaymentCommand(id);

        var orderId = await _mediator.Send(command);

        return NoContent();
    }

    [HttpPatch("{id:guid}/start-draft")]
    public async Task<IActionResult> StartDraft(Guid id)
    {
        var command = new StartDraftCommand(id);

        await _mediator.Send(command);

        return NoContent();
    }

    [HttpPatch("{id:guid}/complete-draft")]
    public async Task<IActionResult> CompleteDraft(Guid id)
    {
        var command = new CompleteDraftCommand(id);

        await _mediator.Send(command);

        return NoContent();
    }    

    [HttpPatch("{id:guid}/approve-draft")]
    public async Task<IActionResult> ApproveDraft(Guid id)
    {
        var command = new ApproveDraftCommand(id);

        await _mediator.Send(command);

        return NoContent();
    }    

    [HttpPatch("{id:guid}/reprove-draft")]
    public async Task<IActionResult> ReproveDraft(Guid id)
    {
        var command = new ReproveDraftCommand(id);

        await _mediator.Send(command);

        return NoContent();
    }   

    [HttpPatch("{id:guid}/complete-embroidery")]
    public async Task<IActionResult> CompleteEmbroidery(Guid id)
    {
        var command = new CompleteEmbroideryCommand(id);

        await _mediator.Send(command);

        return NoContent();
    }      

    [HttpPatch("{id:guid}/complete-finishing")]
    public async Task<IActionResult> CompleteFinishing(Guid id)
    {
        var command = new CompleteFinishingCommand(id);

        await _mediator.Send(command);

        return NoContent();
    } 

    [HttpPatch("{id:guid}/deliver")]
    public async Task<IActionResult> Deliver(Guid id)
    {
        var command = new DeliverCommand(id);

        await _mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteOrder(Guid id)
    {
        var command = new DeleteOrderCommand(id);

        await _mediator.Send(command);

        return NoContent();
    }   

    [HttpDelete("embroidery/{id:guid}")]
    public async Task<IActionResult> DeleteEmbroidery(Guid id)
    {
        var command = new DeleteEmbroideryCommand(id);

        await _mediator.Send(command);

        return NoContent();
    }    

    [HttpDelete("payment/{id:guid}")]
    public async Task<IActionResult> DeletePayment(Guid id)
    {
        var command = new DeletePaymentCommand(id);

        await _mediator.Send(command);

        return NoContent();
    }   
}