using EspacioPersonajesJson;
using EspacioPersonajes;
using System.Collections.Generic;
using EspacioHistorialJson;
using EspacioMetodosPrincipales;
using EspacioClaseListaEpisdios;
using System.Text.Json;

string ArchivoListaPersonajes = "Archivos/ListaPersonajes.json";
string ArchivoHistorial = "Archivos/Historial.json";

List<Personaje> ListaPersonajes;
List<PersonajeEnHistorial> Historial;
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
    Historial = HistorialJson.LeerGanadores(ArchivoHistorial); //el metodo lee el historial desde un json, si no retorna null
}


if (ListaPersonajes == null || Historial == null || Guardado == false)
{
    Console.WriteLine("Error de programa: No se pudo cargar los datos");
}
else
{
    MetodosPrincipales Metodos = new MetodosPrincipales(); //CREO UNA INSTANCIA PARA USAR METODOS EN LA LOGICA PRINCIPAL

    Metodos.MostrarPersonajes(ListaPersonajes); // MOSTRANDO PERSONAJES
    int opcion = Metodos.ElegirPersonaje(); //SELECCION DE PERSONAJE
    var personajeSeleccionado = ListaPersonajes[opcion]; //SE "GUARDA" EL PERSONAJE SELECCIONADO EN UNA VARIABLE
    ListaPersonajes.Remove(ListaPersonajes[opcion]); //ELIMINO EL PERSONAJE SELECCIONADO DE LA LISTA PARA QUE NO SE ENFRENTE A EL MISMO
    List<Personaje> CopiaListaPersonajes = ListaPersonajes.ToList(); //CREO LISTA DE PERSONAJES PARA LUEGO AGREGAR ALLI EL PERSONAJE MODIFICADO SI GANA LA PARTIDA Y GUARDAR ESTA LISTA EN EL JSON

    //ENFRENTO AL PERSONAJE CON TODOS LOS PERSONAJES DE LA LISTA
        var resultadoBatalla = true;
        var resultadoPartida = true;
        float puntaje = 0;
        var numeroBatalla = 0;
        string url = Metodos.ObtenerUrl(personajeSeleccionado.DatosPersonaje.SerieDelPersonaje);
        List<Episodio> episodios = await GetEpisodiosAsync(url);

        foreach (var jugador2 in ListaPersonajes)
        {
            numeroBatalla += 1;

            Console.WriteLine($"<===BONIFICACION POR BATALLA====>");
            double rating = Metodos.ObtenerRating(episodios);
            puntaje = puntaje + (float)(2*rating);
            Console.WriteLine($"TU PUNTAJE AUMENTA UN 2X{rating} ===> PUNTAJE ACTUAL: {puntaje}");
            
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
                break;
            }
        }

        if (resultadoPartida)
        {
            Console.WriteLine("HAS GANADO LA PARTIDA!!!");
            Console.WriteLine($"NIVEL PERSONAJE: {personajeSeleccionado.CaracteristicasPersonaje.Nivel}");
            personajeSeleccionado.CaracteristicasPersonaje.Nivel += 1; //cada vez que se gana una partida el nivel del personaje aumenta en 1 unidad
            
            Console.WriteLine("TU PERSONAJE AUMENTA +1 EN NIVEL !!!");
            Console.WriteLine($"NIVEL ACTUAL: {personajeSeleccionado.CaracteristicasPersonaje.Nivel}");
            
            CopiaListaPersonajes.Add(personajeSeleccionado); //agrego el personaje con nivel modificado a la lista

            Guardado = PersonajesJson.GuardarPersonajes(CopiaListaPersonajes, ArchivoListaPersonajes); //guardo la lista modificada
            Console.WriteLine(Guardado == true ?  "PERSONAJE ACTUALIZADO !!!": "ERROR EN EL GUARDADO DE LISTA MODIFICADA");

            //PEDIR DATOS SI ENTRA EN EL RANKING DE GANADORES
            if (Historial[9].Puntaje <= puntaje)
            {
                Console.WriteLine("INGRESE SU NOMBRE PARA GUARDAR EN EL HISTORIAL DE GANADORES: ");
                var nombreJugador = Console.ReadLine();
                if(HistorialJson.GuardarGanador(personajeSeleccionado, nombreJugador, ArchivoHistorial, Historial, puntaje))
                {
                    Historial = HistorialJson.LeerGanadores(ArchivoHistorial);

                    HistorialJson.MostrarHistorial(Historial); //MOSTRAR HISTORIAL
                }
                else
                {
                    Console.WriteLine("Error al guardar");
                }
            }
            else
            {
                Console.WriteLine("PUNTAJE NO ALCANZADO PARA ENTRAR EN EL RANKING");
            }
        }
        else
        {
            Console.WriteLine("GAME OVER");
        }
}


//USO DE API
static async Task<List<Episodio>> GetEpisodiosAsync(string url) 
{
    try //para manejo de posibles excepciones
    {

        HttpClient client = new HttpClient(); 
        HttpResponseMessage response = await client.GetAsync(url); 
        response.EnsureSuccessStatusCode(); 
        string responseBody = await response.Content.ReadAsStringAsync(); 
        List<Episodio> ListaEpisodios = JsonSerializer.Deserialize<List<Episodio>>(responseBody);
        return ListaEpisodios;
    }
    catch (HttpRequestException e)
    {
        Console.WriteLine("Problemas de acceso a la API");
        Console.WriteLine("Message :{0} ", e.Message);
        return null;
    }
}