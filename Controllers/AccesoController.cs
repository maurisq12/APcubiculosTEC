using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CubiculosTEC.Models;
using CubiculosTEC.Logica;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using System.Text.RegularExpressions;

namespace CubiculosTEC.Controllers;

public class AccesoController : Controller{

    public IActionResult Index(){
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(CubiculosTEC.Models.Acceso objeto){

        if(ModelState.IsValid){   
            if (Regex.IsMatch(objeto.correo,"[a-z0-9]+@+estudiantec.cr")){      
                Estudiante sesion = new LO_Usuario().encontrarEstudiante(objeto.correo,objeto.contrasena);
                if(sesion.correo!=null){
                    var claims = new List<Claim> {
                    new Claim(ClaimTypes.NameIdentifier, sesion.id.ToString()),
                    new Claim(ClaimTypes.Email, objeto.correo),
                    new Claim(ClaimTypes.Role, "estudiante")
                    };

                    var claimsIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));



                    return RedirectToAction("Index","Cubiculos");
                    
                }
                else{
                    ModelState.AddModelError("Custom Error","Credenciales incorrectos");
                }
                return View();


            }
            else{
                Administrador sesion = new LO_Usuario().encontrarAdmin(objeto.correo,objeto.contrasena);
                if(sesion.correo!=null){
                    var claims = new List<Claim> {
                    new Claim(ClaimTypes.Email, objeto.correo),
                    new Claim(ClaimTypes.Role, "administrador")
                };

                var claimsIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));



                return RedirectToAction("gestEstudiantes","Admin");
                    
                }
                else{
                    ModelState.AddModelError("Custom Error","Credenciales incorrectos");
                }
                return View();

            }
            return View();
        }
        return View();
    }




    public async Task<IActionResult> Salir(){
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index","Home");
    }

    public IActionResult Error(){
        return View();
    }

    

}