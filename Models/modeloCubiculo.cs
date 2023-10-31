using System.Data;
using System.Data.SqlClient;

namespace CubiculosTEC.Models;

public class Cubiculo{

    private int IDCubiculo;
    private string nombre;
    private string estado;
    private int capacidad;

    private int tiempoMaximo;

    public Cubiculo(){

    }

    public Cubiculo(string pIDCubiculo, string pNombre, string pEstado, int pCapacidad, string[] pServiciosEspeciales){
        IDCubiculo= Int32.Parse(pIDCubiculo);
        nombre=pNombre;
        estado=pEstado;
        capacidad=pCapacidad;
    }

    public string getNombre(){
        return nombre;
    }

    public int getId(){
        return IDCubiculo;
    }

    public string getEstado(){
        return estado;
    }

    public int getCapacidad(){
        return capacidad;
    }

    public int getTiempoMaximo(){
        return capacidad;
    }

    



    public static List<Cubiculo> cubiculosDisponibles(){
        var listaResultado = new List<Cubiculo>();

        SQLConexion conex = new SQLConexion();
        SqlConnection conectado=  conex.establecer();

        string query= "SELECT idCubiculo, nombre, capacidad, tiempoMaximo, idEstado FROM Cubiculos WHERE idEstado=1;";
        

        SqlCommand cmd = new SqlCommand(query,conectado);
        
        using (SqlDataReader dr = cmd.ExecuteReader()){
            while(dr.Read()){
                Cubiculo objeto = new Cubiculo(){
                    IDCubiculo=Int32.Parse(dr["idCubiculo"].ToString()),
                    nombre= dr["nombre"].ToString(),
                    capacidad=Int32.Parse(dr["capacidad"].ToString()),
                    tiempoMaximo=Int32.Parse(dr["capacidad"].ToString()), 
                    estado= dr["idEstado"].ToString() 
                };
                listaResultado.Add(objeto);
            }
        }
        conectado.Close();
        return listaResultado;  
    }

    public static Cubiculo unCubiculo(int pIdCubiculo){
        var listaResultado = new List<Cubiculo>();

        SQLConexion conex = new SQLConexion();
        SqlConnection conectado=  conex.establecer();

        string query= "SELECT idCubiculo, nombre, capacidad, tiempoMaximo, idEstado FROM Cubiculos WHERE idCubiculo=@pIdCubiculo;";
        
        

        SqlCommand cmd = new SqlCommand(query,conectado);
        cmd.Parameters.AddWithValue("@pIdCubiculo",pIdCubiculo);
        
        using (SqlDataReader dr = cmd.ExecuteReader()){
            while(dr.Read()){
                Cubiculo objeto = new Cubiculo(){
                    IDCubiculo=Int32.Parse(dr["idCubiculo"].ToString()),
                    nombre= dr["nombre"].ToString(),
                    capacidad=Int32.Parse(dr["capacidad"].ToString()),
                    tiempoMaximo=Int32.Parse(dr["capacidad"].ToString()), 
                    estado= dr["idEstado"].ToString() 
                };
                listaResultado.Add(objeto);
            }
        }
        conectado.Close();
        return listaResultado[0]; 

    }

    public static List<Cubiculo> cubiculosTodos(){
        var listaResultado = new List<Cubiculo>();

        SQLConexion conex = new SQLConexion();
        SqlConnection conectado=  conex.establecer();

        string query= "SELECT idCubiculo, nombre, capacidad, EstadosCubiculo.estadoActual estado, tiempoMaximo FROM Cubiculos INNER JOIN EstadosCubiculo ON Cubiculos.idEstado = EstadosCubiculo.idEstado;";
        

        SqlCommand cmd = new SqlCommand(query,conectado);
        
        using (SqlDataReader dr = cmd.ExecuteReader()){
            while(dr.Read()){
                Cubiculo objeto = new Cubiculo(){
                    IDCubiculo=Int32.Parse(dr["idCubiculo"].ToString()),
                    nombre= dr["nombre"].ToString(),
                    capacidad=Int32.Parse(dr["capacidad"].ToString()),
                    tiempoMaximo=Int32.Parse(dr["capacidad"].ToString()), 
                    estado= dr["estado"].ToString()
                };
                listaResultado.Add(objeto);
            }
        }
        conectado.Close();
        return listaResultado;  
    }


