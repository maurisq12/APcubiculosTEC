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
        if(ModelState.IsValid){
            Console.WriteLine("oeoeoeoe");


            /*
            if(new LO_Usuario().verificarCorreo(objeto.correo)){
                new LO_Usuario().nuevoUsuario(objeto);
                //falta el if de estudiante o administrador
                return RedirectToAction("Index","Home");
            }
        
            else{
                ModelState.AddModelError("Custom Error","Ya existe un usuario registrado con este correo");
                return View();
            } */
        }

        return View();
    }
}