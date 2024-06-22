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
                Console.WriteLine($"DEFENSA: {ListaPersonajes[i].CaracteristicasPersonaje.Defensa}");
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
            int ataque;
            int efectividad;
            int defensa;
            const int ajuste = 500;
            float danioProvocado;

            do
            {
                if (turno == 1 )
                {
                    
                    

                    //5) El que gane es beneficiado con una mejora en sus habilidades.por ejemplo: +10 en salud o +5 en defensa.
                    turno = 0; //cambio el turno
                }
                else
                {
                    turno = 1; //cambio el turno
                }

            } while (jugador1.CaracteristicasPersonaje.Salud != 0 || jugador2.CaracteristicasPersonaje.Salud != 0); //continua hasta que uno tenga salud 0


            if (jugador1.CaracteristicasPersonaje.Salud != 0) //retorna true si gano
            {
                return true;
            }
            else
            {
                return false;
            }
        }















    }
}