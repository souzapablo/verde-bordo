using System.ComponentModel;

namespace VerdeBordo.Core.Enums;

public enum OrderStatus
{
    [Description("Criado")]
    Created,
    [Description("Rascunho")]
    Draft,
    [Description("Aguardando aprovação")]
    AwaitingDraftApproval,
    [Description("Bordando")]
    Embroidering,
    [Description("Acabamento")]
    Finishing,
    [Description("Entrega")]
    Delivering,
    [Description("Finalizado")]
    Finished   
}