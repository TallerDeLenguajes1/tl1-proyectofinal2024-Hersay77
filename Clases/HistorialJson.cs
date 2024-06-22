using EspacioPersonajes;
using System.Text.Json; //para manejo de json
using System.IO; //para manejo de FILE

namespace EspacioHistorialJson
{
    public class HistorialJson 
    {
        public static void GuardarGanador(Personaje Ganador, string info, string ArchivoHistorial)
        {
            
        }

        public static List<Personaje> LeerGanadores(string ArchivoHistorial)
        {
            if(Existe(ArchivoHistorial))
            {
                try
                {
                    string jsonString = File.ReadAllText(ArchivoHistorial); //se lee el archivo y se guarda en un string - el archivo esta en formato json
                    List<Personaje> Historial = JsonSerializer.Deserialize<List<Personaje>>(jsonString); //deseralizo el json basado en la clase Personaje
                    return Historial;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al leer la lista de personajes del Historial: {ex.Message}");
                    return null; //retorna nulo si no se pudo crear la lista Historial
                };
            }
            else
            {
                Console.WriteLine("Error Leyendo el historial archivo no existe");
                return null; //retorna nulo si no se pudo leer el historial
            }
        }

        public static bool Existe(string Archivo)
        {
            if (File.Exists(Archivo)) //se usa la clase File con el metodo exists para comprobar si existe el rchivo en la ruta proporcionada
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

