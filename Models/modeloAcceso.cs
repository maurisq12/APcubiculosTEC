using System.ComponentModel.DataAnnotations;


namespace CubiculosTEC.Models;



public class Acesso{

    [Required (ErrorMessage ="Proporcione un correo.")]
    [RegularExpression(@"[a-z0-9]+@+(estudiantec.cr|itcr.ac.cr)",ErrorMessage ="Introduzca un correo institucional válido.")]

    public string correo {get;set;}

    [Required (ErrorMessage ="Escriba una contraseña")]
    public string contrasena {get;set;}
}