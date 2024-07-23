using EspacioPersonajes;
using EspacioFabricaDePersonajes;
using EspacioClaseListaEpisdios;
using EspacioGestorArchivos;
using System.Diagnostics;

namespace EspacioMetodosPrincipales
{
    public class MetodosPrincipales
    {    
        


        public bool GenerarBatalla(Personaje jugador1, Personaje jugador2) //METODO SIMULA BATALLA
        {
            //codigo turno aleatorio
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
                    Thread.Sleep(700);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("---------------TU TURNO---------------");
                    Console.ResetColor();
                    ataque = (jugador1.CaracteristicasPersonaje.Destreza) * (jugador1.CaracteristicasPersonaje.Fuerza) * (jugador1.CaracteristicasPersonaje.Nivel);
                    efectividad = FabricaDePersonjaes.ValorAleatorio(1, 101); //efectividad es aleatoria
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
                    Thread.Sleep(700);  
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("---------------TURNO ENEMIGO---------------");
                    Console.ResetColor();
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

    }
}