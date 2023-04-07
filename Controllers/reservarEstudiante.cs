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

    //SET: /Cubi/
    [HttpPost]
    public IActionResult  reservar(){
        int pIdEstudiante = Int32.Parse(User.Claims.Where(x=> x.Type == ClaimTypes.NameIdentifier).SingleOrDefault().Value);
        var pFechaDeReservacion= DateTime.Now.ToString("yyyy-MM-dd");
        var pIdCubiculo = Request.Form["idCubiculoa"][0];
        var pHoraInicio =  Request.Form["inicio"];
        var pHoraFinal = Request.Form["fin"];
        var pFechaDeUso = Request.Form["date"];

        Console.WriteLine(pIdEstudiante);
        Console.WriteLine(pFechaDeUso);
        Console.WriteLine(pIdCubiculo);
        Console.WriteLine(pHoraInicio);
        Console.WriteLine(pHoraFinal);
        Console.WriteLine(pFechaDeReservacion);



        Cubiculo.reservarCubiculo(5,pIdEstudiante,pFechaDeUso,pHoraInicio,pHoraFinal,pFechaDeReservacion);


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