using EspacioPersonajesJson;
using EspacioPersonajes;
using System.Collections.Generic;
using EspacioHistorialJson;
using EspacioMetodosPrincipales;

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

MetodosPrincipales Metodos = new MetodosPrincipales(); //CREO UNA INSTANCIA PARA USAR METODOS EN LA LOGICA PRINCIPAL

Metodos.MostrarPersonajes(ListaPersonajes); // MOSTRANDO PERSONAJES
int opcion = Metodos.ElegirPersonaje(); //SELECCION DE PERSONAJE
var personajeSeleccionado = ListaPersonajes[opcion]; //SE GUARDA EL PERSONAJE SELECCIONADO EN UNA VARIABLE
ListaPersonajes.Remove(ListaPersonajes[opcion]); //ELIMINO EL PERSONAJE DE LA LISTA

//ENFRENTO AL PERSONAJE CON TODOS LOS PERSONAJES DE LA LISTA
    var resultadoBatalla = true;
    foreach (var jugador2 in ListaPersonajes)
    {
        resultadoBatalla = Metodos.GenerarBatalla(personajeSeleccionado, jugador2);
    }





