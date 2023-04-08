using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CubiculosTEC.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System.Data.SqlClient;

namespace CubiculosTEC.Controllers;

[Authorize(Roles="estudiante")]

public class Cubiculos : Controller
{

    public IActionResult Index(){
        var cubiculos= Cubiculo.cubiculosDisponibles();

        ViewBag.Cubiculos = cubiculos;

        return View();
    }

    //SET: /Cubi/
    public IActionResult filtrarFecha() {
        var pHoraInicio =  Request.Form["filtroInicio"];
        var pHoraFinal = Request.Form["filtroFin"];
        var pFecha = Request.Form["filtroDate"];

        Console.WriteLine(pHoraInicio);
        Console.WriteLine(pHoraFinal);
        Console.WriteLine(pFecha);
        var cubiculos= Cubiculo.filtrarXFechaCubiculo(pFecha,pHoraInicio,pHoraFinal);

        ViewBag.Cubiculos = cubiculos;

        return View("Index");
    
    }
    [HttpPost]
    public IActionResult  reservar(){
        // Parseo de los datos
        int pIdEstudiante = Int32.Parse(User.Claims.Where(x=> x.Type == ClaimTypes.NameIdentifier).SingleOrDefault().Value);
        var pFechaDeReservacion = DateTime.Now.ToString("yyyy-MM-dd");
        var pIdCubiculo = Request.Form["idCubiculoa"][0];
        var pHoraInicio =  Request.Form["inicio"];
        var pHoraFinal = Request.Form["fin"];
        var pFechaDeUso = Request.Form["date"];

        List<String> serviciosOn = new List<String>();
        string[] servicios = {"JAWS","NVDA 2","Lanbda 1.4","Teclado especial","Línea Braille","Impresora Fuse"};
        for (int i = 1; i < 7; i++) 
        {
            var pServicio = Request.Form["servicio"+i.ToString()];
            if (pServicio=="on"){
                serviciosOn.Add(servicios[i-1]);
            }
        }
        string serviciosEspeciales = string.Join( ", ", serviciosOn);

        
        // Se reserva el cubículo
        Cubiculo.reservarCubiculo(Int32.Parse(pIdCubiculo),pIdEstudiante,pFechaDeUso,pHoraInicio,pHoraFinal,pFechaDeReservacion);
        
        //Datos para el correo
        string datosQR = "ID del cubiculo: "+pIdCubiculo+",ID del estudiante: "+ pIdEstudiante+",Fecha de reservacion: "+ pFechaDeUso;
        List<Object> datosPDF = new List<Object> {pIdEstudiante,pFechaDeUso,pIdCubiculo,pHoraInicio,pHoraFinal};
       
        //Envio de correo
        Models.CodigosQR cqr= new CodigosQR();
        byte[] imagenQR = cqr.crearCodigo(datosQR);
        Models.Pdfs pdfs = new Pdfs();
        byte[] pdfsByte = pdfs.crear(datosPDF,serviciosOn);
        Models.Correos correo = new Correos();
        correo.enviarCorreo(imagenQR,pdfsByte);

        //Console.WriteLine(pIdEstudiante);
        //Console.WriteLine(pHoraInicio);


/*
        if(Cubiculo.reservarCubiculo(pIdEstudiante,pFechaDeUso,pIdCubiculo,pHoraInicio,pHoraFinal,pFechaDeReservacion)){
            //mensaje de cubiculoReservado con éxito
        }
        else{
            //mensaje de error, intentar de nuevo
        }*/


        return View("Index");
    }

    




}