namespace GestorSql
{
    public interface ISqlEntidad<T> where T : class
    {
        /// <summary>
        /// Busca por id en una base de datos y retorna el objeto(T)
        /// </summary>
        /// <returns></returns>
        T BuscarPorId(int id);

        /// <summary>
        /// Agrega un objeto(T) a la base de datos
        /// </summary>
        /// <param name="objetoParaAgregar"></param>
        /// <returns></returns>
        string Agregar(T objetoParaAgregar);

    }
}