    public static Boolean reservarCubiculo(int pIdCubiculo, int pIdEstudiante, string pFechaDeUso, string pHoraInicio, string pHoraFinal, string pFechaDeReservacion){

        SQLConexion conex = new SQLConexion();
        SqlConnection conectado=  conex.establecer();

        string query= "agregarReservacion @idCubiculo, @idEstudiante, @fechaDeUso, @horaInicio, @horaFinal, @fechaDeReservacion;";
        Console.WriteLine("dos");

        SqlCommand cmd = new SqlCommand(query,conectado);
        Console.WriteLine("tres");
        cmd.Parameters.AddWithValue("@idCubiculo",pIdCubiculo);
        cmd.Parameters.AddWithValue("@idEstudiante",pIdEstudiante);
        cmd.Parameters.AddWithValue("@fechaDeUso",pFechaDeUso);
        cmd.Parameters.AddWithValue("@horaInicio",pHoraInicio);
        cmd.Parameters.AddWithValue("@horaFinal",pHoraFinal);
        cmd.Parameters.AddWithValue("@fechaDeReservacion",pFechaDeReservacion);
        
        using (SqlDataReader dr = cmd.ExecuteReader()){
            while(dr.Read()){
                
            }
        }
        conectado.Close();
        return true;
    }

    public static List<Cubiculo> filtrarXFechaCubiculo(string pFecha, string pHoraInicio, string pHoraFinal){
        var listaResultado = new List<Cubiculo>();

        SQLConexion conex = new SQLConexion();
        SqlConnection conectado=  conex.establecer();

        string query= "filtrarCubiculosFecha  @fecha, @horaInicio, @horaFinal;";

        SqlCommand cmd = new SqlCommand(query,conectado);
        cmd.Parameters.AddWithValue("@fecha",pFecha);
        cmd.Parameters.AddWithValue("@horaInicio",pHoraInicio);
        cmd.Parameters.AddWithValue("@horaFinal",pHoraFinal);
        
        using (SqlDataReader dr = cmd.ExecuteReader()){
            while(dr.Read()){
                    Cubiculo objeto = new Cubiculo(){
                    IDCubiculo=Int32.Parse(dr["idCubiculo"].ToString()),
                    nombre= dr["nombre"].ToString(),
                    capacidad=Int32.Parse(dr["capacidad"].ToString()),
                    tiempoMaximo=Int32.Parse(dr["capacidad"].ToString()), 
                    estado= "1"
                };
                listaResultado.Add(objeto);
            }
        }
        conectado.Close();
        return listaResultado;
    }

    public static Boolean crearCubiculo(string pNombre, int pEstado, int pCapacidad){

        SQLConexion conex = new SQLConexion();
        SqlConnection conectado=  conex.establecer();

        string query= "crearCubiculo @pNombre, @pCapacidad, @pEstado;";

        SqlCommand cmd = new SqlCommand(query,conectado);
        cmd.Parameters.AddWithValue("@pNombre",pNombre);
        cmd.Parameters.AddWithValue("@pEstado",pEstado);
        cmd.Parameters.AddWithValue("@pCapacidad",pCapacidad);
        
        using (SqlDataReader dr = cmd.ExecuteReader()){
            while(dr.Read()){
                Cubiculo objeto = new Cubiculo(){
                    IDCubiculo=Int32.Parse(dr["idCubiculo"].ToString())
                };
            }
        }
        conectado.Close();
        return true;
    }

