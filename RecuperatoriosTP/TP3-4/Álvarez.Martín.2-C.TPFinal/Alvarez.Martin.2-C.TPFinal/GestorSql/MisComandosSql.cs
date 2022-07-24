using System;
using System.Data.SqlClient;

namespace GestorSql
{
    public class MisComandosSql
    {
        private SqlConnection sqlConnection;
        private SqlCommand comandoSql = new SqlCommand();
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
            this.sqlConnection = new SqlConnection(this.Conexion);
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
                using (SqlConnection conn = new SqlConnection(conexionSettings))
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
        /// Verifica mediante un id que la entidad sea unica en la tabla seleccionada
        /// </summary>
        /// <param name="nombreDeLaTabla">Nombre de la tabla que contiene la entidad en SQL</param>
        /// <param name="nombreIdEnTabla">Nombre de la columna que contiene la id unica</param>
        /// <param name="id">El valor que se busca en el nombreIdEnTabla</param>
        /// <returns>True = La id es única. False = La id no es única</returns>
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
    }

}

