﻿using EspacioPersonajesJson; //metodos guardar y leer json con lista de personajes
using EspacioPersonajes;
using EspacioHistorialJson; //metodos guardar y leer json historial
using EspacioMetodosPrincipales;
using EspacioClaseListaEpisdios;
using System.Text.Json;

string ArchivoListaPersonajes = "Archivos/ListaPersonajes.json"; 
string ArchivoHistorial = "Archivos/Historial.json";
string Portada = "ArchivosTxt/Portada.txt";

List<Personaje> ListaPersonajes;
List<PersonajeEnHistorial> Historial;
bool Guardado = true; //guardado inicia en true por si ya se habia guardado anteriormente por primera vez los personajes


//VERIFICACION DE EXISTENCIA Y CREACION DE ARCHIVOS PARA COMENZAR EL PROGRAMA
if (PersonajesJson.Existe(ArchivoListaPersonajes)) ////Verificar al comienzo del Juego si existe el archivo de personajes
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

//CONTROL LECTURA O CONSTRUCCION CORRECTA PARA INICIAR JUEGO
if (ListaPersonajes == null || Historial == null || Guardado == false)
{
    Console.WriteLine("Error de programa: No se pudo cargar los datos");
}
else
{
    MetodosPrincipales Metodos = new MetodosPrincipales(); //creo instancia para usar metodos principales
    Console.ForegroundColor = ConsoleColor.Green; 
    Metodos.MostrarTxt(Portada, 0);
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("###################=========>   PRESIONE UNA TECLA PARA INICIAR <===========######################");
    Console.ResetColor();
    Console.ReadKey();

    int opcionMenu;
    int opcion;
    do
    {
        Metodos.MostrarMenu(); //MENU PRINCIPAL
        opcionMenu = Metodos.ElegirOpcionMenu(); //uso el metodo de elegir opcion en la misma clase
        switch (opcionMenu)
        {
            case 1:
                //MOSTRAR LISTA PERSONAJES Y SELECCIONAR
                Metodos.MostrarPersonajes(ListaPersonajes);
                opcion = Metodos.ElegirOpcionPersonaje(); //seleccion de personaje
                Metodos.MostrarTxt($"ArchivosTxt/{ListaPersonajes[opcion].DatosPersonaje.Apodo}.txt", 0);//muestro personaje elegido
                Personaje personajeSeleccionado = ListaPersonajes[opcion]; //HAGO REFERENCIA AL PERSONAJE EN OTRA VARIABLE

                ListaPersonajes.Remove(ListaPersonajes[opcion]); //ELIMINO PERSONAJE DE LISTA
                
                //PARTIDA - ENFRENTO AL PERSONAJE CON TODOS LOS PERSONAJES DE LA LISTA
                var resultadoBatalla = true; //variable para controlar si se gano
                var resultadoPartida = true; //variable para controlar si se gan
                float puntaje = 0;
                var numeroBatalla = 0;
                string url = Metodos.ObtenerUrl(personajeSeleccionado.DatosPersonaje.SerieDelPersonaje); //metodo segun serie obtiene url para enviarla al metodo API
                List<Episodio> episodios = await GetEpisodiosAsync(url); //llamada al metodo API obtiene lista de episodios de serie

                foreach (var jugador2 in ListaPersonajes) //se recorre la lista generando las batallas
                {
                    numeroBatalla += 1;              
                    puntaje = Metodos.Bonificacion(puntaje, episodios); //bonificacion por batalla
                    Console.ForegroundColor = ConsoleColor.Magenta; 

                    Console.WriteLine($"\n°°°°°°°°°°°°°° INICIA LA BATALLA N°: {numeroBatalla}°°°°°°°°°°°°°°°°°°\n");
                    Thread.Sleep(700);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Metodos.MostrarVS(personajeSeleccionado, jugador2);
                    Console.ResetColor();

                    resultadoBatalla = Metodos.GenerarBatalla(personajeSeleccionado, jugador2); //BATALLA

                    if (resultadoBatalla)//true - si se gana la batalla
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("=============>>>> HAS GANADO LA BATALLA!!! <<<<============= ");
                        Console.ResetColor();
                        puntaje = puntaje + personajeSeleccionado.CaracteristicasPersonaje.Salud; //El puntaje acumulado en cada batalla sera la salud con la que queda el personaje
                        personajeSeleccionado.CaracteristicasPersonaje.Salud = 100;//VUELVO SALUD DEL PERSONAJE NUEVAENTE A 100 PARA ENFRENTARSE AL PROXIMO OPONENTE

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("=====================>>>HAS PERDIDO LA BATALLA!!! <<<<============= ");
                        Console.ResetColor();
                        ListaPersonajes= PersonajesJson.LeerPersonajes(ArchivoListaPersonajes); //restauro la lista y las propiedades de los personajes
                        resultadoPartida = false; //si no se gano la batalla se pierde la partida 
                        break;//se sale del bucle foreach
                    }
                }

                if (resultadoPartida)
                {
                    
                    Metodos.MostrarPartidaGanada();
                    Console.WriteLine("================================================================");
                    Console.WriteLine($"NIVEL PERSONAJE: {personajeSeleccionado.CaracteristicasPersonaje.Nivel}");
                    personajeSeleccionado.CaracteristicasPersonaje.Nivel += 1; //cada vez que se gana una partida el nivel del personaje aumenta en 1 unidad
                    
                    Console.WriteLine("TU PERSONAJE AUMENTA +1 EN NIVEL !!!");
                    Console.WriteLine($"NIVEL ACTUAL: {personajeSeleccionado.CaracteristicasPersonaje.Nivel}");
                    ListaPersonajes= PersonajesJson.LeerPersonajes(ArchivoListaPersonajes); //restauro la lista y las propiedades de los personajes
                    ListaPersonajes.Remove(ListaPersonajes[opcion]);//remuevo el personaje que se habia seleccionado
                    ListaPersonajes.Add(personajeSeleccionado); //agrego el personaje con nivel modificado a la lista NO MODIFCADA

                    Guardado = PersonajesJson.GuardarPersonajes(ListaPersonajes, ArchivoListaPersonajes); //guardo la lista modificada
                    Console.WriteLine(Guardado == true ?  "PERSONAJE ACTUALIZADO !!!": "ERROR EN EL GUARDADO DE LISTA MODIFICADA");
                    Console.WriteLine($"===>>PUNTAJE: {puntaje}"); 
                    //PEDIR DATOS SI ENTRA EN EL RANKING DE GANADORES
                    if (Historial[9].Puntaje <= puntaje)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("================================================================");
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
                    Metodos.MostrarGameOver();
                }
            break;
            case 2:
                HistorialJson.MostrarHistorial(Historial); //MOSTRAR HISTORIAL
            break;
            case 3:
                //SALIR
                Console.WriteLine("NOS VEMOS CAMPEON");
            break;                
            default:
                opcionMenu = 1;
            break;
        }
    } while (opcionMenu == 1 || opcionMenu == 2);
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

//modular mejor - crear archivos que tengan que ver con los metodos
//corregir ingreso de mas personajes  - personaje 12  - YA
//corregi ingreso menu - YA
//corregir fabrica de personajes
//mejorar uso de API

