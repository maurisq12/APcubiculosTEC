using System.Net;
using System.Net.Mail;


namespace CubiculosTEC.Models;

public class Correos{

    string correoAuten = "cubiculosTEC@outlook.com";
    string contraAuten = "proyectoap123";

    public string enviarCorreo(string cuerpo){

        MailMessage mensaje = new MailMessage();
        mensaje.From = new MailAddress(correoAuten);
        mensaje.Subject = "Confirmación de cubículo - CubículosTEC";
        mensaje.To.Add(new MailAddress("maurisq@hotmail.com"));
        mensaje.Body = @"<html>
        <p>Gracias por confirmar la reservación del cubículo. Con el siguiente código QR puede acceder a este en horario de su reservación </p>
        <img src= "+cuerpo+"></html>";
        mensaje.IsBodyHtml = true;

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