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










    }
}