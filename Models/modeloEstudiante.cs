namespace CubiculosTEC.Models;

public class Estudiante{

    
    public int cedula;
    public int carne;
    public string nombre;
    public string apellido1;
    public string apellido2;
    public int edad;
    public DateTime fechaNacimiento;
    public string correo;

    public string rol;

    public Estudiante(){
        
    }


    public Estudiante(int pCedula, int pCarne, string pNombre, string pApellido1, string pApellido2, int pEdad, DateTime pFechaNacimiento, string pCorreo){
        cedula=pCedula;
        carne=pCarne;
        nombre=pNombre;
        apellido1=pApellido1;
        apellido2=pApellido2;
        edad=pEdad;
        fechaNacimiento=pFechaNacimiento;
        correo=pCorreo;
    }

    public void setNombre(string pNombre){
        nombre=pNombre;
    }

    
}