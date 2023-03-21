using QRCoder;
using System.Drawing;

namespace CubiculosTEC.Models;

public class CodigosQR{
    public  string crearCodigo(){

    QRCodeGenerator qrGenerador = new QRCodeGenerator();
    QRCodeData qrCodeData = qrGenerador.CreateQrCode("Un saludito para mi amigo Retex28", QRCodeGenerator.ECCLevel.Q);


    
    BitmapByteQRCode bitmapByteQRCode = new BitmapByteQRCode(qrCodeData);
    var bitMap = bitmapByteQRCode.GetGraphic(20);

    using var ms = new MemoryStream();
    ms.Write(bitMap);
    byte [] byteImage = ms.ToArray();
    return Convert.ToBase64String(byteImage);
    
    }
}