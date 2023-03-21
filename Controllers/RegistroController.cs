    
    using Microsoft.AspNetCore.Mvc;
using CubiculosTEC.Models;

namespace CubiculosTEC.Controllers;

public class Registro : Controller{

    public IActionResult Index(){
        return View();
    }

    [HttpPost]
    public string completarRegistro()
    {
        string cedula = Request.Form["cedula"].ToString();
        string carne = Request.Form["carne"].ToString();
        string nombre = Request.Form["nombre"].ToString();
        string primerApellido = Request.Form["cedula"].ToString();
        string segundoApellido = Request.Form["segundoApellido"].ToString();
        string edad = Request.Form["edad"].ToString();
        string fechaNacimiento = Request.Form["fechaNacimiento"].ToString();
        string correo = Request.Form["correo"].ToString();
        string pass = Request.Form["pass"].ToString();
        Console.WriteLine(primerApellido);
        return "El número de cédula es"+primerApellido;
        
    }
}