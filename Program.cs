using EspacioPersonajesJson; //metodos guardar y leer json con lista de personajes
using EspacioPersonajes;
using EspacioHistorialJson; //metodos guardar y leer json historial
using EspacioClaseListaEpisdios;
using EspacioGUI;
using EspacioLogicHelper;
using EspacioBatalla;
using EspacioAPI;

//INSTANCIAS PARA USAR METODOS GUI Y AYUDA LOGICA
GUI MetodosGUI = new GUI(); 
LogicHelper MetodosLogica = new LogicHelper();


//VERIFICACION DE EXISTENCIA Y CREACION DE ARCHIVOS PARA COMENZAR EL PROGRAMA
    MetodosLogica.VerificarYCrearArchivos();
    List<Personaje> ListaPersonajes = MetodosLogica.ListaPersonajes; 
    List<PersonajeEnHistorial> Historial = MetodosLogica.Historial;
    bool Guardado = MetodosLogica.Guardado;


//CONTROL E INICIO DEL JUEGO

    if (ListaPersonajes == null || Historial == null || Guardado == false) 
    {
        Console.WriteLine("Error de programa: No se pudo cargar los datos");
    }
    else //SE INCIA EL JUEGO
    {
        //MOSTRAR PORTADA DE INICIO
        Console.ForegroundColor = ConsoleColor.Green; 
        MetodosGUI.MostrarTxt(MetodosLogica.Portada, 0); 
        MetodosGUI.MostrarPresionarTecla();

        int opcionMenu; //1 y 2 repite el bucle - se controla ingreso con metodo
        int opcion; //variable para opciones
        do
        {
            MetodosGUI.MostrarMenu(); //MENU PRINCIPAL
            opcionMenu = MetodosLogica.ElegirOpcionMenu(); //control de ingreso correcto
            switch (opcionMenu)
            {
                case 1:
                    //MOSTRAR LISTA PERSONAJES Y SELECCIONAR
                        MetodosGUI.MostrarPersonajes(ListaPersonajes);
                        opcion = MetodosLogica.ElegirOpcionPersonaje();
                    //MOSTRAR PERSONAJE ELEGIDO 
                        MetodosGUI.MostrarTxt($"ArchivosTxt/{ListaPersonajes[opcion].DatosPersonaje.Apodo}.txt", 0);
                    //HAGO REFERENCIA AL PERSONAJE ELEGIDO EN OTRA VARIABLE
                        Personaje personajeSeleccionado = ListaPersonajes[opcion]; 
               /*     //ELIMINO PERSONAJE DE LISTA (SOLO SE ELIMINA DE LA LISTA, LA REFERENCIA A EL PERSONAJE ELEGIDO EN LA MEMORIA SIGUE EN LA VARIABLE personajeSeleccionado)
                        ListaPersonajes.Remove(ListaPersonajes[opcion]); */
                    
                    //USO Y LLAMADA A LA API (OBTIENE UNA LISTA DE EPISODIOS SEGUN LA SERIE A LA CUAL PERTENECE EL PERSONAJE)
                        string url = MetodosLogica.ObtenerUrl(personajeSeleccionado.DatosPersonaje.SerieDelPersonaje); //metodo segun serie obtiene url para enviarla al metodo API
                        List<Episodio> episodios = await Api.GetEpisodiosAsync(url); //llamada al metodo API obtiene lista de episodios de serie

                    //CONSULTA SI SABE NOMBRE DE EPISODIOS
                    int SabeNombre = MetodosLogica.SabeNombre();

                    //PARTIDA - ENFRENTO AL PERSONAJE CON TODOS LOS PERSONAJES DE LA LISTA
                        var resultadoBatalla = true; //variable para controlar si se gano la batalla
                        var resultadoPartida = true; //variable para controlar si se gano la Partida
                        float puntaje = 0; //acumulador puntaje
                        var numeroBatalla = 0; //contador batalla

                        foreach (var jugador2 in ListaPersonajes) //se recorre la lista generando las batallas
                        {
                            if (jugador2 != personajeSeleccionado) //contola que no pelee con el mismo personaje
                            {
                                numeroBatalla += 1;

                                //BONIFICACION
                                puntaje = SabeNombre == 1 ? MetodosLogica.BonificacionManual(puntaje, episodios): MetodosLogica.BonificacionAuto(puntaje, episodios);
                                Thread.Sleep(1000);

                            //MUESTRA INICIO DE BATALLA
                                    Console.ForegroundColor = ConsoleColor.Magenta; 
                                    Console.WriteLine($"\n°°°°°°°°°°°°°° INICIA LA BATALLA N°: {numeroBatalla}°°°°°°°°°°°°°°°°°°\n");
                                    Thread.Sleep(700);
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    MetodosGUI.MostrarVS(personajeSeleccionado, jugador2);
                                    Console.ResetColor();

                                //BATALLA
                                    resultadoBatalla = Batalla.GenerarBatalla(personajeSeleccionado, jugador2); 

                                //COMRUEBA RESULTADO DE BATLLA
                                    if (resultadoBatalla)//true - si se gana la batalla
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("=============>>>> HAS GANADO LA BATALLA!!! <<<<============= ");
                                        Console.ResetColor();
                                        puntaje = puntaje + personajeSeleccionado.CaracteristicasPersonaje.Salud; //El puntaje acumulado en cada batalla sera la salud con la que queda el personaje
                                        personajeSeleccionado.CaracteristicasPersonaje.Salud = 100;//VUELVO SALUD DEL PERSONAJE NUEVAENTE A 100 PARA ENFRENTARSE AL PROXIMO OPONENTE
                                        jugador2.CaracteristicasPersonaje.Salud = 100; //tambien restauro salud del oponente para una proxima partida

                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("=====================>>>HAS PERDIDO LA BATALLA!!! <<<<============= ");
                                        Console.ResetColor();
                                        ListaPersonajes= PersonajesJson.LeerPersonajes(MetodosLogica.ArchivoListaPersonajes); //restauro la lista y las propiedades de los personajes
                                        resultadoPartida = false; //si no se gano la batalla se pierde la partida 
                                        break;//se sale del bucle foreach
                                    }
                            }
                        }

                        //COMPRUEBA RESULTADO DE PARTIDA
                            if (resultadoPartida)
                            {
                                
                                MetodosGUI.MostrarPartidaGanada();
                                Console.WriteLine("================================================================");
                                Console.WriteLine($"NIVEL PERSONAJE: {personajeSeleccionado.CaracteristicasPersonaje.Nivel}");
                                MetodosLogica.ListaPersonajes[opcion].CaracteristicasPersonaje.Nivel +=1;
                         /*       personajeSeleccionado.CaracteristicasPersonaje.Nivel += 1; //cada vez que se gana una partida el nivel del personaje aumenta en 1 unidad*/
                                Console.WriteLine("TU PERSONAJE AUMENTA +1 EN NIVEL !!!");
                                Console.WriteLine($"NIVEL ACTUAL: {MetodosLogica.ListaPersonajes[opcion].CaracteristicasPersonaje.Nivel}");

                        /*        MetodosLogica.ListaPersonajes = PersonajesJson.LeerPersonajes(MetodosLogica.ArchivoListaPersonajes); //restauro la lista y las propiedades de los personajes

                                MetodosLogica.ListaPersonajes[opcion].CaracteristicasPersonaje.Nivel = personajeSeleccionado.CaracteristicasPersonaje.Nivel; //actualizo el nivel del personaje en la lista
                        */    
                                Guardado = PersonajesJson.GuardarPersonajes(ListaPersonajes, MetodosLogica.ArchivoListaPersonajes); //guardo la lista modificada
                                Console.WriteLine(Guardado == true ?  "PERSONAJE ACTUALIZADO !!!": "ERROR EN EL GUARDADO DE LISTA MODIFICADA");
                                Console.WriteLine($"===>>PUNTAJE: {puntaje}"); 

                                //PEDIR DATOS SI ENTRA EN EL RANKING DE GANADORES
                                    if (Historial[9].Puntaje <= puntaje)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("================================================================");
                                        Console.WriteLine("INGRESE SU NOMBRE PARA GUARDAR EN EL HISTORIAL DE GANADORES: ");
                                        var nombreJugador = Console.ReadLine();
                                        if(HistorialJson.GuardarGanador(personajeSeleccionado, nombreJugador, MetodosLogica.ArchivoHistorial, Historial, puntaje))
                                        {
                                            Historial = HistorialJson.LeerGanadores(MetodosLogica.ArchivoHistorial);

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
