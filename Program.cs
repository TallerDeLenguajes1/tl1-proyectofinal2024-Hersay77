using EspacioPersonajesJson;
using EspacioPersonajes;
using System.Collections.Generic;

string ArchivoListaPersonajes = "Archivos/ListaPersonajes.Json";

if (PersonajesJson.Existe(ArchivoListaPersonajes))
{
    List<Personaje> ListaPersonajes = PersonajesJson.LeerPersonajes(ArchivoListaPersonajes);
}
else
{
    PersonajesJson.GenerarPersonajes();//
}