using ClosedXML.Excel;
using MediatR;
using VerdeBordo.Application.ViewModels.Reports;
using VerdeBordo.Core.Repositories;

namespace VerdeBordo.Application.Features.Reports;

public class GeneratePurchaseReportCommandHandler : IRequestHandler<GeneratePurchaseReportCommand, ReportFileViewModel>
{
    private readonly IPurchaseRepository _purchaseRepository;

    public GeneratePurchaseReportCommandHandler(IPurchaseRepository purchaseRepository)
    {
        _purchaseRepository = purchaseRepository;
    }

    public async Task<ReportFileViewModel> Handle(GeneratePurchaseReportCommand request, CancellationToken cancellationToken)
    {
        var reportData = await _purchaseRepository.GetReportData();

        var worksheetName = $"Saídas VB - {DateTime.Now.ToString("m")}";

        using var workbook = new XLWorkbook();

        var worksheet = workbook.Worksheets.Add(worksheetName);

        var currentRow = 1;
        var currentColumn = 1;

        worksheet.Cell(currentRow, currentColumn++).Value = "Data";
        worksheet.Cell(currentRow, currentColumn++).Value = "Produto";
        worksheet.Cell(currentRow, currentColumn++).Value = "Quantidade";
        worksheet.Cell(currentRow, currentColumn++).Value = "Valor unitário";
        worksheet.Cell(currentRow, currentColumn++).Value = "Frete";
        worksheet.Cell(currentRow, currentColumn++).Value = "Valor total";
        worksheet.Cell(currentRow, currentColumn++).Value = "Fornecedor";

        decimal totalPrice = 0;
        decimal itemPrice = 0;
        var moneyFormat = "[$R$-pt-BR] #,##0.00";

        foreach (var item in reportData)
        {
            itemPrice = item.Price * item.PurchasedAmount + item.Shipment.GetValueOrDefault();
            totalPrice += itemPrice;
            currentRow++;
            currentColumn = 1;
            worksheet.Cell(currentRow, currentColumn++).SetValue(item.PurchaseDate);
            worksheet.Cell(currentRow, currentColumn++).SetValue(item.Description);
            worksheet.Cell(currentRow, currentColumn++).SetValue(item.PurchasedAmount);
            worksheet.Cell(currentRow, currentColumn).Style.NumberFormat.Format = moneyFormat;
            worksheet.Cell(currentRow, currentColumn++).SetValue(item.Price);
            worksheet.Cell(currentRow, currentColumn).Style.NumberFormat.Format = moneyFormat;
            worksheet.Cell(currentRow, currentColumn++).SetValue(item.Shipment.GetValueOrDefault() == 0 ? "N/A" : item.Shipment.GetValueOrDefault());
            worksheet.Cell(currentRow, currentColumn).Style.NumberFormat.Format = moneyFormat;
            worksheet.Cell(currentRow, currentColumn++).SetValue(itemPrice);
            worksheet.Cell(currentRow, currentColumn++).SetValue(item.Name);
        }

        worksheet.Cell(++currentRow, 1).Value = "Gastos totais do período";
        worksheet.Cell(currentRow, 2).Style.NumberFormat.Format = moneyFormat;
        worksheet.Cell(currentRow, 2).SetValue(totalPrice);

        using var stream = new MemoryStream();

        workbook.SaveAs(stream);

        var content = stream.ToArray();

        return new(content, worksheetName, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
    }
}
