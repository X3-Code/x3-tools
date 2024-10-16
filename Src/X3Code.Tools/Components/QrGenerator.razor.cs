using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using QRCoder;

namespace X3Code.Tools.Components;

//Source: https://github.com/codebude/QRCoder
public partial class QrGenerator : ComponentBase
{
    private const string InputPlaceHolder = "Enter up to 250 characters";
    private string? InputText { get; set; }
    private string? QrCodeAsBase64 { get; set; }
    private bool IsButtonDisabled { get; set; } = true;

    private void CreateQrCode(string? content)
    {
        if (string.IsNullOrEmpty(content))
        {
            QrCodeAsBase64 = null;
            return;
        }
        
        var qrGenerator = new QRCodeGenerator();
        var qrCodeData = qrGenerator.CreateQrCode(content, QRCodeGenerator.ECCLevel.Q);
        var qrCode = new Base64QRCode(qrCodeData);
        QrCodeAsBase64 = qrCode.GetGraphic(20);
    }

    private void CheckEnter(KeyboardEventArgs e)
    {
        if (e.Key == "Enter" && !string.IsNullOrWhiteSpace(InputText))
        {
            CreateQrCode(InputText);
        }
    }

    private void Clear()
    {
        InputText = null;
        QrCodeAsBase64 = null;
    }
}