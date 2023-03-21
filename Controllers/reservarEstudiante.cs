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
        return View();
    }

}