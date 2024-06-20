using EspacioPersonajes;

namespace EspacioFabricaDePersonajes
{
    public class FabricaDePersonjaes
    {
        public static Personaje CrearPersonaje(string nombre, string apodo, DateTime fecha, int edad, string descripcion, Serie serieDelPersonaje)
        {
            Personaje nuevoPersonaje = new Personaje();
            nuevoPersonaje.DatosPersonaje.Nombre = nombre;
            nuevoPersonaje.DatosPersonaje.Apodo = apodo;
            nuevoPersonaje.DatosPersonaje.Fecha = fecha;
            nuevoPersonaje.DatosPersonaje.Edad = edad;
            nuevoPersonaje.DatosPersonaje.Descripcion = descripcion;
            nuevoPersonaje.DatosPersonaje.SerieDelPersonaje = serieDelPersonaje;
            nuevoPersonaje.CaracteristicasPersonaje.Velocidad = ValorAleatorio(1, 11);
            nuevoPersonaje.CaracteristicasPersonaje.Destreza = ValorAleatorio(1, 6);
            nuevoPersonaje.CaracteristicasPersonaje.Fuerza = ValorAleatorio(1, 11);
            nuevoPersonaje.CaracteristicasPersonaje.Nivel = ValorAleatorio(1, 11);
            nuevoPersonaje.CaracteristicasPersonaje.Defensa = ValorAleatorio(1, 11);
            nuevoPersonaje.CaracteristicasPersonaje.Salud = 100;

            return nuevoPersonaje; 
        }

        public static int ValorAleatorio(int min, int max){
            Random numeroRandom = new Random();
            return numeroRandom.Next(min, max);
        }
    }


}