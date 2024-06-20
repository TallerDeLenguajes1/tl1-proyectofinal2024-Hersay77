using EspacioPersonajes;
using System.Collections.Generic; //para manejo de colecciones
using System.Text.Json; //para manejo de json
using System.IO; //para manejo de FILE

namespace EspacioPersonajesJson
{
    public class PersonajesJson
    {
        public void GuardarPersonajes(List<Personaje> ListaPersonajes, string ArchivoListaPersonajesJson)
        {

        }

        public static List<Personaje> LeerPersonajes(string ArchivoListaPersonajesJson)
        {   
            List<Personaje> ListaPersonajes = new List<Personaje>();

            return ListaPersonajes;
        }

        public static bool Existe(string Archivo)
        {
            bool existe = true;

            return existe;
        }

        public static void GenerarPersonajes()
        {
            string ArchivoDatosPersonajes = "Archivo/DatosPerosnajes.json";
            if (Existe(ArchivoDatosPersonajes))
            {
                string jsonString = File.ReadAllText(ArchivoDatosPersonajes);
                List<Datos> ListaDatos = JsonSerializer.Deserialize<List<Datos>>(jsonString);
            }
            else
            {
                Console.Write("El archivo DatosPersonajes.json no existe");
            }
        }

    }


}