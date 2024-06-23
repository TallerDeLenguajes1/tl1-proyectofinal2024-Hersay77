using EspacioPersonajes;
using EspacioFabricaDePersonajes;
using EspacioClaseListaEpisdios;
using EspacioGestorArchivos;
using System.Diagnostics;

namespace EspacioMetodosPrincipales
{
    public class MetodosPrincipales
    {    
        public void MostrarPersonajes(List<Personaje> ListaPersonajes) //METODO MOSTAR PERSONAJES
        {
            Console.WriteLine("╔════════════════════════MOSTRANDO LISTA DE PERSONAJES═════════════════════════════╗");

            for (int i = 0; i < ListaPersonajes.Count; i++)
            {
                string archivo;

                switch (ListaPersonajes[i].DatosPersonaje.Apodo)
                {
                    case "Heisenberg":
                        Console.ForegroundColor = ConsoleColor.Green; 
                        archivo = "ArchivosTxt/Heisenberg.txt";
                        MostrarTxt(archivo, 0);
                    break;
                    case "Jesse":
                        Console.ForegroundColor = ConsoleColor.DarkGreen; 
                        archivo = "ArchivosTxt/Jesse.txt";
                        MostrarTxt(archivo, 0);
                    break;
                    case "House":
                        Console.ForegroundColor = ConsoleColor.Blue; 
                        archivo = "ArchivosTxt/House.txt";
                        MostrarTxt(archivo, 0);
                    break;
                    case "Wilson":
                        Console.ForegroundColor = ConsoleColor.DarkBlue; 
                        archivo = "ArchivosTxt/Wilson.txt";
                        MostrarTxt(archivo, 0);
                    break;
                    case "Rey Del Norte":
                        Console.ForegroundColor = ConsoleColor.Red; 
                        archivo = "ArchivosTxt/ReyDelNorte.txt";
                        MostrarTxt(archivo, 0);
                    break;
                    case "Madre De Dragones":
                        Console.ForegroundColor = ConsoleColor.DarkRed; 
                        archivo = "ArchivosTxt/MadreDeDragones.txt";
                        MostrarTxt(archivo, 0);
                    break;
                    case "El Mejor Jefe Del Mundo":
                        Console.ForegroundColor = ConsoleColor.Cyan; 
                        archivo = "ArchivosTxt/ElMejorJefeDelMundo.txt";
                        MostrarTxt(archivo, 0);
                    break;
                    case "El Asistente Regional":
                        Console.ForegroundColor = ConsoleColor.DarkCyan; 
                        archivo = "ArchivosTxt/ElAsistenteRegional.txt";
                        MostrarTxt(archivo, 0);
                    break;
                    case "Malcolm":
                        Console.ForegroundColor = ConsoleColor.Yellow; 
                        archivo = "ArchivosTxt/Malcolm.txt";
                        MostrarTxt(archivo, 0);
                    break;
                    case "Lois":
                        Console.ForegroundColor = ConsoleColor.DarkYellow; 
                        archivo = "ArchivosTxt/Lois.txt";
                        MostrarTxt(archivo, 0);
                    break;
                    case "Chandler":
                        Console.ForegroundColor = ConsoleColor.Magenta; 
                        archivo = "ArchivosTxt/Chandler.txt";
                        MostrarTxt(archivo, 0);
                    break;
                    case "Rachel":
                        Console.ForegroundColor = ConsoleColor.DarkMagenta; 
                        archivo = "ArchivosTxt/Rachel.txt";
                        MostrarTxt(archivo, 0);
                    break;
                    default:
                    break;
                }
                Console.WriteLine("");
                Console.WriteLine($"    NUMERO: {i} - NOMBRE: {ListaPersonajes[i].DatosPersonaje.Nombre} - APODO: {ListaPersonajes[i].DatosPersonaje.Apodo}");
                Console.WriteLine($"    FECHA: {ListaPersonajes[i].DatosPersonaje.Fecha.ToShortDateString()} - EDAD: {ListaPersonajes[i].DatosPersonaje.Edad}");
                Console.WriteLine($"    DESCRIPCION: {ListaPersonajes[i].DatosPersonaje.Descripcion}");
                Console.WriteLine($"    SERIE: {ListaPersonajes[i].DatosPersonaje.SerieDelPersonaje}");
                Console.WriteLine($"    VELOCIDAD: {ListaPersonajes[i].CaracteristicasPersonaje.Velocidad}");
                Console.WriteLine($"    DESTREZA: {ListaPersonajes[i].CaracteristicasPersonaje.Destreza}");
                Console.WriteLine($"    FUERZA: {ListaPersonajes[i].CaracteristicasPersonaje.Fuerza}");
                Console.WriteLine($"    NIVEL: {ListaPersonajes[i].CaracteristicasPersonaje.Nivel}");
                Console.WriteLine($"    DEFENSA: {ListaPersonajes[i].CaracteristicasPersonaje.Armadura}");
                Console.WriteLine($"    SALUD: {ListaPersonajes[i].CaracteristicasPersonaje.Salud}");
                Console.WriteLine("     ══════════════════════════════════════════════════════════════");
                Console.WriteLine("");
                Thread.Sleep(1000);
            }
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════════╝");

        }

