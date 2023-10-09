using System.Text.Json;
namespace EspacioTarea
{
    public class AccesoADatos
    {
        public List<Tarea>? Obtener()
        {
            string nombreArchivo = "Tareas.json";
            string documentoJson;
            if (File.Exists(nombreArchivo))
            {
                FileInfo fileInfo = new(nombreArchivo);
                if (fileInfo.Length > 0)
                {

                    using (FileStream archivoAbierto = new(nombreArchivo, FileMode.Open))
                    {
                        using (StreamReader archivoLeer = new(archivoAbierto))
                        {
                            documentoJson = archivoLeer.ReadToEnd();
                            archivoLeer.Close();
                        }
                    }
                    var listadoTareas = JsonSerializer.Deserialize<List<Tarea>>(documentoJson);
                    return listadoTareas;
                }
            }
            return null;

        }
        public void Guardar(List<Tarea> tareas)
        {
            string nombreArchivo = "Tareas.json";
            string tareasJson = JsonSerializer.Serialize(tareas);
            File.WriteAllText(nombreArchivo, tareasJson);
            // using (FileStream archivoAbierto = new(nombreArchivo, FileMode.Create))
            // {
            //     // using (StreamWriter archivoEscribir = new(archivoAbierto))
            //     // {
            //     //     archivoEscribir.Write(tareasJson);
            //     //     archivoEscribir.Close();
            //     // }
            // }
        }
    }
}