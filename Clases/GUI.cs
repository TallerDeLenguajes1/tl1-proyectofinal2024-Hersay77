using EspacioGestorArchivos;
using EspacioPersonajes;

namespace EspacioGUI
{
    public class GUI
    {
        //METODO DINAMICO PARA MOSTRAR TXTs o ARTE ASCII
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

        //METODO DINAMICO PRESIONAR UNA TECLA PARA CONTINUAR
        public void MostrarPresionarTecla(){
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("###################=========>   PRESIONE UNA TECLA PARA INICIAR <===========######################");
            Console.ResetColor();
            Console.ReadKey();
        }

        //METODO DINAMICO MOSTRAR MENU PRINCIPAL
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

        //METODO DINAMICO MOSTRAR PERSONAJES
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
                    case "Rey-Del-Norte":
                        Console.ForegroundColor = ConsoleColor.Red; 
                        archivo = "ArchivosTxt/Rey-Del-Norte.txt";
                        MostrarTxt(archivo, 0);
                    break;
                    case "Madre-De-Dragones":
                        Console.ForegroundColor = ConsoleColor.DarkRed; 
                        archivo = "ArchivosTxt/Madre-De-Dragones.txt";
                        MostrarTxt(archivo, 0);
                    break;
                    case "El-Mejor-Jefe-Del-Mundo":
                        Console.ForegroundColor = ConsoleColor.Cyan; 
                        archivo = "ArchivosTxt/El-Mejor-Jefe-Del-Mundo.txt";
                        MostrarTxt(archivo, 0);
                    break;
                    case "El-Asistente-Regional":
                        Console.ForegroundColor = ConsoleColor.DarkCyan; 
                        archivo = "ArchivosTxt/El-Asistente-Regional.txt";
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
                Console.WriteLine($"    NUMERO: {i+1} - NOMBRE: {ListaPersonajes[i].DatosPersonaje.Nombre} - APODO: {ListaPersonajes[i].DatosPersonaje.Apodo}");
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
            Console.ResetColor();
        }
    
        //METODO DINAMICO MOSTRAR VERSUS
        public void MostrarVS(Personaje jugador1, Personaje jugador2){
            Console.ForegroundColor = ConsoleColor.Red; 
            MostrarTxt($"ArchivosTxt/{jugador1.DatosPersonaje.Apodo}.txt", 0);
            Thread.Sleep(700);

            Console.WriteLine(@"
 __     __  ____  
 \ \   / / / ___| 
  \ \ / /  \___ \ 
   \ V /    ___) |
    \_/    |____/");
            Thread.Sleep(700);
            MostrarTxt($"ArchivosTxt/{jugador2.DatosPersonaje.Apodo}.txt", 0);
            Thread.Sleep(700);
            Console.WriteLine(" ");
            Console.ResetColor();
        }

        //MOSTRAR PARTIDA GANADA
        public void MostrarPartidaGanada(){
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"
▄██████░▄████▄░██████▄░▄████▄░▄██████░████████░▄█████
██░░░░░░██░░██░██░░░██░██░░██░██░░░░░░░░░██░░░░██░░░░
██░░███░██░░██░██░░░██░██░░██░▀█████▄░░░░██░░░░█████░
██░░░██░██████░██░░░██░██████░░░░░░██░░░░██░░░░██░░░░
▀█████▀░██░░██░██░░░██░██░░██░██████▀░░░░██░░░░▀█████
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
                ██░░░░░▄████▄
                ██░░░░░██░░██
                ██░░░░░██░░██
                ██░░░░░██████
                ██████░██░░██
                ░░░░░░░░░░░░░
█████▄░▄████▄░█████▄░████████░██████░██████▄░▄████▄░░░██░██░██
██░░██░██░░██░██░░██░░░░██░░░░░░██░░░██░░░██░██░░██░░░██░██░██
█████▀░██░░██░█████▀░░░░██░░░░░░██░░░██░░░██░██░░██░░░██░██░██
██░░░░░██████░██░░██░░░░██░░░░░░██░░░██░░░██░██████░░░░░░░░░░░
██░░░░░██░░██░██░░██░░░░██░░░░██████░██████▀░██░░██░░░██░██░██
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
            ");
        Console.ResetColor();
        }
    
        //MOSTRAR GAME OVER
        public void MostrarGameOver(){

            Console.ForegroundColor = ConsoleColor.Red;
        
            Console.WriteLine(@"

▄██████░▄████▄░▄██▄▄██▄░▄█████░░░▄█████▄░██░░░██░▄█████░█████▄
██░░░░░░██░░██░██░██░██░██░░░░░░░██░░░██░██░░░██░██░░░░░██░░██
██░░███░██░░██░██░██░██░█████░░░░██░░░██░██░░░██░█████░░█████▀
██░░░██░██████░██░██░██░██░░░░░░░██░░░██░██░░██░░██░░░░░██░░██
▀█████▀░██░░██░██░██░██░▀█████░░░▀█████▀░▀███▀░░░▀█████░██░░██
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
            ");


        Console.ResetColor();       
        }
    
    //METODO DINAMICO MOSTRAR INICIO BATALLA
        public void MostrarInicioBatalla(int numeroBatalla){
        Console.ForegroundColor = ConsoleColor.Magenta; 
        Console.WriteLine($"\n°°°°°°°°°°°°°° INICIA LA BATALLA N°: {numeroBatalla}°°°°°°°°°°°°°°°°°°\n");
        Thread.Sleep(700);
        }

    //METODO DINAMICO MOSTRAR PUNTAJE ACUMULADO
      public void MostrarPuntaje(float puntaje){
            Console.ForegroundColor = ConsoleColor.White; 
            Console.WriteLine($"\nPUNTAJE ACUMULADO: {puntaje}\n");
            Thread.Sleep(700);
            Console.ResetColor();
        }
    
        //METODO MOSTRAR GANADOR TORNEO
        public void MostrarGanador(Personaje jugador){
                        Console.WriteLine(@"
   ___   _   _  _   _   ___   ___  ___   ___  ___ _      _____ ___  ___  _  _  ___  
  / __| /_\ | \| | /_\ |   \ / _ \| _ \ |   \| __| |    |_   _| _ \/ _ \| \| |/ _ \ 
 | (_ |/ _ \| .` |/ _ \| |) | (_) |   / | |) | _|| |__    | | |   / (_) | .` | (_) |
  \___/_/ \_\_|\_/_/ \_\___/ \___/|_|_\ |___/|___|____|   |_| |_|_\\___/|_|\_|\___/ 
                ");

                MostrarTxt($"ArchivosTxt/{jugador.DatosPersonaje.Apodo}.txt", 0);
        }

    }


}