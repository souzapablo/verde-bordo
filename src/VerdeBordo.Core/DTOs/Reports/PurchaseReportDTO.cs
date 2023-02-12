namespace VerdeBordo.Application.DTOs.Reports;

public record class PurchaseReportDTO()
{
    public DateTime PurchaseDate { get; }
    public string Description { get; }
    public decimal PurchasedAmount { get; }
    public decimal Price { get; }
    public decimal? Shipment { get; }
    public string Name { get; }

}