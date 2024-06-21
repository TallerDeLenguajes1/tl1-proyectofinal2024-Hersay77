using EspacioPersonajes; 
using System.Collections.Generic; //para manejo de colecciones
using System.Text.Json; //para manejo de json
using System.IO; //para manejo de FILE
using EspacioFabricaDePersonajes;

namespace EspacioPersonajesJson
{
    public class PersonajesJson
    {
        public static bool GuardarPersonajes(List<Personaje> ListaPersonajes, string ArchivoListaPersonajesJson)
        {
            try //uso try-catch para captura cualquier excepción que pueda ocurrir
            {
                string jsonString = JsonSerializer.Serialize(ListaPersonajes); // Serializar la lista de personajes que se recibe a JSON
                File.WriteAllText(ArchivoListaPersonajesJson, jsonString); // Escribir la cadena JSON en el archivo especificado - WriteAllText sobreexcribe el archivo si existe y si no, lo crea
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar la lista de personajes: {ex.Message}");
                return false;
            }
        }

        public static List<Personaje> LeerPersonajes(string ArchivoListaPersonajesJson)
        {   
            try
            {
                List<Personaje> ListaPersonajes = new List<Personaje>();
                return ListaPersonajes; //retorna lista creada
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al leer la lista de personajes: {ex.Message}");
                return null; //retorna nulo si no se pudo crear la lista
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

        public static List<Personaje> GenerarPersonajes()
        {
            string ArchivoDatosPersonajes = "Archivo/DatosPerosnajes.json"; //guardo en un string la ruta del archivo que contiene datos de los personajes para generarlos
            if (Existe(ArchivoDatosPersonajes)) //compruebo si existe el archivo
            {
                try
                    {
                        string jsonString = File.ReadAllText(ArchivoDatosPersonajes); //se lee el archivo y se guarda en un string - el archivo esta en formato json
                        List<Datos> ListaDatos = JsonSerializer.Deserialize<List<Datos>>(jsonString); //deseralizo el json basado en la clase Datos
                        List<Personaje> ListaPersonajes = new List<Personaje>(); //creo lista de personajes
                        foreach (var Dato in ListaDatos) //se recorre la lista y se envian los datos de un personaje a la fabrica
                        {
                            Personaje NuevoPersonje = FabricaDePersonjaes.CrearPersonaje(Dato.Nombre, Dato.Apodo, Dato.Fecha, Dato.Edad, Dato.Descripcion, Dato.SerieDelPersonaje); //se fabrica el nuevo personaje
                            ListaPersonajes.Add(NuevoPersonje); //lo agrego a la lista
                        }
                        return ListaPersonajes;
                    }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error creando personajes: {ex.Message}");
                    return null; //retorna nulo si no se pudo crear la lista Historial
                };                
            }
            else
            {
                Console.Write("El archivo DatosPersonajes.json no existe");
                return null; //retorna null si no existe
            }
        }
    }
}