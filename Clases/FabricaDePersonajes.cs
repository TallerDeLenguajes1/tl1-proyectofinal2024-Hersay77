using EspacioPersonajes;

namespace EspacioFabricaDePersonajes
{
    public class FabricaDePersonjaes
    {
        public static Personaje CrearPersonaje(string nombre, string apodo, DateTime fecha, int edad, string descripcion, Serie serieDelPersonaje, int velocidad, int destreza, int fuerza, int armadura)
        {
            Personaje nuevoPersonaje = new Personaje();
            nuevoPersonaje.DatosPersonaje = new Datos(); //como datos es una clase debo crear una instancia
            nuevoPersonaje.DatosPersonaje.Nombre = nombre;
            nuevoPersonaje.DatosPersonaje.Apodo = apodo;
            nuevoPersonaje.DatosPersonaje.Fecha = fecha;
            nuevoPersonaje.DatosPersonaje.Edad = edad;
            nuevoPersonaje.DatosPersonaje.Descripcion = descripcion;
            nuevoPersonaje.DatosPersonaje.SerieDelPersonaje = serieDelPersonaje;
            nuevoPersonaje.CaracteristicasPersonaje = new Caracteristicas(); //como Caracteristicas es una clase debo crear una instancia
            nuevoPersonaje.CaracteristicasPersonaje.Velocidad = velocidad;
            nuevoPersonaje.CaracteristicasPersonaje.Destreza = destreza;
            nuevoPersonaje.CaracteristicasPersonaje.Fuerza = fuerza;
            nuevoPersonaje.CaracteristicasPersonaje.Nivel = ValorAleatorio(1, 11);
            nuevoPersonaje.CaracteristicasPersonaje.Armadura = armadura;
            nuevoPersonaje.CaracteristicasPersonaje.Salud = 100;

            return nuevoPersonaje; 
        }

        public static List<Personaje> CrearPersonajes(List<Personaje> ListaDatosPredefinidos )
        {
            List<Personaje> ListaPersonajes = new List<Personaje>(); //creo lista de personajes

            return ListaPersonajes;
        }

        public static int ValorAleatorio(int min, int max){
            Random numeroRandom = new Random();
            return numeroRandom.Next(min, max);
        }
    }

}