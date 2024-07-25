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

        //METODO DINAMICO VERIFICAR Y CREAR ARCHIVOS PARA EL INICIO DEL JUEGO
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
                
                if (int.TryParse(entrada, out numero) && numero >= 0 && numero <= 11)
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

        //METODO CONSULTA SI SABE NOMBRE DE EPISODIOS
        public int SabeNombre(){
            Console.WriteLine(@"
╔═════════════════════════════════════════════════════════════════════════════════════════════════════════╗
║     POR CADA BATALLA TIENE LA POSIBILIDAD DE AUMENTAR SU ATAQUE A TRAVES DEL BONUS POR EPISODIO!!!      ║
║                                                                                                         ║
║     SI SABE EL NOMBRE DE LOS EPISODIOS DE LA SERIE DEL PERSONAJE QUE ELIGIO PRESIONE ---> 1             ║
║     DE OTRO MODO LOS EPISODIOS SERAN ELEGIDOS DE UNA LISTA DE LOS MISMOS POR UN NUMERO ALEATORIO        ║
║                                                                                                         ║
║     TODOS LOS EPISODIOS TIENEN UN RATING QUE SE OBTIENE DE UNA WEB QUE CALCULA EL PROMEDIO DE           ║
║     VISTAS AL EPISODIO Y A TRAVES DE ESTE RATING SU PERSONAJE PUEDE AUMENTAR SU ATAQUE!!!               ║
╚═════════════════════════════════════════════════════════════════════════════════════════════════════════╝");

        int numero;
            while (true) //aseguro que el bucle siempre se repita a menos que entre al if 
            {
                Console.WriteLine("Presione 1 si conoce los nombres de los episodios, sino presione 0: ");
                string entrada = Console.ReadLine();
                
                if (int.TryParse(entrada, out numero))
                {
                    Console.WriteLine("SELECCIONASTE LA OPCION: " + numero);
                    if (numero == 1)
                    {
                        Console.WriteLine("DEBERAS INGRESAR UNA PALABRA QUE COINCIDA CON EL NOMBRE DE UN EPISODIO PARA LA BONIFICACION POR BATALLA");
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        Console.WriteLine("LA ASIGNACION DE LOS EPISODIOS SERA ALEATORIA");
                        Thread.Sleep(1000);
                    }
                    return numero;
                }
                else
                {
                    Console.WriteLine("Entrada no válida. Intente de nuevo.");
                }
            }
        }

        //METODO DINAMICO PARA CALCULAR BONIFICACION SEGUN API Y MOSTRAR
        public float BonificacionAuto(List<Episodio> episodios)
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
            float bonificacion = 0;
            bonificacion += 2 *(float)(rating); 
            Console.WriteLine($"===>>BONIFICACION: {bonificacion}");
            Console.ResetColor();
            Thread.Sleep(1500);
            return bonificacion;
        }

        //METODO DINAMICO PARA CALCULAR BONIFICACION SEGUN API Y MOSTRAR MANUALMENTE
        public float BonificacionManual(List<Episodio> episodios)
        {
            Console.WriteLine("Ingrese el nombre del episodio: ");
            var NombreABuscar = Console.ReadLine();

            Episodio EpisodioEncontrado = episodios.Find(t => t.Name == NombreABuscar); //uso metodo Find proporcionado por List<t>, devuelve el tipo t, enste caso Episodio si se cumple Episodio => Episodio.Name == NombreABuscar sino devuelve null

            if (EpisodioEncontrado != null)
            {
                Console.WriteLine($"Episodio Enocntrado: {EpisodioEncontrado.Name}");
                episodios.Remove(EpisodioEncontrado); //elimminio de la lista asi no se pueda volver a usar
                Console.ForegroundColor = ConsoleColor.Yellow; 
                Console.WriteLine(@"
    ╔═════════════════════════════════════════════════════╗
    ║              BONIFICACION POR ESPISODIO             ║
    ╚═════════════════════════════════════════════════════╝");
                Console.WriteLine($"===>>EPISODIO ALEATORIO: {EpisodioEncontrado.Name}");
                Console.WriteLine($"===>>RATING DEL EPISODIO: {EpisodioEncontrado.Rating.Average}");
                double? rating = EpisodioEncontrado.Rating.Average; //rating del episodio - //corrigiendo a veces devuelve null  - la api
                float bonificacion = 0;
                bonificacion += 2 *(float)(rating); 
                Console.WriteLine($"===>>BONIFICACION: {bonificacion}");
                Console.ResetColor();
                Thread.Sleep(700);
                return bonificacion;
            }
            else
            {
                Console.WriteLine("Episodio NO encontrado, se asigna uno aleatorio");
                return (BonificacionAuto(episodios));
            }


        }

      

    }
}