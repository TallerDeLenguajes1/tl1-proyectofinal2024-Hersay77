using System;

namespace EspacioPersonajes
{
    public class Personaje
    {
        private Caracteristicas caracteristicasPersonaje;  
        private Datos datosPersonaje;

            public Caracteristicas CaracteristicasPersonaje { get => caracteristicasPersonaje; set => caracteristicasPersonaje = value; }
            public Datos DatosPersonaje { get => datosPersonaje; set => datosPersonaje = value; }

        public class FabricaDePersonajes
        {
        public Personaje GenerarPersonaje(string nombre, string apodo, DateTime fecha, int edad, string descripcion, Serie serieDelPersonaje, int velocidad, int fuerza, int nivel, int defensa, int salud)
            {
                Personaje personaje = new Personaje();
                    personaje.datosPersonaje = new Datos();
                        personaje.datosPersonaje.Nombre = nombre;
                        personaje.datosPersonaje.Apodo = apodo;
                        personaje.datosPersonaje.Fecha = fecha;
                        personaje.datosPersonaje.Edad = edad;
                        personaje.datosPersonaje.Descripcion = descripcion;
                        personaje.datosPersonaje.SerieDelPersonaje = serieDelPersonaje;
                    personaje.caracteristicasPersonaje = new Caracteristicas();
                        personaje.caracteristicasPersonaje.Velocidad = velocidad;
                        personaje.caracteristicasPersonaje.Fuerza = fuerza;
                        personaje.caracteristicasPersonaje.Nivel = nivel;
                        personaje.caracteristicasPersonaje.Defensa = defensa;
                        personaje.CaracteristicasPersonaje.Salud = salud;
                return personaje;
            }
        }

        public int GenerarValorAleatorio()
        {
            Random random = new Random();
            return random.Next(1, 10);
        }

    }

    public class Caracteristicas
    {
        int velocidad; //1 a 10
        int destreza; //1 a 5
        int fuerza; //1 a 10
        int nivel; //1 a 10
        int defensa; //1 a 10
        int salud; //100

            public int Velocidad { get => velocidad; set => velocidad = value; }
            public int Destreza { get => destreza; set => destreza = value; }
            public int Fuerza { get => fuerza; set => fuerza = value; }
            public int Nivel { get => nivel; set => nivel = value; }
            public int Defensa { get => defensa; set => defensa = value; }
            public int Salud { get => salud; set => salud = value; }
    }

    public class Datos
    { 
        private string nombre;
        private string apodo;
        private DateTime fecha;
        private int edad;
        private string descripcion;
        private Serie serieDelPersonaje;

            public string Nombre { get => nombre; set => nombre = value; }
            public string Apodo { get => apodo; set => apodo = value; }
            public DateTime Fecha { get => fecha; set => fecha = value; }
            public int Edad { get => edad; set => edad = value; }
            public string Descripcion { get => descripcion; set => descripcion = value; }
            public Serie SerieDelPersonaje { get => serieDelPersonaje; set => serieDelPersonaje = value; }
    }

    public enum Serie
    {
        BreakingBad = 0, 
        HouseMD = 1,
        GameOfThrones = 2,
        TheOffice = 3,
        MalcolmInTheMiddle = 4,
        Friends = 5,
        ElchavoDel8 = 6
    }
}