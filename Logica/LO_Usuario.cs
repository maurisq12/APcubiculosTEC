using CubiculosTEC.Models;
using System.Data;
using System.Data.SqlClient;


namespace CubiculosTEC.Logica;

public class LO_Usuario{
    public Usuario encontrarUsuario(string pCorreo, string pContrasena){
        Usuario objeto = new Usuario();

        SQLConexion conex = new SQLConexion();
        SqlConnection conectado=  conex.establecer();

        string query= "SELECT Nombre, correo,contrasena,rol FROM Usuarios WHERE correo=@pCorreo and contrasena = @pContrasena";

        SqlCommand cmd = new SqlCommand(query,conectado);
        cmd.Parameters.AddWithValue("@pCorreo",pCorreo);
        cmd.Parameters.AddWithValue("@pContrasena",pContrasena);

        if (conectado.State != ConnectionState.Open){

            conectado.Close();
            conectado.Open();
        }
        
        using (SqlDataReader dr = cmd.ExecuteReader()){
            while(dr.Read()){
                objeto = new Usuario(){
                    nombre= dr["Nombre"].ToString(),
                    correo= dr["correo"].ToString(),
                    contrasena=dr["contrasena"].ToString(),
                    rol =  dr["rol"].ToString()
                };
            }
        }
        Console.WriteLine(objeto.rol);
        return objeto;  

        
    }
}

    
