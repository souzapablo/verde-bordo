using System.ComponentModel;

namespace VerdeBordo.Core.Enums;

public enum PaymentMethod
{
    [Description("Pix")]
    Pix,
    [Description("Boleto bancário")]
    Billet,
    [Description("Picpay")]
    Picpay
}