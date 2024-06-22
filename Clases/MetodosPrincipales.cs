using EspacioPersonajes;
using EspacioFabricaDePersonajes;

namespace EspacioMetodosPrincipales
{
    public class MetodosPrincipales
    {    
        public void MostrarPersonajes(List<Personaje> ListaPersonajes) //METODO MOSTAR PERSONAJES
        {
            Console.WriteLine("################# MOSTRANDO LISTA DE PERSONAJES ################");

            for (int i = 0; i < ListaPersonajes.Count; i++)
            {
                Console.WriteLine("###########################################################");
                Console.WriteLine($"NUMERO DE PERSONAJE: {i}");
                Console.WriteLine($"NOMBRE: {ListaPersonajes[i].DatosPersonaje.Nombre}");
                Console.WriteLine($"APODO: {ListaPersonajes[i].DatosPersonaje.Apodo}");
                Console.WriteLine($"FECHA DE NACIMIENTO: {ListaPersonajes[i].DatosPersonaje.Fecha.ToShortDateString()}");
                Console.WriteLine($"EDAD: {ListaPersonajes[i].DatosPersonaje.Edad}");
                Console.WriteLine($"DESCRIPCION: {ListaPersonajes[i].DatosPersonaje.Descripcion}");
                Console.WriteLine($"SERIE: {ListaPersonajes[i].DatosPersonaje.SerieDelPersonaje}");
                Console.WriteLine($"VELOCIDAD: {ListaPersonajes[i].CaracteristicasPersonaje.Velocidad}");
                Console.WriteLine($"DESTREZA: {ListaPersonajes[i].CaracteristicasPersonaje.Destreza}");
                Console.WriteLine($"FUERZA: {ListaPersonajes[i].CaracteristicasPersonaje.Fuerza}");
                Console.WriteLine($"NIVEL: {ListaPersonajes[i].CaracteristicasPersonaje.Nivel}");
                Console.WriteLine($"DEFENSA: {ListaPersonajes[i].CaracteristicasPersonaje.Armadura}");
                Console.WriteLine($"SALUD: {ListaPersonajes[i].CaracteristicasPersonaje.Salud}");
                Console.WriteLine("###########################################################");
            }
        }

        public int ElegirPersonaje() //METODO ELEGIR EL PERSONAJE
        {
            int numero;
            while (true) //aseguro que el bucle siempre se repita a menos que entre al if y retorne el numero elegido
            {
                Console.WriteLine("SELECCIONE EL PERSONAJE: ");
                string entrada = Console.ReadLine();
                
                if (int.TryParse(entrada, out numero))
                {
                    Console.WriteLine("ELEGISTE EL PERSONAJE: " + numero);
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

            var turno = FabricaDePersonjaes.ValorAleatorio(1, 3); //uso metodo estatico de fabrica de personajes para generar numero aleatorio
            Console.WriteLine(turno == 1 ? "INICIAS ATACANDO !!!" : "INICIA ATACANDO EL ENEMIGO!!!");
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

        public void Bonificacion(Serie serie)
        {
            switch (serie)
            {
                case Serie.BreakingBad:

                break;
                case Serie.HouseMD:
                break;
                case Serie.GameOfThrones:
                break;
                case Serie.TheOffice:
                break;  
                case Serie.MalcolmInTheMiddle:
                break;
                case Serie.Friends:
                break;
                default:
                break;
            }

        }


    }
}