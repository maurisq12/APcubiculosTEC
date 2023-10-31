using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CubiculosTEC.Models;
using Microsoft.AspNetCore.Authorization;

namespace CubiculosTEC.Controllers;

[Authorize(Roles = "administrador")]
public class Admin : Controller
{

    //SET: /Cubi/
    public IActionResult gestEstudiantes()
    {
        var estudiantes = Estudiante.todosEstudiantes();
        ViewBag.Estudiantes = estudiantes;
        return View();
    }
    public IActionResult gestCubiculos()
    {
        var cubiculos = Cubiculo.cubiculosTodos();
        ViewBag.Cubiculos = cubiculos;
        return View();
    }
    public IActionResult gestAsignaciones()
    {
        var asignaciones = Reservacion.todasReservaciones();
        ViewBag.Reservas = asignaciones;
        return View();
    }
    public IActionResult gestTiempos()
    {
        var cubiculos = Cubiculo.cubiculosTodos();
        ViewBag.Cubiculos = cubiculos;
        return View();
    }



    public IActionResult editEstudiante()
    {
        var estudianteEdit = Estudiante.unEstudiante((Int32.Parse(Request.Query["id"])));
        estudianteEdit.fechaNacimiento = DateTime.Parse(estudianteEdit.fechaNacimiento).ToString("yyyy-MM-dd");
        ViewBag.Estudiante = estudianteEdit;
        return View();
    }

    public IActionResult editCubiculo()
    {
        var cubiculoEdit = Cubiculo.unCubiculo(Int32.Parse(Request.Query["id"]));
        ViewBag.Cubiculo = cubiculoEdit;
        return View();
    }

    public IActionResult editReserva()
    {
        var reservaEdit = Reservacion.unaReservacion((Int32.Parse(Request.Query["id"]) ));
        reservaEdit.fechaDeUso = DateTime.Parse(reservaEdit.fechaDeUso).ToString("yyyy-MM-dd");
        reservaEdit.fechaDeReservacion = DateTime.Parse(reservaEdit.fechaDeReservacion).ToString("yyyy-MM-dd");
        ViewBag.Reserva = reservaEdit;
        Console.WriteLine(reservaEdit.horaInicio);
        return View();
    }

    [HttpPost]
    public IActionResult editEstudianteconf()
    {
        Estudiante.editarEstudiante(Int32.Parse(Request.Form["laCedula"]), Int32.Parse(Request.Form["elCarne"]), Request.Form["elNombre"], Request.Form["elApellido1"], Request.Form["elApellido2"], Request.Form["laFecha"], Request.Form["elCorreo"], Request.Form["laContrasena"], Int16.Parse(Request.Form["elEstado"]));
        return View("realizadoAdmin");

    }

    [HttpPost]
    public IActionResult editCubiculoconf()
    {
        Cubiculo.editarCubiculo(Int32.Parse(Request.Form["elId"]), Request.Form["elNombre"], Int32.Parse(Request.Form["elEstado"]), Int32.Parse(Request.Form["laCapacidad"]));
        return View("realizadoAdmin");
    }

    [HttpPost]
    public IActionResult editReservaconf()
    {
        Reservacion.modificarReservacion(Int32.Parse(Request.Form["elId"]), Int32.Parse(Request.Form["elIdCubiculo"]), Int32.Parse(Request.Form["elIdEstudiante"]), Request.Form["laFechaDeUso"], Request.Form["laHoraInicio"], Request.Form["laHoraFinal"], Request.Form["laFechaDeReserva"], Request.Form["laConfirmacion"]);
        return View("realizadoAdmin");
    }

    public IActionResult asignacionesEstudiante()
    {
        var asignaciones = Reservacion.reservacionesUsuario(Int32.Parse(Request.Query["id"]));
        Console.WriteLine(asignaciones.Count());
        ViewBag.Reservas = asignaciones;
        return View();
    }

    [HttpPost]
    public IActionResult realizarBloqueo()
    {
        Cubiculo.bloqueoCubiculo(Int32.Parse(Request.Form["elId"]), Request.Form["laFechaDeUso"].ToString(), Request.Form["laHoraInicio"].ToString(), Request.Form["laHoraFinal"].ToString(), DateTime.Now.ToString("yyyy-MM-dd"));
        Console.WriteLine(Request.Form["laHoraInicio"].ToString());
        Console.WriteLine(Request.Form["laHoraFinal"].ToString());
        return View();
    }


    [HttpPost]
    public IActionResult definirHoraMaxima()
    {
        Cubiculo.tiempoMaximoCubiculo(Int32.Parse(Request.Form["elId"]), Request.Form["elTiempoMaximo"].ToString());
        Console.WriteLine(Int32.Parse(Request.Form["elId"]));
        Console.WriteLine(Request.Form["eltiempoMaximo"].ToString());
        return View();
    }

    public IActionResult gestCubiculoTiempo()
    {
        var cubiculoGest = Cubiculo.unCubiculo(Int32.Parse(Request.Query["id"]));
        ViewBag.Cubiculo = cubiculoGest;
        return View();
    }

    [HttpPost]
    public IActionResult cambiarEstado()
    {
        Console.WriteLine(Int32.Parse(Request.Form["elEstado"]));
        int elEstado = Int32.Parse(Request.Form["elEstado"]);
        int elId = Int32.Parse(Request.Form["elId"]);
        Cubiculo.cambiarEstadoCubiculo(elId, elEstado);
        return RedirectToAction("gestTiempos", "Admin");
    }

    public IActionResult eliminarCubiculo()
    {
        int IdCubiculo = Int32.Parse(Request.Form["idEliminar"]);
        ViewBag.eliminado = Cubiculo.eliminarCubiculo(IdCubiculo);
        var cubiculos = Cubiculo.cubiculosTodos();
        ViewBag.Cubiculos = cubiculos;
        return View("gestCubiculos");
    }

    public IActionResult eliminarEstudiante()
    {
        ViewBag.eliminado = Estudiante.eliminarEstudiante(Int32.Parse(Request.Form["idEliminar"]));
        var estudiantes = Estudiante.todosEstudiantes();
        ViewBag.Estudiantes = estudiantes;
        return View("gestEstudiantes");
    }
    public IActionResult eliminarAsignacion(){

        ViewBag.eliminado = Reservacion.eliminarReservacion(Int32.Parse(Request.Form["idEliminar"]));
        var asignaciones = Reservacion.todasReservaciones();
        ViewBag.Reservas = asignaciones;
        return View("gestAsignaciones");
    }

    public IActionResult agregarCubiculo(){
        return View();
    }

    public IActionResult crearCubiculo(){
        Cubiculo.crearCubiculo(Request.Form["elNombre"],Int32.Parse(Request.Form["elEstado"]), Int32.Parse(Request.Form["laCapacidad"]));
        var cubiculos = Cubiculo.cubiculosTodos();
        ViewBag.Cubiculos = cubiculos;
        return View("gestCubiculos");
    }

}