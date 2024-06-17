namespace EspacioPersonajes
{
    public class Personaje
    {
        private Caracteristicas caracteristicasPersonaje;  
        private Datos datosPeronaje;
 
        public Caracteristicas CaracteristicasPersonaje { get => CaracteristicasPersonaje; set => CaracteristicasPersonaje = value; }
        public Datos DatosPeronaje { get => DatoPeronaje; set => DatoPeronaje = value; }

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
        public int defensa { get => armadura; set => armadura = value; }
        public int Salud { get => salud; set => salud = value; }
    }

    public class Datos
    {
        private serie seriePersonaje;
        private string nombre;
        private string apodo;
        private DateTime fechadeNacimiento;
        private int edad;
        private string descripcion; 
    }

    public enum serie
    {
        BreakingBad = 0;
        HouseMD = 1;
        GameOfThrones = 2;
        TheOffice = 3;
        MalcolmInTheMiddle = 4;
        Friends = 5;
        ElchavoDel8 = 6;
    }
}