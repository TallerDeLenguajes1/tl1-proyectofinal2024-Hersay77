using EspacioPersonajes;

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

        public bool GenerarBatalla(Personaje jugador1, Personaje jugador2)
        {

            //BATALLA

            if ()
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