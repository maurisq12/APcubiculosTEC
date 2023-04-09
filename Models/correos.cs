using System.Net;
using System.Net.Mail;


namespace CubiculosTEC.Models;

public class Correos{

    string correoAuten = "cubiculosTEC@outlook.com";
    string contraAuten = "proyectoap123";

    public string enviarCorreo(byte[] imagen1, byte[] pdfBytes, string pCorreo){

       MailMessage mensaje = new MailMessage();
        mensaje.From = new MailAddress(correoAuten);
        mensaje.Subject = "Confirmación de cubículo - CubículosTEC";
        mensaje.To.Add(new MailAddress(pCorreo));
        mensaje.Body = @"<html>
        <p>Gracias por confirmar la reservación del cubículo. Se adjunta un PDF con la información del cubículo y un código QR podrá acceder a el cubículo reservado. </p>
        </html>";
        mensaje.IsBodyHtml = true;

        //Se adjunta Codigo QR
        MemoryStream qrStream = new MemoryStream(imagen1);
        qrStream.Position = 0;
        mensaje.Attachments.Add(new Attachment(qrStream,"codigo-qr.png"));

        // Adjunta el PDF al correo
        var pdfStream = new MemoryStream(pdfBytes);
        pdfStream.Position = 0;
        mensaje.Attachments.Add(new Attachment(pdfStream, "datos-cubiculo.pdf"));


        var smtpCliente = new SmtpClient("smtp-mail.outlook.com"){
            Port=587,
            Credentials = new NetworkCredential(correoAuten,contraAuten),
            EnableSsl=true,

        };

        smtpCliente.Send(mensaje);

        return "mensaje enviado";
    }

    public void correoRegistro(Registro objeto){
        MailMessage mensaje = new MailMessage();
        mensaje.From = new MailAddress(correoAuten);
        mensaje.Subject = "Confirmación de cubículo - CubículosTEC";
        mensaje.To.Add(new MailAddress(objeto.correo));
        mensaje.Body = @"<html>
            <body>
            <h2>Bienvenido a CubiculosTEC</h2>
            <p>A continuación los datos del registro para esta cuenta: </p><br>
            <p>Nombre: "+objeto.nombre+" "+objeto.apellido1+" "+objeto.apellido2+" </p>"+
            "<p>Cédula: "+objeto.cedula+"</p>"+
            "<p>Carné: "+objeto.carne+"</p>"+
            "<p>Fecha de nacimiento: "+objeto.fechaNacimiento+"</p>"+
            "<p>Correo electrónico: "+objeto.correo+"</p>"+
            "<p>Contraseña: "+objeto.contrasena+"</p><br>"+
            @"<p>Ahora puedes iniciar sesión y reservar cubículos </p>
            </body>
            </html>";


        mensaje.IsBodyHtml = true;

        var smtpCliente = new SmtpClient("smtp-mail.outlook.com"){
            Port=587,
            Credentials = new NetworkCredential(correoAuten,contraAuten),
            EnableSsl=true,
        };

        smtpCliente.Send(mensaje);
    }




}