    public static Boolean editarCubiculo(int pIdCubiculo, string pNombre, int pEstado, int pCapacidad){

        SQLConexion conex = new SQLConexion();
        SqlConnection conectado=  conex.establecer();

        string query= "modificarCubiculo @idCubiculo, @pNombre, @pEstado, @pCapacidad, @pTiempoMáximo;";

        SqlCommand cmd = new SqlCommand(query,conectado);
        cmd.Parameters.AddWithValue("@idCubiculo",pIdCubiculo);
        cmd.Parameters.AddWithValue("@pNombre",pNombre);
        cmd.Parameters.AddWithValue("@pEstado",pEstado);
        cmd.Parameters.AddWithValue("@pCapacidad",pCapacidad);
        cmd.Parameters.AddWithValue("@pTiempoMáximo","00:00");
        
        using (SqlDataReader dr = cmd.ExecuteReader()){
            while(dr.Read()){
                Cubiculo objeto = new Cubiculo(){
                    IDCubiculo=Int32.Parse(dr["idCubiculo"].ToString())
                };
            }
        }
        conectado.Close();
        return true;
    }

    public static Boolean eliminarCubiculo(int pIdCubiculo){
        try{
        SQLConexion conex = new SQLConexion();
        SqlConnection conectado=  conex.establecer();

        string query= "eliminarCubiculo @idCubiculo;";

        SqlCommand cmd = new SqlCommand(query,conectado);
        cmd.Parameters.AddWithValue("@idCubiculo",pIdCubiculo);
        
        using (SqlDataReader dr = cmd.ExecuteReader()){
            while(dr.Read()){
                Cubiculo objeto = new Cubiculo(){
                    IDCubiculo=Int32.Parse(dr["idCubiculo"].ToString())
                };
            }
        }
        conectado.Close();
        return true;
        }catch{
            return false;
        }


    }

    public static Boolean cambiarEstadoCubiculo(int pIdCubiculo, int pEstado){
        SQLConexion conex = new SQLConexion();
        SqlConnection conectado=  conex.establecer();

        string query= "cambiarEstadoCubiculo @idCubiculo, @pEstado;";

        SqlCommand cmd = new SqlCommand(query,conectado);
        cmd.Parameters.AddWithValue("@idCubiculo",pIdCubiculo);
        cmd.Parameters.AddWithValue("@pEstado",pEstado);
        
        using (SqlDataReader dr = cmd.ExecuteReader()){
            while(dr.Read()){
                Cubiculo objeto = new Cubiculo(){
                    IDCubiculo=Int32.Parse(dr["idCubiculo"].ToString())
                };
            }
        }
        conectado.Close();
        return true;
    }

    public static Boolean bloqueoCubiculo(int pIdCubiculo, string pFechaDeUso , string pHoraInicio, string pHoraFinal, string pFechaDeReservacion){

        SQLConexion conex = new SQLConexion();
        SqlConnection conectado=  conex.establecer();

        string query= "bloquearCubiculo @idCubiculo, @pFechaDeUso, @pHoraInicio, @pHoraFinal, @pFechaDeReservacion;";

        SqlCommand cmd = new SqlCommand(query,conectado);
        cmd.Parameters.AddWithValue("@idCubiculo",pIdCubiculo);
        cmd.Parameters.AddWithValue("@pFechaDeUso",pFechaDeUso);
        cmd.Parameters.AddWithValue("@pHoraInicio",pHoraInicio);
        cmd.Parameters.AddWithValue("@pHoraFinal",pHoraFinal);
        cmd.Parameters.AddWithValue("@pFechaDeReservacion",pFechaDeReservacion);
        
        using (SqlDataReader dr = cmd.ExecuteReader()){
            while(dr.Read()){
            }
        }
        conectado.Close();
        return true;
    }

    public static Boolean tiempoMaximoCubiculo(int pIdCubiculo, string pMaximo){

        SQLConexion conex = new SQLConexion();
        SqlConnection conectado=  conex.establecer();

        string query= "definirHoraMaxima @idCubiculo, @pMaximo;";

        SqlCommand cmd = new SqlCommand(query,conectado);
        cmd.Parameters.AddWithValue("@idCubiculo",pIdCubiculo);
        cmd.Parameters.AddWithValue("@pMaximo",pMaximo);
        
        using (SqlDataReader dr = cmd.ExecuteReader()){
            while(dr.Read()){
            }
        }
        conectado.Close();
        return true;
    }

    



} 



