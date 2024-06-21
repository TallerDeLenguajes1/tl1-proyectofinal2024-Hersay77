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


static void MostrarPersonajes(List<Personaje> ListaPersonajes){
    Console.WriteLine("################# MOSTRANDO LISTA DE PERSONAJES ################");
    foreach (var personaje in ListaPersonajes)
    {
        Console.WriteLine("###########################################################");
        Console.WriteLine($"NOMBRE: {personaje.DatosPersonaje.Nombre}");
        Console.WriteLine($"APODO: {personaje.DatosPersonaje.Apodo}");
        Console.WriteLine($"FECHA DE NACIMIENTO: {personaje.DatosPersonaje.Fecha.ToShortDateString()}");
        Console.WriteLine($"EDAD: {personaje.DatosPersonaje.Edad}");
        Console.WriteLine($"DESCRIPCION: {personaje.DatosPersonaje.Descripcion}");
        Console.WriteLine($"SERIE: {personaje.DatosPersonaje.SerieDelPersonaje}");
        Console.WriteLine($"VELOCIDAD: {personaje.CaracteristicasPersonaje.Velocidad}");
        Console.WriteLine($"DESTREZA: {personaje.CaracteristicasPersonaje.Destreza}");
        Console.WriteLine($"FUERZA: {personaje.CaracteristicasPersonaje.Fuerza}");
        Console.WriteLine($"NIVEL: {personaje.CaracteristicasPersonaje.Nivel}");
        Console.WriteLine($"DEFENSA: {personaje.CaracteristicasPersonaje.Defensa}");
        Console.WriteLine($"SALUD: {personaje.CaracteristicasPersonaje.Salud}");
        Console.WriteLine("###########################################################");
    }
}

