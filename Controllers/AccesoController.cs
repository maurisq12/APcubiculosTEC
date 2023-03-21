using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CubiculosTEC.Models;
using CubiculosTEC.Logica;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;



namespace CubiculosTEC.Controllers;

public class AccesoController : Controller{

    public IActionResult Index(){
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(CubiculosTEC.Models.Acesso objeto){

        if(ModelState.IsValid){            
            Usuario sesion = new LO_Usuario().encontrarUsuario(objeto.correo,objeto.contrasena);
            if(sesion.nombre!=null){
                var claims = new List<Claim> {
                new Claim(ClaimTypes.Email, objeto.correo),
                new Claim(ClaimTypes.Role, sesion.rol)
            };

            var claimsIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));



            return RedirectToAction("Index","Home");
                
            }
            else{
                ModelState.AddModelError("Custom Error","Credenciales incorrectos");
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