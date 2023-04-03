using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CubiculosTEC.Models;

namespace CubiculosTEC.Controllers;

public class Admin : Controller
{

    public string Index(){
        return "es lo inicial";
    }


    //SET: /Cubi/
    public IActionResult gestEstudiantes(){
        var estudiantes = Estudiante.todosEstudiantes();
        foreach(Estudiante unEs in estudiantes){
            Console.WriteLine(unEs.getNombre());

        }
        ViewBag.Estudiantes = estudiantes;
        return View();
    }
        public IActionResult gestCubiculos(){
        return View();
    }
        public IActionResult gestAsignaciones(){
        return View();
    }
        public IActionResult gestTiempos(){
        return View();
    }

}