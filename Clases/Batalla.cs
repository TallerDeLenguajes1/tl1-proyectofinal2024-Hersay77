using EspacioPersonajes;
using EspacioFabricaDePersonajes;

namespace EspacioBatalla
{
    public class Batalla
    {
        public static bool GenerarBatalla(Personaje jugador1, Personaje jugador2, float bonificacion) //METODO SIMULA BATALLA
        {
            var turno = 1;
            int ataque; //Ataque: Destreza * Fuerza * Nivel (del personaje que ataca) * bonificacion
            int efectividad;//Valor aleatorio entre 1 y 100.
            int defensa; //armadura * Velocidad (del personaje que defiende)
            const int ajuste = 500; //constante de ajuste
            float danioProvocado; //(Ataque * Efectividad) - Defensa) / constante de ajuste

            while (true) //repite siempre la batalla, sale del bucle por los if que verifican la salud
            {
                if (turno == 1 )
                {               
                    Thread.Sleep(700);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("---------------TU TURNO----------ATACANDO! >>>>>>>>>");
                    Console.ResetColor();
                    ataque = (jugador1.CaracteristicasPersonaje.Destreza) * (jugador1.CaracteristicasPersonaje.Fuerza) * (jugador1.CaracteristicasPersonaje.Nivel) + (int)bonificacion;
                    efectividad = FabricaDePersonjaes.ValorAleatorio(1, 101); //efectividad es aleatoria
                    Console.WriteLine($"TU EFECTIVIDAD DE ATAQUE: {efectividad}");
                    defensa = (jugador2.CaracteristicasPersonaje.Armadura) * (jugador2.CaracteristicasPersonaje.Velocidad);
                    danioProvocado = ((ataque * efectividad) - defensa) / ajuste;
                    jugador2.CaracteristicasPersonaje.Salud = (jugador2.CaracteristicasPersonaje.Salud) - danioProvocado;
                    Console.WriteLine($"DANIO PROVOCADO: {danioProvocado}");
                    //Verificando salud 
                    if (jugador2.CaracteristicasPersonaje.Salud <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("=============>>>>       LO DERROTASTE      <<<<============= ");
                        Console.WriteLine("=============>>>> HAS GANADO LA BATALLA!!! <<<<============= ");
                        Console.ResetColor();                       
                        return true; //retorna true si gano, sale de la batalla
                    }
                    Console.WriteLine($"SALUD DEL ENEMIGO: {jugador2.CaracteristicasPersonaje.Salud}");
                    turno = 0; //cambio el turno
                }
                else
                {
                    Thread.Sleep(700);  
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("---------------TURNO ENEMIGO----------DEFENDIENDO! <<<<<<<<<<<");
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
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("=============>>>>      TE DERROTARON :(     <<<<============= ");
                        Console.WriteLine("=============>>>> HAS PERDIDO LA BATALLA!!! <<<<============= ");
                        Console.ResetColor();       
                        return false; //retorna false si perdiste la batalla, saliendo de la batalla
                    }
                    Console.WriteLine($"TU SALUD: {jugador1.CaracteristicasPersonaje.Salud}");  
                    turno = 1; //cambio el turno
                }
            } 
        }

    }
}