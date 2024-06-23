using EspacioPersonajes;
using System.Text.Json; //para manejo de json
using System.IO; //para manejo de FILE

namespace EspacioHistorialJson
{
    public class HistorialJson 
    {
        public static bool GuardarGanador(Personaje Ganador, string nombre, string ArchivoHistorial, List<PersonajeEnHistorial> Historial, float puntaje)
        {
                try
                {
                    Historial = Historial.OrderByDescending(p => p.Puntaje).ToList();//OrderByDescending ordena segun el puntaje, pero no modifica la lista original Historial. En su lugar, crea una nueva secuencia (IEnumerable<T>) con los elementos ordenados según el criterio especificado. Entonces se hace tambien ToList();
                    Historial.Remove(Historial[9]);//se quita el ultimo en la lista
                    var personajeAgregar = new PersonajeEnHistorial(){NombreJugador = nombre, NombrePersonaje = Ganador.DatosPersonaje.Nombre, Nivel = Ganador.CaracteristicasPersonaje.Nivel, Puntaje = puntaje}; //construyo nuevo personaje en historial a guardar
                    Historial.Add(personajeAgregar);
                    Historial = Historial.OrderByDescending(p => p.Puntaje).ToList();//se vuelve a ordenar la lista por puntaje
                    string jsonString = JsonSerializer.Serialize(Historial); // Serializar la lista de personajes que se recibe a JSON
                    File.WriteAllText(ArchivoHistorial, jsonString); // Escribir la cadena JSON en el archivo especificado - WriteAllText sobreexcribe el archivo si existe y si no, lo crea
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al guardar en Historial: {ex.Message}");
                    return false; //retorna nulo si no se pudo guardar la lista Historial
                };
        }

        public static List<PersonajeEnHistorial> LeerGanadores(string ArchivoHistorial)
        {
            if(Existe(ArchivoHistorial))
            {
                try
                {
                    string jsonString = File.ReadAllText(ArchivoHistorial); //se lee el archivo y se guarda en un string - el archivo esta en formato json
                    List<PersonajeEnHistorial> Historial = JsonSerializer.Deserialize<List<PersonajeEnHistorial>>(jsonString); //deseralizo el json basado en la clase Personaje
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


        public static void MostrarHistorial(List<PersonajeEnHistorial> Historial)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
╔═══════════════════════════════════════════════════════════════════════════════════════════════╗
║                                 HISTORIAL - RANKING GANADORES                                 ║
|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||");
            for (int i = 0; i < Historial.Count; i++)
            {
                Console.WriteLine($"    {i+1} - JUGADOR: {Historial[i].NombreJugador} ----PERSONAJE: {Historial[i].NombrePersonaje} ----NIVEL: {Historial[i].Nivel} ----PUNTAJE: {Historial[i].Puntaje}");
            }
            Console.WriteLine(@"
╚═══════════════════════════════════════════════════════════════════════════════════════════════╝");
            Console.ResetColor();
        }
    }

    public class PersonajeEnHistorial
        {
            private string nombreJugador;
            private string nombrePersonaje;
            int nivel ; 
            float puntaje;

            public string NombreJugador { get => nombreJugador; set => nombreJugador = value; }
            public string NombrePersonaje { get => nombrePersonaje; set => nombrePersonaje = value; }
            public int Nivel { get => nivel; set => nivel = value; }
            public float Puntaje { get => puntaje; set => puntaje = value; }
        }
}

