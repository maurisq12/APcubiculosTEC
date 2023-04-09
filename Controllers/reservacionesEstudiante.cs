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

    

    public IActionResult confirmar(){
        int pIdReservacion=Int32.Parse(Request.Query["id"]);
        var reserva = Reservacion.unaReservacion(pIdReservacion);
        Reservacion.confirmarReservacion(pIdReservacion);
        //Datos para el correo
        string datosQR = "ID del cubiculo: "+reserva.idCubiculo+",ID del estudiante: "+ reserva.idEstudiante+",Fecha de reservacion: "+ reserva.fechaDeUso;
        List<Object> datosPDF = new List<Object> {reserva.idEstudiante,reserva.fechaDeUso,reserva.idCubiculo,reserva.horaInicio,reserva.horaFinal};
       
        //Envio de correo
        Models.CodigosQR cqr= new CodigosQR();
        byte[] imagenQR = cqr.crearCodigo(datosQR);
        Models.Pdfs pdfs = new Pdfs();
        byte[] pdfsByte = pdfs.crear(datosPDF,Reservacion.obtenerServicios(pIdReservacion));
        Models.Correos correo = new Correos();
        var elEstudiante= Estudiante.unEstudiante(reserva.idEstudiante);
        correo.enviarCorreo(imagenQR,pdfsByte,elEstudiante.correo);


        return View();
    }



}