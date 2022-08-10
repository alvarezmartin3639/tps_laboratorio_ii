using System;
using System.Data.SqlClient;

namespace GestorSql
{
    public class MisComandosSql
    {
        private string conexion;

        public string Conexion { get => conexion; set => conexion = value; }

        #region CONSTRUCTOR

        /// <summary>
        /// Constructor encargado de instanciar el string conexion y el sqlConnection
        /// </summary>
        /// <param name="conexionSettings">La configuración para conectarse al servidor sql</param>
        public MisComandosSql(string conexionSettings)
        {
            this.Conexion = conexionSettings;
        }

        #endregion

        /// <summary>
        /// Verifica  el estado de la conexión con el servidor Sql pasado por parametro, si se pudo conectar retorna true
        /// </summary>
        /// <param name="conexionSettings">La configuración para conectarse al servidor sql</param>
        /// <returns>true si se pudo entablar conexión, false si no</returns>
        public static bool VerificarConexionConSql(string conexionSettings)
        {
            try
            {
                using (SqlConnection conn = new(conexionSettings))
                {
                    conn.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Verifica que una tabla no repita una entidad, mediante su atributo único (dni,una fecha, un id...etc)
        /// </summary>
        /// <param name="nombreDeLaTabla">El nombre de la tabla donde va a buscar dicho id unico</param>
        /// <param name="nombreSingularidadEnTabla">Nombre del atributo unico</param>
        /// <param name="singularidad">Valor int que tiene dicho atributo unico de la tabla</param>
        /// <param name="conexionSetting">El string para instanciar la conexión con el SqlConnection</param>
        /// <returns>true si no existe dicho valor en la tabla, false si existe</returns>
        public static bool VerificarSingularidad(string nombreDeLaTabla, string nombreSingularidadEnTabla, int singularidad, string conexionSettings)
        {
            try
            {

                string sentencia = $"SELECT * FROM {nombreDeLaTabla} where {nombreSingularidadEnTabla}=@numeroUnico";


                using (SqlConnection sqlConnection = new(conexionSettings))
                {

                    SqlCommand comandoSql = new(sentencia, sqlConnection);
                    comandoSql.Parameters.AddWithValue("@numeroUnico", singularidad);

                    sqlConnection.Open();
                    if (comandoSql.ExecuteScalar() is null)
                        return true;
                }
                return false;

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Verifica que una tabla no repita una entidad, mediante su atributo único (dni,una fecha, un id...etc)
        /// </summary>
        /// <param name="nombreDeLaTabla">El nombre de la tabla donde va a buscar dicho id unico</param>
        /// <param name="nombreSingularidadEnTabla">Nombre del atributo unico</param>
        /// <param name="singularidad">Valor DateTime que tiene dicho atributo unico de la tabla</param>
        /// <param name="conexionSetting">El string para instanciar la conexión con el SqlConnection</param>
        /// <returns>true si no existe dicho valor en la tabla, false si existe</returns>
        public static bool VerificarSingularidad(string nombreDeLaTabla, string nombreSingularidadEnTabla, DateTime singularidad, string conexionSetting)
        {
            try
            {
                string sentencia = $"SELECT * FROM {nombreDeLaTabla} where {nombreSingularidadEnTabla}=@numeroUnico";
                using (SqlConnection sqlConnection = new(conexionSetting))
                {
                    SqlCommand comandoSql = new(sentencia, sqlConnection);
                    comandoSql.Parameters.AddWithValue("@numeroUnico", singularidad);

                    sqlConnection.Open();
                    if (comandoSql.ExecuteScalar() is null)
                        return true;
                }
                return false;

            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}



