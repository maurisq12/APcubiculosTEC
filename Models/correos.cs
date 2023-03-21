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
        <img src= "+cuerpo+" width=\"300\" height=\"300\"/></html>";
        mensaje.IsBodyHtml = true;

        var smtpCliente = new SmtpClient("smtp-mail.outlook.com"){
            Port=587,
            Credentials = new NetworkCredential(correoAuten,contraAuten),
            EnableSsl=true,

        };

        smtpCliente.Send(mensaje);

        return "mensaje enviado";
    

    }




}