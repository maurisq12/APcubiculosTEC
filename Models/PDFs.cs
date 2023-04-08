using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;

namespace CubiculosTEC.Models;


public class Pdfs{
    
    public byte[] crear(List<Object> datos,List<String> serviciosOn){
        // Parseo de lista
        string pIdEstudiante = datos[0].ToString();
        string pFechaDeUso = datos[1].ToString();
        string pIdCubiculo = datos[2].ToString();
        string pHoraInicio = datos[3].ToString();
        string pHoraFinal = datos[4].ToString();
        string servicios = string.Join( ", ", serviciosOn);

        // Crear nuevo PDF
        Document document = new Document();

        // Crear PDF.Escritor 
        var ms = new MemoryStream();
        PdfWriter writer = PdfWriter.GetInstance(document, ms);

        // Abrir el documento
        document.Open();

        // Interpolacion de cadenas y leer el HTML string
        StringReader html = new StringReader( @$"<html><head><title>Nueva Reservacion</title></head><body>
                                            <h1>Nueva Reservación de Cubículo</h1>
                                            <h2>Datos de la reservación</h2>
                                            <ul>
                                                <li>ID del Estudiante: {pIdEstudiante} </li>
                                                <li>ID del Cubículo: {pIdCubiculo} </li>
                                                <li>Fecha de la reservación: {pFechaDeUso}</li>
                                                <li>Hora Llegada: {pHoraInicio}</li>
                                                <li>Hora Salida: {pHoraFinal}</li>
                                                <li>Servicios Solicitados: {servicios} </li>
                                            </ul>
                                        </body>
                                        </html>");

        // Parse en HTML y agregarlo al PDF
        XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, html);

        // Cerrar el documento
        document.Close();
        
        var pdfBytes = ms.ToArray();
        return pdfBytes; // Retornar el documento como ArrayDeBytes
    }
}