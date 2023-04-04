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
        ViewBag.Estudiantes = estudiantes;
        return View();
    }
        public IActionResult gestCubiculos(){
        var cubiculos = Cubiculo.cubiculosTodos();
        ViewBag.Cubiculos = cubiculos;
        return View();
    }
        public IActionResult gestAsignaciones(){
        return View();
    }
        public IActionResult gestTiempos(){
        return View();
    }
        public IActionResult editEstudiante(){
        var estudianteEdit = Estudiante.todosEstudiantes()[Int32.Parse(Request.Query["id"])-1];
        Console.WriteLine(estudianteEdit.getNombre());
        Console.WriteLine(estudianteEdit.correo);
        ViewBag.Estudiante = estudianteEdit;


        return View();
    }

}