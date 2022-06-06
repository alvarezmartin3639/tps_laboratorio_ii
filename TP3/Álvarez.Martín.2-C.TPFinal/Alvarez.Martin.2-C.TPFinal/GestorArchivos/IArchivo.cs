namespace GestorArchivos
{
    public interface IArchivos<T> where T : class
    {
        /// <summary>
        /// Interfaz utilizada para leer archivos
        /// </summary>
        /// <param name="path">La ruta donde el usuario elige donde guardar el archivo</param>
        /// <returns></returns>
        T Leer(string path);

        /// <summary>
        /// Interfaz utilizada para escribir archivos
        /// </summary>
        /// <param name="dato">El texto que se va a escribir en el archivo</param>
        /// <param name="path">La ruta donde el usuario elige donde guardar el archivo</param>
        void Escribir(T dato, string path);
    }

}
