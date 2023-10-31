using Microsoft.AspNetCore.Mvc;
using CubiculosTEC.Models;
using CubiculosTEC.Logica;

namespace CubiculosTEC.Controllers;

public class Registro : Controller{
    public IActionResult Index(){
        return View();
    }

    [HttpPost]
    public IActionResult Index(CubiculosTEC.Models.Registro objeto)
    {
        Console.WriteLine(Request.Form["laFechaNacimiento"]);
        objeto.fechaNacimiento= Request.Form["laFechaNacimiento"];
        if(ModelState.IsValid){
            if(new LO_Usuario().verificarCorreo(objeto.correo)){
                new LO_Usuario().nuevoUsuario(objeto);
                new Correos().correoRegistro(objeto);
                return RedirectToAction("Index","Acceso");
            }
        
            else{
                ModelState.AddModelError("Custom Error","Ya existe un usuario registrado con este correo");
                return View();
            }
        }
        else{
            Console.WriteLine("error de datos");
        }

        return View();
    }
}