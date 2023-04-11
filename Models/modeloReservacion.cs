using System.Data;
using System.Data.SqlClient;

namespace CubiculosTEC.Models;

public class Reservacion
{

    public int idEstudiante;

    public string estudianteReservador;
    public int idCubiculo;

    public string nombreCubiculo;
    public string fechaDeUso;
    public string horaInicio;
    public string horaFinal;
    public string confirmacion;
    public string fechaDeReservacion;

    public int idReservacion;

    public string horasUtilizado;




    public Reservacion()
    {

    }

    public static List<Reservacion> reservacionesUsuario(int pIdUsuario)
    {
        List<Reservacion> todasReservaciones = new List<Reservacion>();

        SQLConexion conex = new SQLConexion();
        SqlConnection conectado = conex.establecer();

        string query = @"SELECT Cubiculos.idCubiculo,Cubiculos.nombre nombreC , Estudiantes.idEstudiante idEstudiante,Estudiantes.nombre nombre, Estudiantes.apellido1 apellido1 ,Estudiantes.apellido2 apellido2, fechaDeUso, horaInicio, horaFinal, confirmacion, fechaDeReservacion, idReservacion FROM Reservaciones INNER JOIN Estudiantes ON Reservaciones.idEstudiante = Estudiantes.idEstudiante 
        INNER JOIN Cubiculos ON Reservaciones.idCubiculo = Cubiculos.idCubiculo WHERE Reservaciones.idEstudiante = @pIdUsuario;";
        SqlCommand cmd = new SqlCommand(query, conectado);

        cmd.Parameters.AddWithValue("@pIdUsuario", pIdUsuario);

        using (SqlDataReader dr = cmd.ExecuteReader())
        {
            while (dr.Read())
            {
                Reservacion objeto = new Reservacion()
                {
                    idReservacion = Int32.Parse(dr["idReservacion"].ToString()),
                    idCubiculo = Int32.Parse(dr["idCubiculo"].ToString()),
                    idEstudiante = Int32.Parse(dr["idEstudiante"].ToString()),
                    horaInicio = dr["horaInicio"].ToString(),
                    horaFinal = dr["horaFinal"].ToString(),
                    horasUtilizado = (TimeSpan.Parse(dr["horaFinal"].ToString()) - TimeSpan.Parse(dr["horaInicio"].ToString())).ToString(),
                    fechaDeUso = DateTime.Parse(dr["fechaDeUso"].ToString()).Date.ToShortDateString(),
                    fechaDeReservacion = DateTime.Parse(dr["fechaDeReservacion"].ToString()).Date.ToShortDateString(),
                    estudianteReservador = dr["nombre"].ToString() + " " + dr["apellido1"].ToString() + " " + dr["apellido2"].ToString(),
                    nombreCubiculo = dr["nombreC"].ToString(),
                    confirmacion = dr["confirmacion"].ToString()

                };
                todasReservaciones.Add(objeto);
            }
        }
        conectado.Close();
        return todasReservaciones;
    }

    public static Reservacion unaReservacion(int pIdReserva)
    {
        List<Reservacion> todasReservaciones = new List<Reservacion>();

        SQLConexion conex = new SQLConexion();
        SqlConnection conectado = conex.establecer();

        string query = @"SELECT Cubiculos.idCubiculo,Cubiculos.nombre nombreC , Estudiantes.idEstudiante idEstudiante,Estudiantes.nombre nombre, Estudiantes.apellido1 apellido1 ,Estudiantes.apellido2 apellido2, fechaDeUso, horaInicio, horaFinal, confirmacion, fechaDeReservacion, idReservacion FROM Reservaciones INNER JOIN Estudiantes ON Reservaciones.idEstudiante = Estudiantes.idEstudiante 
        INNER JOIN Cubiculos ON Reservaciones.idCubiculo = Cubiculos.idCubiculo WHERE Reservaciones.idReservacion = @pIdReserva;";
        SqlCommand cmd = new SqlCommand(query, conectado);

        cmd.Parameters.AddWithValue("@pIdReserva", pIdReserva);

        using (SqlDataReader dr = cmd.ExecuteReader())
        {
            while (dr.Read())
            {
                Reservacion objeto = new Reservacion()
                {
                    idReservacion = Int32.Parse(dr["idReservacion"].ToString()),
                    idCubiculo = Int32.Parse(dr["idCubiculo"].ToString()),
                    idEstudiante = Int32.Parse(dr["idEstudiante"].ToString()),
                    horaInicio = dr["horaInicio"].ToString(),
                    horaFinal = dr["horaFinal"].ToString(),
                    horasUtilizado = (TimeSpan.Parse(dr["horaFinal"].ToString()) - TimeSpan.Parse(dr["horaInicio"].ToString())).ToString(),
                    fechaDeUso = DateTime.Parse(dr["fechaDeUso"].ToString()).Date.ToShortDateString(),
                    fechaDeReservacion = DateTime.Parse(dr["fechaDeReservacion"].ToString()).Date.ToShortDateString(),
                    estudianteReservador = dr["nombre"].ToString() + " " + dr["apellido1"].ToString() + " " + dr["apellido2"].ToString(),
                    nombreCubiculo = dr["nombreC"].ToString(),
                    confirmacion = dr["confirmacion"].ToString()

                };
                todasReservaciones.Add(objeto);
            }
        }
        conectado.Close();
        return todasReservaciones[0];
    }

