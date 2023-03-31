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