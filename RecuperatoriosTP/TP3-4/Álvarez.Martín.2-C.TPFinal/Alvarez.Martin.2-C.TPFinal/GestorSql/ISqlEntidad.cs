namespace GestorSql
{
    public interface ISqlEntidad<T> where T : class
    {

        /// <summary>
        /// Busca por id en una base de datos y retorna el objeto(T)
        /// </summary>
        /// <returns></returns>
        int BuscarPorId(int id)
        {
            if (this is null)
            {
                return id;
            }
            return id;
        }

        /// <summary>
        /// Agrega un objeto(T) a la base de datos
        /// </summary>
        /// <param name="objetoParaAgregar"></param>
        /// <returns></returns>
        public string Agregar(T objetoParaAgregar);

    }
}
