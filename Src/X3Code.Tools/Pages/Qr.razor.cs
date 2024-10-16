using Microsoft.AspNetCore.Components;
using QRCoder;

namespace X3Code.Tools.Pages;

//Source: https://github.com/codebude/QRCoder
public partial class Qr : ComponentBase
{
    public string? InputText { get; set; }
    public string? QrCodeAsBase64 { get; set; }

    private void CreateQrCode(string? content)
    {
        if (string.IsNullOrEmpty(content)) return;
        
        var qrGenerator = new QRCodeGenerator();
        var qrCodeData = qrGenerator.CreateQrCode(content, QRCodeGenerator.ECCLevel.Q);
        var qrCode = new Base64QRCode(qrCodeData);
        QrCodeAsBase64 = qrCode.GetGraphic(20);
    }
}