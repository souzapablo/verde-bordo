using VerdeBordo.Core.Enums;

namespace VerdeBordo.Application.InputModels.Embroideries;

public record CreateEmbroideryInputModel(string Description, EmbroideryDetails Details, EmbroiderySize Size, decimal Price, bool HasFrame);