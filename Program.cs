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
ListaPersonajes.Remove(ListaPersonajes[opcion]); //ELIMINO EL PERSONAJE SELECCIONADO DE LA LISTA PARA QUE NO SE ENFRENTE A EL MISMO

//ENFRENTO AL PERSONAJE CON TODOS LOS PERSONAJES DE LA LISTA
    var resultadoBatalla = true;
    var resultadoPartida = true;
    float puntaje = 0;
    var numeroBatalla = 0;
    foreach (var jugador2 in ListaPersonajes)
    {
        numeroBatalla += 1;
        Console.WriteLine($"################### - INICIA LA BATALLA - {numeroBatalla} - ###############################");
        resultadoBatalla = Metodos.GenerarBatalla(personajeSeleccionado, jugador2); //genero batalla
        if (resultadoBatalla)//true - si se gana la batalla
        {
            Console.WriteLine("HAS GANADO LA BATALLA!!!");
            puntaje = puntaje + personajeSeleccionado.CaracteristicasPersonaje.Salud; //El puntaje acumulado en cada batalla sera la salud con la que queda el personaje
            personajeSeleccionado.CaracteristicasPersonaje.Salud = 100;//VUELVO SALUD DEL PERSONAJE NUEVAENTE A 100 PARA ENFRENTARSE AL PROXIMO OPONENTE

        }
        else
        {
            Console.WriteLine("HAS PERDIDO LA BATALLA!!!");
            resultadoPartida = false; //si no se gano la batalla se pierde la partida 
            return;
        }
    }

    if (resultadoPartida)
    {
        Console.WriteLine("HAS GANADO LA PARTIDA!!!");
        personajeSeleccionado.CaracteristicasPersonaje.Nivel += 1; //cada vez que se gana una partida el nivel del personaje aumenta en 1 unidad
    }
    else
    {
        Console.WriteLine("GAME OVER");
    }