    public static Boolean confirmarReservacion(int idReservacion)
    {
        SQLConexion conex = new SQLConexion();
        SqlConnection conectado = conex.establecer();

        string query = "confirmarCubiculo @idReservacion;";

        SqlCommand cmd = new SqlCommand(query, conectado);

        cmd.Parameters.AddWithValue("@idReservacion", idReservacion);

        using (SqlDataReader dr = cmd.ExecuteReader())
        {
            while (dr.Read())
            {
            }
        }
        conectado.Close();
        return true;

    }

    public static Boolean checkReservacion(int pIdCubiculo, string pFechaDeUso, string pHoraInicio, string pHoraFinal)
    {
        SQLConexion conex = new SQLConexion();
        SqlConnection conectado = conex.establecer();

        string query = "SELECT idReservacion FROM Reservaciones WHERE idCubiculo=@pIdCubiculo and fechaDeUso=@pFechaDeUso AND ((@pHoraInicio between horaInicio and horaFinal) OR (@pHoraFinal between horaInicio and horaFinal));";

        SqlCommand cmd = new SqlCommand(query, conectado);


        cmd.Parameters.AddWithValue("@pIdCubiculo", pIdCubiculo);
        cmd.Parameters.AddWithValue("@pFechaDeUso", pFechaDeUso);
        cmd.Parameters.AddWithValue("@pHoraInicio", pHoraInicio);
        cmd.Parameters.AddWithValue("@pHoraFinal", pHoraFinal);

        SqlDataReader dr = cmd.ExecuteReader();

        if (dr.HasRows)
        {
            return false;
        }
        return true;

    }

    public static List<Reservacion> todasReservaciones()
    {
        List<Reservacion> todasReservaciones = new List<Reservacion>();

        SQLConexion conex = new SQLConexion();
        SqlConnection conectado = conex.establecer();

        string query = "SELECT idCubiculo, Estudiantes.idEstudiante idEstudiante,Estudiantes.nombre nombre, Estudiantes.apellido1 apellido1 ,Estudiantes.apellido2 apellido2, fechaDeUso, horaInicio, horaFinal, confirmacion, fechaDeReservacion, idReservacion FROM Reservaciones INNER JOIN Estudiantes ON Reservaciones.idEstudiante = Estudiantes.idEstudiante;";

        SqlCommand cmd = new SqlCommand(query, conectado);

        using (SqlDataReader dr = cmd.ExecuteReader())
        {
            while (dr.Read())
            {
                Reservacion objeto = new Reservacion()
                {
                    idReservacion = Int32.Parse(dr["idReservacion"].ToString()),
                    idCubiculo = Int32.Parse(dr["idCubiculo"].ToString()),
                    idEstudiante = Int32.Parse(dr["idEstudiante"].ToString()),
                    horaInicio = dr["horaInicio"].ToString(),
                    horaFinal = dr["horaFinal"].ToString(),
                    horasUtilizado = (TimeSpan.Parse(dr["horaFinal"].ToString()) - TimeSpan.Parse(dr["horaInicio"].ToString())).ToString(),
                    fechaDeUso = DateTime.Parse(dr["fechaDeUso"].ToString()).Date.ToShortDateString(),
                    fechaDeReservacion = DateTime.Parse(dr["fechaDeReservacion"].ToString()).Date.ToShortDateString(),
                    estudianteReservador = dr["nombre"].ToString() + " " + dr["apellido1"].ToString() + " " + dr["apellido2"].ToString(),
                    confirmacion = dr["confirmacion"].ToString()

                };
                todasReservaciones.Add(objeto);
            }
        }

        conectado.Close();
        return todasReservaciones;
    }

