using EspacioPersonajesJson;
using EspacioPersonajes;
using System.Collections.Generic;
using EspacioHistorialJson;

string ArchivoListaPersonajes = "Archivos/ListaPersonajes.json";
string ArchivoHistorial = "Archivos/Historial.json";

List<Personaje> ListaPersonajes;
List<Personaje> Historial;
bool Guardado = true; //guardado inicia en true por si ya se habia guardado anteriormente por primera vez los personajes

if (PersonajesJson.Existe(ArchivoListaPersonajes))
{
    ListaPersonajes = PersonajesJson.LeerPersonajes(ArchivoListaPersonajes); //lee lista de personajes
    Historial = HistorialJson.LeerGanadores(ArchivoHistorial); //se lee el historial, sino retorna null
}
else
{
    ListaPersonajes = PersonajesJson.GenerarPersonajes(); //Crea la lista de personajes desde 0 con DatosPersonajesjson que arme con datos 
    Guardado = PersonajesJson.GuardarPersonajes(ListaPersonajes, ArchivoListaPersonajes); //el metodo guarda la lista de personajes en json y devuelve true si se completo el guardado
    //Historial = HistorialJson.LeerGanadores(ArchivoHistorial); //el metodo lee el historial desde un json, si no retorna null
}


/*if (ListaPersonajes == null || Historial == null || Guardado == false)
{
    Console.WriteLine("Error de programa: No se pudo cargar los datos");
}
else
{
    //MOSTAR MENU
}*/

MostrarPersonajes(ListaPersonajes);

//MOSTAR PERSONAJES
static void MostrarPersonajes(List<Personaje> ListaPersonajes){
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


    //SELECCION DE PERSONAJE

    int numero;
    bool esValido = false;

    while (!esValido)
    {
        Console.WriteLine("SELECCIONE EL PERSONAJE: ");
        string entrada = Console.ReadLine();
        
        if (int.TryParse(entrada, out numero))
        {
            esValido = true;
            Console.WriteLine("ELEGISTE EL PERSONAJE: " + numero);

        }
        else
        {
            Console.WriteLine("Entrada no válida. Intente de nuevo.");
        }
    }

}

