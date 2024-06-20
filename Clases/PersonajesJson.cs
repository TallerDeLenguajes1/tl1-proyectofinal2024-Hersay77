using EspacioPersonajes;
using System.Collections.Generic;

namespace EspacioPersonajesJson
{
    public class PersonajesJson
    {
        public void GuardarPersonajes(List<Personaje> ListaPersonajes, string ArchivoListaPersonajesJson)
        {

        }

        public List<Personaje> LeerPersonajes(string ArchivoListaPersonajesJson)
        {   
            List<Personaje> ListaPersonajes = new List<Personaje>();

            return ListaPersonajes;
        }

        public bool Existe(string Archivo)
        {
            bool existe = true;

            return existe;
        }
    }


}