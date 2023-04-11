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


        List<int> serviciosReservacion = new List<int>();
        for (int i = 1; i < 7; i++) 
        {
            var pServicio = Request.Form["servicio"+i.ToString()];
            if (pServicio=="on"){
                serviciosReservacion.Add(i);
            }
        }
        //string serviciosEspeciales = string.Join( ", ", serviciosOn);

        // Se reserva el cubículo
        Cubiculo.reservarCubiculo(Int32.Parse(pIdCubiculo),pIdEstudiante,pFechaDeUso,pHoraInicio,pHoraFinal,pFechaDeReservacion);

        //se agregan los servicios
        Reservacion.agregarServicios(serviciosReservacion,Reservacion.utlimaReservacion(pIdEstudiante));
        

        /*
        if(Cubiculo.reservarCubiculo(pIdEstudiante,pFechaDeUso,pIdCubiculo,pHoraInicio,pHoraFinal,pFechaDeReservacion)){
            //mensaje de cubiculoReservado con éxito
        }
        else{
            //mensaje de error, intentar de nuevo
        }*/


        return View();
    }


    

    public string validarReservacion(int pIdCubiculo, string pFechaDeUso, string pHoraInicio, string pHoraFinal){
        
        if(Reservacion.checkReservacion(pIdCubiculo, pFechaDeUso, pHoraInicio, pHoraInicio)){
            return "libre";
        }
        return "ocupado";
    }

    




}