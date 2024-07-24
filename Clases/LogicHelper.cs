using EspacioPersonajes;
using EspacioClaseListaEpisdios;
using EspacioFabricaDePersonajes;
using EspacioHistorialJson;
using EspacioPersonajesJson;

namespace EspacioLogicHelper
{
    public class LogicHelper
    {
        private List<Personaje> listaPersonajes;
        private List<PersonajeEnHistorial> historial;
        private bool guardado = true; ////variable para identificar el correcto guardado de archivos de personajes. Inicia en true por si ya se habia guardado anteriormente por primera vez los personajes (si ya esta creada ListaPersonajes.json en una misma sesion)

        //RUTAS DE ARCHIVOS
        private string archivoListaPersonajes = "Archivos/ListaPersonajes.json"; 
        private string archivoHistorial = "Archivos/Historial.json";
        private string portada = "ArchivosTxt/Portada.txt";
        private string archivoDatosPersonajes = "Archivos/DatosPersonajes.json";

        public List<Personaje> ListaPersonajes { get => listaPersonajes; set => listaPersonajes = value; }
        public List<PersonajeEnHistorial> Historial { get => historial; set => historial = value; }
        public bool Guardado { get => guardado; set => guardado = value; }
        public string ArchivoListaPersonajes { get => archivoListaPersonajes; }
        public string ArchivoHistorial { get => archivoHistorial;  }
        public string Portada { get => portada; }
        public string ArchivoDatosPersonajes { get => archivoDatosPersonajes; }

        public void VerificarYCrearArchivos(){
            
            if (PersonajesJson.Existe(ArchivoListaPersonajes)) ////Verificar al comienzo del Juego si existe el archivo de personajes
            {
                ListaPersonajes = PersonajesJson.LeerPersonajes(ArchivoListaPersonajes); //lee lista de personajes, sino retorna null
                Historial = HistorialJson.LeerGanadores(ArchivoHistorial); //se lee el historial, sino retorna null
            }
            else
            {
                ListaPersonajes = PersonajesJson.GenerarPersonajesPreestablecidos(ArchivoDatosPersonajes); //Crea la lista de personajes desde 0 con DatosPersonajes.json (archivo que contiene datos de personajes preestablecidos)
                Guardado = PersonajesJson.GuardarPersonajes(ListaPersonajes, ArchivoListaPersonajes); //el metodo guarda la lista de personajes en json y devuelve true si se completo el guardado
                Historial = HistorialJson.LeerGanadores(ArchivoHistorial); //lee el historial desde un json, si no retorna null
            }
        }















        //METODO DINAMICO PARA VERIFICAR LA CORRECTA OPCION DEL MENU
        public int ElegirOpcionMenu() //METODO ELEGIR 
        {
            int numero;
            while (true) //aseguro que el bucle siempre se repita a menos que entre al if y retorne el numero elegido
            {
                Console.WriteLine("ELIGE LA OPCION: ");
                string entrada = Console.ReadLine();
                
                if (int.TryParse(entrada, out numero) && numero >= 1 && numero <= 3)
                {
                    Console.WriteLine("SELECCIONASTE LA OPCION: " + numero);
                    return numero;
                }
                else
                {
                    Console.WriteLine("Entrada no válida. Intente de nuevo.");
                }
            }
        }

        //METODO DINAMICO ELEGIR OPCION DEL PERSONAJE
        public int ElegirOpcionPersonaje() 
        {
            int numero;
            while (true) //aseguro que el bucle siempre se repita a menos que entre al if y retorne el numero elegido
            {
                Console.WriteLine("ELIGE EL NUMERO DE PERSONAJE: ");
                string entrada = Console.ReadLine();
                
                if (int.TryParse(entrada, out numero) && numero >= 0 && numero <= 10)
                {
                    Console.WriteLine("SELECCIONASTE LA OPCION: " + numero);
                    return numero;
                }
                else
                {
                    Console.WriteLine("Entrada no válida o No existe el numero de personaje. Intente de nuevo.");
                }
            }
        }

        //METODO DINAMICO QUE OBTIENE URL SEGUN SERIE DEL PERSONAJE PARA API
        public string ObtenerUrl(Serie serie)
        {
            switch (serie)
            {
                case Serie.BreakingBad:
                    return "https://api.tvmaze.com/shows/169/episodes"; //url de API que retorna lista de episodios de la serie
                
                case Serie.HouseMD:
                    return "https://api.tvmaze.com/shows/118/episodes";

                case Serie.GameOfThrones:
                    return "https://api.tvmaze.com/shows/82/episodes";

                case Serie.TheOffice:
                    return "https://api.tvmaze.com/shows/526/episodes";

                case Serie.MalcolmInTheMiddle:
                    return "https://api.tvmaze.com/shows/568/episodes";

                case Serie.Friends:
                    return "https://api.tvmaze.com/shows/431/episodes";
                default:
                    return null;
            }
        }

        //METODO DINAMICO PARA CALCULAR BONIFICACION SEGUN API Y MOSTRAR
        public float Bonificacion(float puntaje, List<Episodio> episodios)
        {

            var valorAleatorio = FabricaDePersonjaes.ValorAleatorio(0 , episodios.Count); //obtengo valor aleatorio basado en cantidad de episodios
            Console.ForegroundColor = ConsoleColor.Yellow; 
            Console.WriteLine(@"
╔═════════════════════════════════════════════════════╗
║              BONIFICACION POR ESPISODIO             ║
╚═════════════════════════════════════════════════════╝");
            Console.WriteLine($"===>>EPISODIO ALEATORIO: {episodios[valorAleatorio].Name}");
            Console.WriteLine($"===>>RATING DEL EPISODIO: {episodios[valorAleatorio].Rating.Average}");
            double? rating = episodios[valorAleatorio].Rating.Average; //rating del episodio - //corrigiendo a veces devuelve null  - la api
            puntaje += 2 *(float)(rating); 
            Console.WriteLine($"===>>PUNTAJE NUEVO: {puntaje}");
            Console.ResetColor();
            Thread.Sleep(700);
            return puntaje;
        }

    }
}