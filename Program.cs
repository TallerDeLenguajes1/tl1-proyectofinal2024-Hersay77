using EspacioPersonajesJson;
using EspacioPersonajes;
using System.Collections.Generic;

string ArchivoListaPersonajes = "Archivos/ListaPersonajes.Json";

if (PersonajesJson.Existe(ArchivoListaPersonajes))
{
    List<Personaje> ListaPersonajes = PersonajesJson.LeerPersonajes(ArchivoListaPersonajes);
    //CARGAR HISTORIAL
}
else
{
    List<Personaje> ListaPersonajes = PersonajesJson.GenerarPersonajes();
    //CARGAR HISTORIAL
}

