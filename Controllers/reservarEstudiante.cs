using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CubiculosTEC.Models;

namespace CubiculosTEC.Controllers;

public class Cubiculos : Controller
{

    public string Index(){
        return "es lo inicial";
    }


    //SET: /Cubi/
    public IActionResult reservar(){
        var cubiculos= Cubiculo.cubiculosDisponibles();

        for(int i=0;i<cubiculos.Count;i++)
        {
        Console.WriteLine("ID: "+cubiculos[i].getId().ToString()+" Nombre: "+cubiculos[i].getNombre()+ " Capacidad: "+cubiculos[i].getCapacidad());
        }
        return View();
    }

}