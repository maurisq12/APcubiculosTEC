using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;

namespace CubiculosTEC.Models;

using System.Drawing;


public class CodigosQR{
    public byte[] crearCodigo(string informacion){

        QRCodeGenerator qrGenerator = new QRCodeGenerator(); 
        QRCodeData qrCodeData = qrGenerator.CreateQrCode(informacion, QRCodeGenerator.ECCLevel.Q);
        BitmapByteQRCode qrCode = new BitmapByteQRCode(qrCodeData);
        byte[] qrCodeAsBitmapByteArr = qrCode.GetGraphic(20);

        return qrCodeAsBitmapByteArr;
    


    }

}