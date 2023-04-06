using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CubiculosTEC.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data.SqlClient;
using System.Security.Claims;

namespace CubiculosTEC.Controllers;

[Authorize(Roles="estudiante")]

public class Reservas : Controller
{

    public IActionResult Index(){
        return View();
        
    }

    

    //SET: /Cubi/
    public IActionResult misReservaciones(){
        int pIdEstudiante = Int32.Parse(User.Claims.Where(x=> x.Type == ClaimTypes.NameIdentifier).SingleOrDefault().Value);
        List<Reservacion> reservasEstudiante = Reservacion.reservacionesUsuario(pIdEstudiante);
        ViewBag.Reservas =reservasEstudiante;
        Console.WriteLine("Estudiante: "+reservasEstudiante[0].idEstudiante);
        Console.WriteLine("hay: "+reservasEstudiante.Count() );
        Console.WriteLine("Reservacion numero: "+reservasEstudiante[0].idReservacion);
        return View();        
    }

    public string confirmando(){
        //var idReservacion= agarrar el id
        Models.CodigosQR miQR = new CodigosQR();
        string elcodigo64 = miQR.crearCodigo();
        string codigoListo = "data:image/png;charset=utf-8;base64,"+elcodigo64;
        ViewData["Imagen"]= codigoListo;
        Models.Pdfs nuevoPDF = new Pdfs();
        nuevoPDF.crear();
        //envio de correo con confirmación
        Models.Correos servCorreo = new Correos();
        servCorreo.enviarCorreo(codigoListo);
        return "listo";
    }

}