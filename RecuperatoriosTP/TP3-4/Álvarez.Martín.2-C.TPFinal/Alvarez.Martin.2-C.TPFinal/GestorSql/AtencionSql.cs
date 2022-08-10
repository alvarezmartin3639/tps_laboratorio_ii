
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace GestorSql
{
    public class AtencionSql : ISqlEntidad<Atencion>
    {
        private SqlConnection sqlConnection;
        private static string conexion;
        private string conexionSql;

        /// <summary>
        /// Constructor estatico de AtencionSql, instancia el atributo conexion con la información del servidor
        /// </summary>
        static AtencionSql()
        {
            conexion = "Server = .\\sqlexpress ; Database = TP4_AlvarezMartinAndres_DB; Trusted_Connection = true ;";
        }

        /// <summary>
        /// Construye una Atencion, pasando por parametro la información para conectarse a Sql server;
        /// </summary>
        /// <param name="conexionSettings">La información necesaria para conectarse</param>
        public AtencionSql(string conexionSettings)
        {
            this.sqlConnection = new SqlConnection(conexionSettings);
            this.conexionSql = conexionSettings;
        }

        /// <summary>
        /// Busca en la tabla Atencion la atención que coincida con el id proporcionado por parametro, retoranando dicha Atencion
        /// </summary>
        /// <param name="id">El id para buscar</param>
        /// <returns>La atención que contiene dicho id</returns>
        public Atencion BuscarPorId(int id)
        {
            try
            {
                SqlCommand comandoSql = new("SELECT * FROM Atencion where idDeAtencion=@id", this.sqlConnection);
                comandoSql.Parameters.AddWithValue("idDeAtencion", id);
                return this.BuscarAtenciones(comandoSql).First();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Busca atenciones mediante la instrucción y la conexión del SqlCommand  pasado por parametro
        /// </summary>
        /// <param name="commandoSql">El SqlCommand encargado de realizar la tarea</param>
        /// <returns>Una List<Atencion> con el listado de atenciones seleccionadas</Atencion></returns>
        public List<Atencion> BuscarAtenciones(SqlCommand commandoSql)
        {
            Atencion atencionNueva = new();
            List<Atencion> lista = new();

            try
            {
                this.sqlConnection.Open();
                SqlDataReader dataReader = commandoSql.ExecuteReader();

                while (dataReader.Read())
                {
                    atencionNueva.IdDeAtencion = int.Parse(dataReader["idDeAtencion"].ToString());
                    atencionNueva.IdDeMedico = int.Parse(dataReader["idDeMedico"].ToString());
                    atencionNueva.IdDePaciente = int.Parse(dataReader["idDePaciente"].ToString());
                    atencionNueva.MotivoDeLaConsulta = dataReader["motivoDeLaConsulta"].ToString();
                    atencionNueva.Tratamiento = dataReader["tratamiento"].ToString();
                    atencionNueva.Diagnostico = dataReader["diagnostico"].ToString();
                    atencionNueva.FechaDeLaAtencion = DateTime.Parse(dataReader["fechaDeLaAtencion"].ToString());
                    lista.Add(atencionNueva);
                }

                return lista;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (this.sqlConnection != null && sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    this.sqlConnection.Close();
                }
            }
        }

        /// <summary>
        /// Busca atenciones del medico mediante el id pasado por parametro
        /// </summary>
        /// <param name="idDeMedico">El id del medico a buscar</param>
        /// <returns>Un List<Atencion> con todas las atenciones del medico </Atencion></returns>
        public List<Atencion> BuscarAtencionesDeUnMedicoMedianteSuId(int idDeMedico)
        {
            try
            {
                SqlCommand comandoSql = new("SELECT * FROM Atencion where idDeMedico=@idDeMedico", this.sqlConnection);
                comandoSql.Parameters.AddWithValue("idDeMedico", idDeMedico);
                return this.BuscarAtenciones(comandoSql);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Busca atenciones del medico mediante el id pasado por parametro
        /// </summary>
        /// <param name="idDePaciente">El id del Paciente a buscar</param>
        /// <returns>Un List<Atencion> con todas las atenciones del Paciente</Atencion></returns>
        public List<Atencion> BuscarAtencionesDeUnPacienteMedianteSuId(int idDePaciente)
        {
            try
            {
                SqlCommand comandoSql = new("SELECT * FROM Atencion where idDePaciente=@idDePaciente", this.sqlConnection);
                comandoSql.Parameters.AddWithValue("idDePaciente", idDePaciente);
                return this.BuscarAtenciones(comandoSql);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Importa todas las Atenciones que existen en la tabla Atencion de la database TP4_AlvarezMartinAndres_DB
        /// </summary>
        /// <returns>List<Atencion> con todos las atenciones de la tabla </Paciente></returns>
        public static List<Atencion> Leer()
        {
            List<Atencion> lista = new();
            try
            {

                string sentencia = "SELECT * FROM Atencion";
                using (SqlConnection sqlConnection = new(AtencionSql.conexion))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new(sentencia, sqlConnection);
                    SqlDataReader dataReader = sqlCommand.ExecuteReader();

                    while (dataReader.Read())
                    {
                        Atencion atencionNueva = new();
                        atencionNueva.IdDeAtencion = int.Parse(dataReader["idDeAtencion"].ToString());
                        atencionNueva.IdDeMedico = int.Parse(dataReader["idDeMedico"].ToString());
                        atencionNueva.IdDePaciente = int.Parse(dataReader["idDePaciente"].ToString());
                        atencionNueva.MotivoDeLaConsulta = dataReader["motivoDeLaConsulta"].ToString();
                        atencionNueva.Tratamiento = dataReader["tratamiento"].ToString();
                        atencionNueva.Diagnostico = dataReader["diagnostico"].ToString();
                        atencionNueva.FechaDeLaAtencion = DateTime.Parse(dataReader["fechaDeLaAtencion"].ToString());
                        lista.Add(atencionNueva);
                    }

                    return lista;
                }
            }
            catch (Exception)
            {

                throw;
            }


        }

        /// <summary>
        /// Exporta una Atencion a la tabla Atencion de la database TP4_AlvarezMartinAndres_DB
        /// </summary>
        /// <param name="objetoParaAgregar">La Atencion para agregar</param>
        /// <returns>Un string confirmando que se guardo una Atencion</returns>
        public bool Agregar(Atencion objetoParaAgregar)
        {
            try
            {
                bool retorno = false;
                if (MisComandosSql.VerificarSingularidad("Atencion", "fechaDeLaAtencion", objetoParaAgregar.FechaDeLaAtencion, AtencionSql.conexion))
                {
                    using (SqlConnection sqlConnection = new SqlConnection(this.conexionSql))
                    {
                        sqlConnection.Open();
                        string sentencia = "INSERT INTO Atencion ( idDeMedico, idDePaciente, motivoDeLaConsulta," +
                            " tratamiento, diagnostico, fechaDeLaAtencion) " +
                            "VALUES ( @idDeMedico, @idDePaciente, @motivoDeLaConsulta," +
                            " @tratamiento, @diagnostico, @fechaDeLaAtencion)";

                        SqlCommand sqlCommand = new(sentencia, sqlConnection);
                        sqlCommand.Parameters.AddWithValue("idDeMedico", objetoParaAgregar.IdDeMedico);
                        sqlCommand.Parameters.AddWithValue("idDePaciente", objetoParaAgregar.IdDePaciente);
                        sqlCommand.Parameters.AddWithValue("motivoDeLaConsulta", objetoParaAgregar.MotivoDeLaConsulta);
                        sqlCommand.Parameters.AddWithValue("tratamiento", objetoParaAgregar.Tratamiento);
                        sqlCommand.Parameters.AddWithValue("diagnostico", objetoParaAgregar.Diagnostico);
                        sqlCommand.Parameters.AddWithValue("fechaDeLaAtencion", objetoParaAgregar.FechaDeLaAtencion);
                        sqlCommand.ExecuteNonQuery();

                        retorno = true;
                    }
                }
                return retorno;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Elimina una Atencion de la tabla Atencion de ladatabase TP4_AlvarezMartinAndres_DB
        /// </summary>
        /// <param name="idDeAtencion">El id de la atencion a eliminar</param>
        public static void Borrar(int idDeAtencion)
        {
            try
            {
                using (SqlConnection sqlConnection = new(AtencionSql.conexion))
                {
                    string sentencia = "DELETE FROM Atencion WHERE idDeAtencion = @idDeAtencion";
                    SqlCommand comandoSql = new(sentencia, sqlConnection);
                    comandoSql.Parameters.Clear();
                    comandoSql.Parameters.AddWithValue("idDeAtencion", idDeAtencion);
                    sqlConnection.Open();
                    comandoSql.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
