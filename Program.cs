using EspacioPersonajesJson; //metodos guardar y leer json con lista de personajes
using EspacioPersonajes;
using EspacioHistorialJson; //metodos guardar y leer json historial
using EspacioClaseListaEpisdios;
using System.Text.Json;
using EspacioGUI;
using EspacioLogicHelper;
using EspacioBatalla;


GUI MetodosGUI = new GUI(); //creo instancia para usar metodos DE INTERFAZ GRAFICA DE USUARIO
LogicHelper MetodosLogica = new LogicHelper(); //creo instancia para usar metodos de AYUDA PARA LOGICA PRINCIPAL

//RUTAS DE ARCHIVOS
    string ArchivoListaPersonajes = "Archivos/ListaPersonajes.json"; 
    string ArchivoHistorial = "Archivos/Historial.json";
    string Portada = "ArchivosTxt/Portada.txt";
    string ArchivoDatosPersonajes = "Archivos/DatosPersonajes.json";


//VERIFICACION DE EXISTENCIA Y CREACION DE ARCHIVOS PARA COMENZAR EL PROGRAMA
    List<Personaje> ListaPersonajes;
    List<PersonajeEnHistorial> Historial;
    bool Guardado = true; //variable para identificar el correcto guardado de archivos de personajes. Inicia en true por si ya se habia guardado anteriormente por primera vez los personajes (si ya esta creada ListaPersonajes.json en una misma sesion)

    if (PersonajesJson.Existe(ArchivoListaPersonajes)) ////Verificar al comienzo del Juego si existe el archivo de personajes
    {
        ListaPersonajes = PersonajesJson.LeerPersonajes(ArchivoListaPersonajes); //lee lista de personajes, sino retorna null
        Historial = HistorialJson.LeerGanadores(ArchivoHistorial); //se lee el historial, sino retorna null
    }
    else
    {
        ListaPersonajes = PersonajesJson.GenerarPersonajesPreestablecidos(ArchivoDatosPersonajes); //Crea la lista de personajes desde 0 con DatosPersonajes.json (archivo que contiene datos de personajes preestablecidos)
        Guardado = PersonajesJson.GuardarPersonajes(ListaPersonajes, ArchivoListaPersonajes); //el metodo guarda la lista de personajes en json y devuelve true si se completo el guardado
        Historial = HistorialJson.LeerGanadores(ArchivoHistorial); //lee el historial desde un json, si no retorna null
    }

//CONTROL E INICIO DEL JUEGO

    if (ListaPersonajes == null || Historial == null || Guardado == false) 
    {
        Console.WriteLine("Error de programa: No se pudo cargar los datos");
    }
    else //SE INCIA EL JUEGO
    {
        //MOSTRAR PORTADA DE INICIO
        Console.ForegroundColor = ConsoleColor.Green; 
        MetodosGUI.MostrarTxt(Portada, 0); 
        MetodosGUI.MostrarPresionarTecla();

        int opcionMenu; //1 -> se eligio mostrar personajes y se inicia (al finalizar debe volver al inicio). 2 -> se muestra el historial (al finalziar debe volver al incio) y con el metodo opcion menu se verifica ingreso
        int opcion;
        do
        {
            MetodosGUI.MostrarMenu(); //MENU PRINCIPAL
            opcionMenu = MetodosLogica.ElegirOpcionMenu(); //uso el metodo de elegir opcion
            switch (opcionMenu)
            {
                case 1:
                    //MOSTRAR LISTA PERSONAJES Y SELECCIONAR
                        MetodosGUI.MostrarPersonajes(ListaPersonajes);
                        opcion = MetodosLogica.ElegirOpcionPersonaje();
                    //MOSTRAR PERSONAJE ELEGIDO 
                        MetodosGUI.MostrarTxt($"ArchivosTxt/{ListaPersonajes[opcion].DatosPersonaje.Apodo}.txt", 0);//muestro personaje elegido
                    //HAGO REFERENCIA AL PERSONAJE ELEGIDO EN OTRA VARIABLE
                        Personaje personajeSeleccionado = ListaPersonajes[opcion]; 
                    //ELIMINO PERSONAJE DE LISTA (SOLO SE ELIMINA DE LA LISTA, LA REFERENCIA A EL PERSONAJE ELEGIDO EN LA MEMORIA SIGUE EN LA VARIABLE personajeSeleccionado)
                        ListaPersonajes.Remove(ListaPersonajes[opcion]); 
                    
                    //USO Y LLAMADA A LA API (OBTIENE UNA LISTA DE EPISODIOS SEGUN LA SERIE A LA CUAL PERTENECE EL PERSONAJE DEL PERSONAJE)
                        string url = MetodosLogica.ObtenerUrl(personajeSeleccionado.DatosPersonaje.SerieDelPersonaje); //metodo segun serie obtiene url para enviarla al metodo API
                        List<Episodio> episodios = await GetEpisodiosAsync(url); //llamada al metodo API obtiene lista de episodios de serie

                    //PARTIDA - ENFRENTO AL PERSONAJE CON TODOS LOS PERSONAJES DE LA LISTA
                        var resultadoBatalla = true; //variable para controlar si se gano la batalla
                        var resultadoPartida = true; //variable para controlar si se gano la Partida
                        float puntaje = 0; //acumulador puntaje
                        var numeroBatalla = 0; //contador batalla

                        foreach (var jugador2 in ListaPersonajes) //se recorre la lista generando las batallas
                        {
                            numeroBatalla += 1;              
                            puntaje = MetodosLogica.Bonificacion(puntaje, episodios); //bonificacion por batalla
                            Console.ForegroundColor = ConsoleColor.Magenta; 
                            Console.WriteLine($"\n°°°°°°°°°°°°°° INICIA LA BATALLA N°: {numeroBatalla}°°°°°°°°°°°°°°°°°°\n");
                            Thread.Sleep(700);
                            Console.ForegroundColor = ConsoleColor.Red;
                            MetodosGUI.MostrarVS(personajeSeleccionado, jugador2);
                            Console.ResetColor();

                            resultadoBatalla = Batalla.GenerarBatalla(personajeSeleccionado, jugador2); //BATALLA

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
                            
                            MetodosGUI.MostrarPartidaGanada();
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
                            MetodosGUI.MostrarGameOver();
                        }
                break;
                case 2:
                    HistorialJson.MostrarHistorial(Historial); //MOSTRAR HISTORIAL
                break;
                case 3:
                    //SALIR
                    Console.WriteLine(" # NOS VEMOS CAMPEON #");
                    Thread.Sleep(700); 
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

