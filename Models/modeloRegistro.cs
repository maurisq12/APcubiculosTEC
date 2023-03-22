using System.ComponentModel.DataAnnotations;


namespace CubiculosTEC.Models;

public class Registro{

    [Required (ErrorMessage ="Escriba una cédula")]
    [RegularExpression(@"\d{9}",ErrorMessage ="Escriba una cédula válida.")]
    public string cedula {get;set;}

    [Required (ErrorMessage ="Escriba un número de carné")]
    [RegularExpression(@"\d",ErrorMessage ="Escriba una cédula válida.")]
    public string carne {get;set;}

    [Required (ErrorMessage ="Escriba un nombre")]
    public string nombre {get;set;}

    [Required (ErrorMessage ="Escriba un apellido")]
    public string apellido1 {get;set;}

    [Required (ErrorMessage ="Escriba un apellido")]
    public string apellido2 {get;set;}

    [Required (ErrorMessage ="Escriba dígitos")]
    [RegularExpression(@"\d{2}",ErrorMessage ="Escriba una edad válida.")]
    public string edad {get;set;}

    [Required (ErrorMessage ="Proporcione su fecha de nacimiento")]
    public DateTime fechaNacimiento {get;set;}

    [Required (ErrorMessage ="Proporcione un correo.")]
    [RegularExpression(@"[a-z0-9]+@+(estudiantec.cr|itcr.ac.cr)",ErrorMessage ="Introduzca un correo institucional válido.")]
    public string correo {get;set;}


    [Required (ErrorMessage ="Escriba una contraseña")]
    public string contrasena {get;set;}




}