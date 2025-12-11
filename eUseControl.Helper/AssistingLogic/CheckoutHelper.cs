using QRCoder;
using System;
using System.IO;

namespace eUseControl.Helper.AssistingLogic
{
     public class CheckoutHelper
     {
          public byte[] GenerateQrCode(string qrText)
          {
               using (var qrGenerator = new QRCodeGenerator())
               using (var qrData = qrGenerator.CreateQrCode(qrText, QRCodeGenerator.ECCLevel.Q))
               using (var qrCode = new PngByteQRCode(qrData))
               {
                    return qrCode.GetGraphic(20);
               }
          }
     }
}