    public static Boolean modificarReservacion(int pIdReserva, int pIdCubiculo, int pIdEstudiante, string pFechaDeUso, string pHoraInicio, string pHoraFinal, string pFechaDeReservacion, string pConfirmacion)
    {

        SQLConexion conex = new SQLConexion();
        SqlConnection conectado = conex.establecer();

        string query = " modificarReservacion @pIdReserva, @pIdCubiculo, @pIdEstudiante, @pFechaDeUso, @pHoraInicio, @pHoraFinal, @pFechaDeReservacion, @pConfirmacion;";

        SqlCommand cmd = new SqlCommand(query, conectado);

        cmd.Parameters.AddWithValue("@pIdReserva", pIdReserva);
        cmd.Parameters.AddWithValue("@pIdCubiculo", pIdCubiculo);
        cmd.Parameters.AddWithValue("@pIdEstudiante", pIdEstudiante);
        cmd.Parameters.AddWithValue("@pFechaDeUso", pFechaDeUso);
        cmd.Parameters.AddWithValue("@pHoraInicio", pHoraInicio);
        cmd.Parameters.AddWithValue("@pHoraFinal", pHoraFinal);
        cmd.Parameters.AddWithValue("@pFechaDeReservacion", pFechaDeReservacion);
        cmd.Parameters.AddWithValue("@pConfirmacion", pConfirmacion);

        using (SqlDataReader dr = cmd.ExecuteReader())
        {
            while (dr.Read())
            {
            }
        }

        conectado.Close();
        return true;

    }

    public static int utlimaReservacion(int pIdEstudiante)
    {
        List<Reservacion> todasReservaciones = new List<Reservacion>();

        SQLConexion conex = new SQLConexion();
        SqlConnection conectado = conex.establecer();

        string query = "SELECT TOP 1 idReservacion FROM Reservaciones WHERE idEstudiante=@pIdEstudiante ORDER BY idReservacion DESC";
        SqlCommand cmd = new SqlCommand(query, conectado);

        cmd.Parameters.AddWithValue("@pIdEstudiante", pIdEstudiante);

        SqlDataReader dr = cmd.ExecuteReader();
        dr.Read();
        int pRespuesta = Int32.Parse(dr["idReservacion"].ToString());
        conectado.Close();
        return pRespuesta;



    }

    public static void agregarServicios(List<int> servicios, int pIdReservacion)
    {
        if (!(servicios.Count() == 0))
        {
            SQLConexion conex = new SQLConexion();
            SqlConnection conectado = conex.establecer();
            for (int i = 0; i < servicios.Count(); i++)
            {
                string query = "agregarServicioReservacion @pIdServicio, @pIdReservacion";
                SqlCommand cmd = new SqlCommand(query, conectado);

                cmd.Parameters.AddWithValue("@pIdServicio", servicios[i]);
                cmd.Parameters.AddWithValue("@pIdReservacion", pIdReservacion);

                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                dr.Close();
            }
            conectado.Close();
        }
        return;
    }


    public static List<String> obtenerServicios(int pIdReservacion)
    {
        List<String> serviciosOn = new List<String>();
        string[] servicios = { "JAWS", "NVDA 2", "Lanbda 1.4", "Teclado especial", "Línea Braille", "Impresora Fuse" };

        SQLConexion conex = new SQLConexion();
        SqlConnection conectado = conex.establecer();

        string query = " SELECT idServicioEspecial FROM ServiciosCubiculo WHERE idReservacion=@pIdReservacion;";

        SqlCommand cmd = new SqlCommand(query, conectado);

        List<int> numServicios = new List<int>();

        cmd.Parameters.AddWithValue("@pIdReservacion", pIdReservacion);
        using (SqlDataReader dr = cmd.ExecuteReader())
        {
            while (dr.Read())
            {
                numServicios.Add(Int32.Parse(dr["idServicioEspecial"].ToString()));
            }
        }

        conectado.Close();

        for (int i = 0; i < numServicios.Count(); i++)
        {
            serviciosOn.Add(servicios[numServicios[i] - 1]);
        }
        return serviciosOn;
    }
    public static Boolean eliminarReservacion(int pIdReserva)
    {
        try
        {
            SQLConexion conex = new SQLConexion();
            SqlConnection conectado = conex.establecer();

            string query = "eliminarReservacion @idReservacion;";

            SqlCommand cmd = new SqlCommand(query, conectado);
            cmd.Parameters.AddWithValue("@idReservacion", pIdReserva);

            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {

                };
            }
            conectado.Close();
            return true;
        }
        catch
        {
            return false;
        }

    }


}