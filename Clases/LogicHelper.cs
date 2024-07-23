using EspacioPersonajes;

namespace EspacioLogicHelper
{
    public class LogicHelper
    {
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

        








    }
}