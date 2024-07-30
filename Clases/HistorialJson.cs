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

        //REQUISITO - METODO ESTATICO LEE HISTORIAL DE GANADORES
        public static List<PersonajeEnHistorial> LeerGanadores(string ArchivoHistorial)
        {
            if(Existe(ArchivoHistorial))
            {
                try
                {
                    string jsonString = File.ReadAllText(ArchivoHistorial); //se lee el archivo y se guarda en un string - el archivo esta en formato json
                    List<PersonajeEnHistorial> Historial = JsonSerializer.Deserialize<List<PersonajeEnHistorial>> (jsonString); //deseralizo el json basado en la clase Personaje
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

        //REQUISITO - METODO ESTATICO COMPRUEBA SI EXISTE ARCHIVO HISTORIAL
        public static bool Existe(string Archivo)
        {
            if (File.Exists(Archivo)) //se usa la clase File con el metodo existe para comprobar si existe el archivo en la ruta proporcionada
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
╔══════════════════════════════════════════════════════════════════════════════════════════════════════╗
║                                     HISTORIAL - RANKING GANADORES                                    ║
 ||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||");
            Console.WriteLine();
            for (int i = 0; i <=9; i++)
            {
                Console.WriteLine($"\n    {i+1} - \tJUGADOR: {Historial[i].NombreJugador} ----PERSONAJE: {Historial[i].NombrePersonaje} ----NIVEL: {Historial[i].Nivel} ----PUNTAJE: {Historial[i].Puntaje}");
            }
            Console.WriteLine(@"
╚══════════════════════════════════════════════════════════════════════════════════════════════════════╝");
            Console.ResetColor();
        }

        //METODO PARA CREAR Y GUARDAR UN ARCHIVO SI NO EXISTE HISTORIAL
        public static bool GuardarHistorialVacio(string ArchivoHistorial, List<PersonajeEnHistorial> Historial){
            try
                {
                    string jsonString = JsonSerializer.Serialize(Historial); // Serializar el historial vacio
                    File.WriteAllText(ArchivoHistorial, jsonString); // Escribir la cadena JSON en el archivo especificado - WriteAllText sobreexcribe el archivo si existe y si no, lo crea
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al guardar en Historial: {ex.Message}");
                    return false; //retorna nulo si no se pudo guardar la lista Historial
                };
        }

        //METODO CREA HISTORIAL VACIO
        public static List<PersonajeEnHistorial> CrearHistorialVacio(){
            List<PersonajeEnHistorial> Historial = new List<PersonajeEnHistorial>();
            
            for (int i = 0; i <= 9; i++)
            {
                var personaje = new PersonajeEnHistorial();
                Historial.Add(personaje);
            }

            return Historial;
        }

    }

    //CLASE PARA GUARDAR PERSONAJES Y DATOS EN UN FORMATO MAS SIMPLIFICADO EN EL HISTORIAL
    public class PersonajeEnHistorial //Clase para el formato de como se guarda el personaje en el historial
        {
            private string nombreJugador;
            private string nombrePersonaje;
            int nivel ; //nivel que aumento el personaje
            float puntaje; //puntaje que se alcanzo en el juego

            public string NombreJugador { get => nombreJugador; set => nombreJugador = value; }
            public string NombrePersonaje { get => nombrePersonaje; set => nombrePersonaje = value; }
            public int Nivel { get => nivel; set => nivel = value; }
            public float Puntaje { get => puntaje; set => puntaje = value; }

            public PersonajeEnHistorial(){
                nombreJugador = "VACIO";
                nombrePersonaje = "VACIO";
                nivel = 0;
                puntaje = 0;
            }
        }

}

