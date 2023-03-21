namespace CubiculosTEC.Models;

public class Estudiante{

    private int IDEstudiante;
    private int cedula;
    private int carne;
    private string nombre;
    private string apellido1;
    private string apellido2;
    private int edad;
    private DateTime fechaNacimiento;
    private string correo;


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
}