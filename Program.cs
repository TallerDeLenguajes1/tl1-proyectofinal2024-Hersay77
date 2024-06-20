using EspacioPersonajesJson;
using EspacioPersonajes;
using System.Collections.Generic;
using EspacioHistorialJson;

string ArchivoListaPersonajes = "Archivos/ListaPersonajes.Json";
List<Personaje> ListaPersonajes;
List<Personaje> Historial;

if (PersonajesJson.Existe(ArchivoListaPersonajes))
{
    ListaPersonajes = PersonajesJson.LeerPersonajes(ArchivoListaPersonajes);
    //CARGAR HISTORIAL
}
else
{
    ListaPersonajes = PersonajesJson.GenerarPersonajes(); //Crea la lista de personajes desde 0 con DatosPersonajesjson que arme con datos 
    PersonajesJson.GuardarPersonajes(ListaPersonajes, "Archivo/ListaPersonajes.json");
    
    //CARGAR HISTORIAL
}

if (ListaPersonajes == null /*&& Historial == null*/)
{
    Console.WriteLine("Error: No se pudo cargar los datos");
}
else
{
    //MOSTAR MENU
}