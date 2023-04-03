using System.Data;
using System.Data.SqlClient;

namespace CubiculosTEC.Models;

public class Reservacion{

    public int idEstudiante;
    public int idCubiculo;
    public DateTime fechaDeUso;
    public DateTime horaInicio;
    public DateTime horaFinal;
    public DateTime confirmacion;
    public DateTime fechaDeReservacion;

    public int idReservacion;




    public Reservacion(){

    }

    public static List<Reservacion> reservacionesUsuario(int pIdUsuario){
        List<Reservacion> todasReservaciones = new List<Reservacion>();

        SQLConexion conex = new SQLConexion();
        SqlConnection conectado=  conex.establecer();

        string query= "SELECT idCubiculo, idEstudiante, fechaDeUso, horaInicio, horaFinal, confirmacion, fechaDeReservacion, idReservacion FROM Reservaciones WHERE idEstudiante=@pIdUsuario;";

        SqlCommand cmd = new SqlCommand(query,conectado);

        cmd.Parameters.AddWithValue("@pIdUsuario",pIdUsuario);
        
        using (SqlDataReader dr = cmd.ExecuteReader()){
            while(dr.Read()){
                Reservacion objeto = new Reservacion(){
                    idEstudiante=Int32.Parse(dr["idCubiculo"].ToString()),
                    idCubiculo=Int32.Parse(dr["idEstudiante"].ToString()),
                };
                todasReservaciones.Add(objeto);
            }
        }
        conectado.Close();
        return todasReservaciones;
    }


    public static Boolean confirmarReservacion(int idReservacion){
        SQLConexion conex = new SQLConexion();
        SqlConnection conectado=  conex.establecer();

        string query= "confirmarReservacion @idReservacion;";

        SqlCommand cmd = new SqlCommand(query,conectado);

        cmd.Parameters.AddWithValue("@idReservacion",idReservacion);
        
        using (SqlDataReader dr = cmd.ExecuteReader()){
            while(dr.Read()){
                Reservacion objeto = new Reservacion(){
                    idEstudiante=Int32.Parse(dr["idCubiculo"].ToString()),
                    idCubiculo=Int32.Parse(dr["idEstudiante"].ToString()),
                };
            }
        }
        conectado.Close();
        return true;

    }

    public static List<Reservacion> todasReservaciones(){
        List<Reservacion> todasReservaciones = new List<Reservacion>();

        SQLConexion conex = new SQLConexion();
        SqlConnection conectado=  conex.establecer();

        string query= "SELECT idCubiculo, idEstudiante.Nombre, Estudiantes.apellido1,Estudiantes.apellido2, fechaDeUso, horaInicio, horaFinal, confirmacion, fechaDeReservacion, idReservacion FROM Reservaciones INNER JOIN Estudiantes ON Reservaciones.idEstudiante = Estudiantes.idEstudiante;";

        SqlCommand cmd = new SqlCommand(query,conectado);
        
        using (SqlDataReader dr = cmd.ExecuteReader()){
            while(dr.Read()){
                Reservacion objeto = new Reservacion(){
                    idEstudiante=Int32.Parse(dr["idCubiculo"].ToString()),
                    idCubiculo=Int32.Parse(dr["idEstudiante"].ToString()),
                };
                todasReservaciones.Add(objeto);
            }
        }
        conectado.Close();
        return todasReservaciones;
    }


}