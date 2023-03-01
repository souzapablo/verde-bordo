using System.ComponentModel;

namespace VerdeBordo.Core.Enums;

public enum EmbroideryDetails
{
    [Description("Frase")]
    Sentence,
    [Description("Floral")]
    Floral,
    [Description("Frase + floral")]
    SentenceFloral,
    [Description("Pet")]
    Pet,
    [Description("Bebê arco-íris")]
    RainbowBaby
}