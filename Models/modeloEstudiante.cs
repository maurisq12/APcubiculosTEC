using System.Data.SqlClient;

namespace CubiculosTEC.Models;

public class Estudiante{

    public int id;
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

    public static Boolean editarEstudiante(int pIdEstudiante, int pCedula, int pCarne, string pNombre, string pApellido1, string pApellido2, int pEdad, DateTime pFechaNacimiento, string pCorreo, string pContrasena){

        SQLConexion conex = new SQLConexion();
        SqlConnection conectado=  conex.establecer();

        string query= "editarEstudiante @pCedula, @pCarne, @pNombre, @pApellido1, @pApellido2, @pEdad, @pFechaNacimiento, @pCorreo, @pContrasena;";

        SqlCommand cmd = new SqlCommand(query,conectado);
        cmd.Parameters.AddWithValue("@pIdEstudiante",pIdEstudiante);
        cmd.Parameters.AddWithValue("@pCedula",pCedula);
        cmd.Parameters.AddWithValue("@pCarne",pCarne);
        cmd.Parameters.AddWithValue("@pNombre",pNombre);
        cmd.Parameters.AddWithValue("@pApellido1",pApellido1);
        cmd.Parameters.AddWithValue("@pApellido2",pApellido2);
        cmd.Parameters.AddWithValue("@pEdad",pEdad);
        cmd.Parameters.AddWithValue("@pFechaNacimiento",pFechaNacimiento);
        cmd.Parameters.AddWithValue("@pCorreo",pCorreo);
        cmd.Parameters.AddWithValue("@pContrasena",pContrasena);
        
        using (SqlDataReader dr = cmd.ExecuteReader()){
            while(dr.Read()){
                Estudiante objeto = new Estudiante(){
                    nombre=(dr["nombre"].ToString())
                };
            }
        }
        conectado.Close();
        return true;
    }

    public static Boolean eliminarEstudiante(int pIdEstudiante){

        SQLConexion conex = new SQLConexion();
        SqlConnection conectado=  conex.establecer();

        string query= "eliminarEstudiante @pIdEstudiante;";

        SqlCommand cmd = new SqlCommand(query,conectado);
        cmd.Parameters.AddWithValue("@pIdEstudiante",pIdEstudiante);
        
        using (SqlDataReader dr = cmd.ExecuteReader()){
            while(dr.Read()){
                Estudiante objeto = new Estudiante(){
                    nombre=(dr["nombre"].ToString())
                };
            }
        }
        conectado.Close();
        return true;
    }

    

    
}