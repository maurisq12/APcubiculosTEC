namespace CubiculosTEC.Models;

public class Cubiculo{

    private int IDCubiculo;
    private string nombre;
    private string estado;
    private int capacidad;
    private string[] serviciosEspeciales;

    public Cubiculo(int pIDCubiculo, string pNombre, string pEstado, int pCapacidad, string[] pServiciosEspeciales){
        IDCubiculo=pIDCubiculo;
        nombre=pNombre;
        estado=pEstado;
        capacidad=pCapacidad;
        serviciosEspeciales=pServiciosEspeciales;
    }


}