        public int ElegirOpcion() //METODO ELEGIR 
        {
            int numero;
            while (true) //aseguro que el bucle siempre se repita a menos que entre al if y retorne el numero elegido
            {
                Console.WriteLine("ELIGE LA OPCION: ");
                string entrada = Console.ReadLine();
                
                if (int.TryParse(entrada, out numero))
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

        public bool GenerarBatalla(Personaje jugador1, Personaje jugador2) //METODO SIMULA BATALLA
        {

            /*var turno = FabricaDePersonjaes.ValorAleatorio(1, 3); //uso metodo estatico de fabrica de personajes para generar numero aleatorio
            Console.WriteLine(turno == 1 ? "INICIAS ATACANDO !!!" : "INICIA ATACANDO EL ENEMIGO!!!");*/
            var turno = 1;
            int ataque; //Ataque: Destreza * Fuerza * Nivel (del personaje que ataca)
            int efectividad;//Valor aleatorio entre 1 y 100.
            int defensa; //armadura * Velocidad (del personaje que defiende)
            const int ajuste = 500; 
            float danioProvocado; //(Ataque * Efectividad) - Defensa) / constante de ajuste
            do
            {
                if (turno == 1 )
                {
                    Console.WriteLine("---------------TU TURNO---------------");
                    ataque = (jugador1.CaracteristicasPersonaje.Destreza) * (jugador1.CaracteristicasPersonaje.Fuerza) * (jugador1.CaracteristicasPersonaje.Nivel);
                    efectividad = FabricaDePersonjaes.ValorAleatorio(1, 101);
                    Console.WriteLine($"TU EFECTIVIDAD DE ATAQUE: {efectividad}");
                    defensa = (jugador2.CaracteristicasPersonaje.Armadura) * (jugador2.CaracteristicasPersonaje.Velocidad);

                    danioProvocado = ((ataque * efectividad) - defensa) / ajuste;
                    jugador2.CaracteristicasPersonaje.Salud = (jugador2.CaracteristicasPersonaje.Salud) - danioProvocado;
                    Console.WriteLine($"DANIO PROVOCADO: {danioProvocado}");
                    //Verificando salud 
                    if (jugador2.CaracteristicasPersonaje.Salud <= 0)
                    {
                        Console.WriteLine("¡Lo derrotaste!");
                        break;
                    }
                    Console.WriteLine($"SALUD DEL ENEMIGO: {jugador2.CaracteristicasPersonaje.Salud}");
                    turno = 0; //cambio el turno
                }
                else
                {
                    Console.WriteLine("---------------TURNO ENEMIGO---------------");
                    ataque = (jugador2.CaracteristicasPersonaje.Destreza) * (jugador2.CaracteristicasPersonaje.Fuerza) * (jugador2.CaracteristicasPersonaje.Nivel);
                    efectividad = FabricaDePersonjaes.ValorAleatorio(1, 101);
                    Console.WriteLine($"EFECTIVIDAD DE ATAQUE DEL ENEMIGO: {efectividad} ");
                    defensa = (jugador1.CaracteristicasPersonaje.Armadura) * (jugador1.CaracteristicasPersonaje.Velocidad);

                    danioProvocado = ((ataque * efectividad) - defensa) / ajuste;
                    jugador1.CaracteristicasPersonaje.Salud = (jugador1.CaracteristicasPersonaje.Salud) - danioProvocado;
                    Console.WriteLine($"DANIO PROVOCADO: {danioProvocado}");
                    //Verificando salud
                    if (jugador1.CaracteristicasPersonaje.Salud <= 0)
                    {
                        Console.WriteLine("¡Fuiste derrotado!");
                        break;
                    }
                    Console.WriteLine($"TU SALUD: {jugador1.CaracteristicasPersonaje.Salud}");  
                    turno = 1; //cambio el turno
                }

            } while (jugador1.CaracteristicasPersonaje.Salud > 0 && jugador2.CaracteristicasPersonaje.Salud > 0); //continua mientras la salud de ambos jugadores siga positiva


            if (jugador1.CaracteristicasPersonaje.Salud > 0) //retorna true si gano
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string ObtenerUrl(Serie serie)
        {
            string url;
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

        public double ObtenerRating(List<Episodio> episodios){
            
            var valorAleatorio = FabricaDePersonjaes.ValorAleatorio(0 , episodios.Count);

            Console.WriteLine($"===>>EPISODIO ALEATORIO: {episodios[valorAleatorio].Name}");
            Console.WriteLine($"===>>RATING DEL EPISODIO: {episodios[valorAleatorio].Rating.Average}");
            double rating = episodios[valorAleatorio].Rating.Average; 
            return rating;
        }
    
        public void MostrarTxt(string archivo, int retraso) //METODO PARA MOSTRAR TXT O TITULOS
        {
            var GestorArchivos = new GestorDeArchivos(); 
            if(GestorArchivos.Existe(archivo)) //compruebo si existe el archivo
            {
                var documentotxt = GestorArchivos.AbrirArchivoTexto(archivo); //leo el archivo
                foreach (var caracter in documentotxt) //recorro caracter por caracter para hacer mas lenta la muestra
                {
                    Console.Write(caracter);
                    Thread.Sleep(retraso);
                }
            }
            else
            {
                Console.WriteLine("#ERROR: El Archivo txt no existe");
            }
        }

        public void MostrarMenu()
        {

            
            //El símbolo @ se usa antes de una cadena en C# para indicar que es una cadena literal (verbatim string literal). Esto permite incluir caracteres especiales, como barras invertidas (\)
            string menu = @"
                    ╔═════════════════════════════════════════════════════╗
                    ║               M E N Ú   P R I N C I P A L           ║
                    ╠═════════════════════════════════════════════════════╣
                    ║ 1. SELECCIONAR - MOSTRAR LISTA DE PERSONAJES        ║
                    ║ 2. MOSTRAR RANKING - HISTORIAL                      ║
                    ║ 3. SALIR                                            ║
                    ╚═════════════════════════════════════════════════════╝
                    ";
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(menu);
            Console.ResetColor();
        }
    
    }
}