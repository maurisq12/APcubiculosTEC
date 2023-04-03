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
        Console.WriteLine(cubiculos[1].getId());
        ViewBag.Cubiculos = cubiculos;
        return View();
    }


    public IActionResult reservari(){
        return View();
    }

    


    //SET: /Cubi/
    [HttpPost]
    public IActionResult  reservaria(string fname){
        int pIdEstudiante = Int32.Parse(User.Claims.Where(x=> x.Type == ClaimTypes.NameIdentifier).SingleOrDefault().Value);
        var pFechaDeUso= DateTime.Now.ToString("HH:mm:ss tt");
        //var pIdCubiculo = agarrar id cubiculo
        //var pHoraInicio =  agarrar hora inicio
        //var pHoraFinal = agarrar hora final
        //var pFechaDeReservacion = agarrar hora final

/*
        if(Cubiculo.reservarCubiculo(pIdEstudiante,pFechaDeUso,pIdCubiculo,pHoraInicio,pHoraFinal,pFechaDeReservacion)){
            //mensaje de cubiculoReservado con éxito
        }
        else{
            //mensaje de error, intentar de nuevo
        }*/


        return View("reservaria");
    }

    




}