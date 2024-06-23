namespace EspacioGestorArchivos
{
    
public class GestorDeArchivos
{

        public string AbrirArchivoTexto(string nombreArchivo) 
        {
            string documento;
            using (var archivoOpen = new FileStream(nombreArchivo, FileMode.Open))//using se hace para asegurar que los recursos sean liberados adecuadamente al finalizar la lectura del archivo. Se abre el archivo especificado (nombreArchivo) en modo lectura (FileMode.Open) utilizando un FileStream llamado archivoOpen.
            {
                using (var strReader = new StreamReader(archivoOpen)) // se crea un StreamReader llamado strReader que lee desde archivoOpen. ReadToEnd() lee todo el contenido del archivo y lo guarda en la variable documento. Una vez que se completa la lectura, se cierra explícitamente archivoOpen.El FileStream (archivoOpen) se utiliza inicialmente para abrir el archivo en modo lectura. Sin embargo, el StreamReader (strReader) proporciona métodos convenientes para leer texto desde el flujo de bytes del FileStream
                {
                    documento = strReader.ReadToEnd();
                    archivoOpen.Close();
                }
            }
            return documento;
        }

        public void GuardarArchivoTexto(string nombreArchivo, string datos)
        {
            using (var archivo = new FileStream(nombreArchivo, FileMode.Create))
            {
                using (var strWriter = new StreamWriter(archivo))
                {
                    strWriter.WriteLine("{0}", datos);
                    strWriter.Close();
                }
            }
        }

        public bool Existe(string Archivo)
        {
            if (File.Exists(Archivo)) //se usa la clase File con el metodo exists para comprobar si existe el rchivo en la ruta proporcionada
            {
                return true;
            }
            else
            {
                return false;
            }
        }
}
}
