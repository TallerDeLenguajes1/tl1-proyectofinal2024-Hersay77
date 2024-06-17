namespace EspacioPersonajes
{
    public class Personaje
    {
        private Caracteristicas CaracteristicasPersonaje;  
        private Datos datosPeronaje;
 
        public Caracteristicas CaracteristicasPersonaje1 { get => CaracteristicasPersonaje; set => CaracteristicasPersonaje = value; }
        public Datos DatosPeronaje { get => DatoPeronaje; set => DatoPeronaje = value; }

    }

    public class Caracteristicas
    {
        int velocidad; //1 a 10
        int destreza; //1 a 5
        int fuerza; //1 a 10
        int nivel; //1 a 10
        int armadura; //1 a 10
        int salud; //100

        public global::System.Int32 Velocidad { get => velocidad; set => velocidad = value; }
        public global::System.Int32 Destreza { get => destreza; set => destreza = value; }
        public global::System.Int32 Fuerza { get => fuerza; set => fuerza = value; }
        public global::System.Int32 Nivel { get => nivel; set => nivel = value; }
        public global::System.Int32 Armadura { get => armadura; set => armadura = value; }
        public global::System.Int32 Salud { get => salud; set => salud = value; }
    }

    public class Datos
    {
        tipo Tipo;
        string Nombre;
        string Apodo;
        DateTime FechadeNacimiento;
        int Edad; 
    }

    public enum tipo
    {

    }
}