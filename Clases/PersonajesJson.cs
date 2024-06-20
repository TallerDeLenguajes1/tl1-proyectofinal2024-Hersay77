using EspacioPersonajes; 
using System.Collections.Generic; //para manejo de colecciones
using System.Text.Json; //para manejo de json
using System.IO; //para manejo de FILE
using EspacioFabricaDePersonajes;

namespace EspacioPersonajesJson
{
    public class PersonajesJson
    {
        public static void GuardarPersonajes(List<Personaje> ListaPersonajes, string ArchivoListaPersonajesJson)
        {
            string jsonString = JsonSerializer.Serialize(ListaPersonajes); //Serealizo la lista de personajes
            File.WriteAllText(ArchivoListaPersonajesJson, jsonString); //escribo en el json. WriteAllText crea y soobrescribe el archivo ya que necesito soobreescribir el archivo lista de personajes siempre, sea cual sea el camino que se lo cree
        }

        public static List<Personaje> LeerPersonajes(string ArchivoListaPersonajesJson)
        {   
            List<Personaje> ListaPersonajes = new List<Personaje>();

            return ListaPersonajes;
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

        public static List<Personaje> GenerarPersonajes()
        {
            string ArchivoDatosPersonajes = "Archivo/DatosPerosnajes.json"; //guardo en un string la ruta del archivo que contiene datos de los personajes para generarlos
            if (Existe(ArchivoDatosPersonajes)) //compruebo si existe el archivo
            {
                string jsonString = File.ReadAllText(ArchivoDatosPersonajes); //se lee el archivo y se guarda en un string - el archivo esta en formato json
                List<Datos> ListaDatos = JsonSerializer.Deserialize<List<Datos>>(jsonString); //deseralizo el json basado en la clase Datos
                List<Personaje> ListaPersonajes = new List<Personaje>(); //creo lista de personajes
                foreach (var Dato in ListaDatos) //se recorre la lista y se envian los datos de un personaje a la fabrica
                {
                    Personaje NuevoPersonje = FabricaDePersonjaes.CrearPersonaje(Dato.Nombre, Dato.Apodo, Dato.Fecha, Dato.Edad, Dato.Descripcion, Dato.SerieDelPersonaje); //fabrica el nuevo personaje
                    ListaPersonajes.Add(NuevoPersonje); //lo agrego a la lista
                }
                return ListaPersonajes;
            }
            else
            {
                Console.Write("El archivo DatosPersonajes.json no existe");
                return null;
            }
        }

    }
}