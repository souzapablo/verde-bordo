using MediatR;
using VerdeBordo.Application.ViewModels.Reports;

namespace VerdeBordo.Application.Features.Reports;

public class GeneratePurchaseReportCommand : IRequest<ReportFileViewModel>
{
}
