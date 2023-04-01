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

    public static List<Cubiculo> cubiculosDisponibles(){
        var listaResultado = new List<Cubiculo>();

        SQLConexion conex = new SQLConexion();
        SqlConnection conectado=  conex.establecer();

        string query= "SELECT idCubiculo, nombre, capacidad, tiempoMaximo FROM Cubiculos WHERE idEstado=1;";

        SqlCommand cmd = new SqlCommand(query,conectado);

        if (conectado.State != ConnectionState.Open){

            conectado.Close();
            conectado.Open();
        }
        
        using (SqlDataReader dr = cmd.ExecuteReader()){
            while(dr.Read()){
                Cubiculo objeto = new Cubiculo(){
                    IDCubiculo=Int32.Parse(dr["idCubiculo"].ToString()),
                    nombre= dr["nombre"].ToString(),
                    capacidad=Int32.Parse(dr["capacidad"].ToString()),
                    tiempoMaximo=Int32.Parse(dr["capacidad"].ToString())  
                };
                listaResultado.Add(objeto);
            }
        }
        return listaResultado;  
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

} 



