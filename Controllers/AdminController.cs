using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CubiculosTEC.Models;
using Microsoft.AspNetCore.Authorization;

namespace CubiculosTEC.Controllers;

[Authorize(Roles="administrador")]
public class Admin : Controller
{

    


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
        var asignaciones = Reservacion.todasReservaciones();
        ViewBag.Reservas = asignaciones;
        return View();
    }
    public IActionResult gestTiempos(){
        return View();
    }
    public IActionResult editEstudiante(){
        var estudianteEdit = Estudiante.todosEstudiantes()[Int32.Parse(Request.Query["id"])-2];
        estudianteEdit.fechaNacimiento=DateTime.Parse(estudianteEdit.fechaNacimiento).ToString("yyyy-MM-dd");
        ViewBag.Estudiante = estudianteEdit;
        return View();
    }

         public IActionResult editCubiculo(){
        var cubiculoEdit = Cubiculo.cubiculosTodos()[Int32.Parse(Request.Query["id"])-1];
        ViewBag.Cubiculo = cubiculoEdit;
        return View();
    }

    public IActionResult editReserva(){
        var reservaEdit = Reservacion.todasReservaciones()[Int32.Parse(Request.Query["id"])-1];
        ViewBag.Reserva = reservaEdit;
        return View();
    }

        [HttpPost]
        public void editEstudianteconf(){
            Estudiante.editarEstudiante(Int32.Parse(Request.Form["laCedula"]),Int32.Parse(Request.Form["elCarne"]),Request.Form["elNombre"],Request.Form["elApellido1"],Request.Form["elApellido2"],Request.Form["laFecha"],Request.Form["elCorreo"],Request.Form["laContrasena"], Int16.Parse(Request.Form["elEstado"]));
            //return View();

        }

        [HttpPost]
        public void editCubiculoconf(){
            Cubiculo.editarCubiculo(Int32.Parse(Request.Form["elId"]),Request.Form["elNombre"],Int32.Parse(Request.Form["elEstado"]),Int32.Parse(Request.Form["laCapacidad"]));
            //return View();
        }

        [HttpPost]
        public void editReservaconf(){
            Cubiculo.editarCubiculo(Int32.Parse(Request.Form["elId"]),Request.Form["elNombre"],Int32.Parse(Request.Form["elEstado"]),Int32.Parse(Request.Form["laCapacidad"]));
            //return View();
        }



}