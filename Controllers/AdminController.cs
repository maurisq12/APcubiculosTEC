using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CubiculosTEC.Models;
using Microsoft.AspNetCore.Authorization;

namespace CubiculosTEC.Controllers;

[Authorize(Roles="administrador")]
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
        Console.WriteLine(estudianteEdit.fechaNacimiento);
        ViewBag.Estudiante = estudianteEdit;
        return View();
    }

        [HttpPost]
        public void editEstudianteconf(){
            Estudiante.editarEstudiante(Request.Form["elNombre"],Request.Form["elApellido1"],Request.Form["elApellido2"],Request.Form["laFecha"],Request.Form["elCorreo"],Request.Form["laContrasena"], Int16.Parse(Request.Form["elEstado"]));
            //return View();

        }

}