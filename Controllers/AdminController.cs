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
        var cubiculos = Cubiculo.cubiculosTodos();
        ViewBag.Cubiculos = cubiculos;
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
        reservaEdit.fechaDeUso=DateTime.Parse(reservaEdit.fechaDeUso).ToString("yyyy-MM-dd");
        reservaEdit.fechaDeReservacion=DateTime.Parse(reservaEdit.fechaDeReservacion).ToString("yyyy-MM-dd");
        ViewBag.Reserva = reservaEdit;
        Console.WriteLine(reservaEdit.horaInicio);
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
        Reservacion.modificarReservacion(Int32.Parse(Request.Form["elId"]), Int32.Parse(Request.Form["elIdCubiculo"]),Int32.Parse(Request.Form["elIdEstudiante"]),Request.Form["laFechaDeUso"],Request.Form["laHoraInicio"],Request.Form["laHoraFinal"],Request.Form["laFechaDeReserva"],Request.Form["laConfirmacion"]);
        //return View();
    }

    public IActionResult asignacionesEstudiante(){
        var asignaciones = Reservacion.reservacionesUsuario(Int32.Parse(Request.Query["id"]));
        Console.WriteLine(asignaciones.Count());
        ViewBag.Reservas = asignaciones;
        return View();
    }

    public IActionResult realizarBloqueo(){
        Cubiculo.bloqueoCubiculo(Int32.Parse(Request.Form["elIdCubiculo"]),Request.Form["laFechaDeUso"],Request.Form["laHoraInicio"],Request.Form["laHoraFinal"],DateTime.Now.ToString("yyyy-MM-dd"));
        return View();
    }

    public IActionResult definirHoraMaxima(){
        Cubiculo.tiempoMaximoCubiculo(Int32.Parse(Request.Form["elIdCubiculo"]),Request.Form["elTiempoMaximo"]);
        return View();
    }

    public IActionResult gestCubiculoTiempo(){
        var cubiculoGest = Cubiculo.cubiculosTodos()[Int32.Parse(Request.Query["id"])-1];
        ViewBag.Cubiculo = cubiculoGest;
        return View();
    }

    public IActionResult cambiarEstado(){
        Cubiculo.cambiarEstadoCubiculo(Int32.Parse(Request.Query["id"]), Int32.Parse(Request.Form["elEstado"]));
        return View();
    }

    public IActionResult eliminarCubiculo(){
        int IdCubiculo = Int32.Parse(Request.Form["idEliminar"]);
        Cubiculo.eliminarCubiculo(IdCubiculo);
        var cubiculos = Cubiculo.cubiculosTodos();
        ViewBag.Cubiculos = cubiculos;
        return View("gestCubiculos");
    }

    







}