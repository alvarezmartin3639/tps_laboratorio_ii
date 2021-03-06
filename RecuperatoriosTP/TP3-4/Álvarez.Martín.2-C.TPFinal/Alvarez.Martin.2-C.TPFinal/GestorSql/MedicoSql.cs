
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GestorSql
{
    public class MedicoSql : ISqlEntidad<Medico>
    {
        private SqlConnection sqlConnection;
        private static string conexion;

        /// <summary>
        /// Construye un Medico, pasando por parametro la información para conectarse a Sql server;
        /// </summary>
        /// <param name="conexionSettings">La información necesaria para conectarse</param>
        public MedicoSql(string conexionSettings)
        {
            MedicoSql.conexion = conexionSettings;
        }

        /// <summary>
        /// Busca en la tabla Medico el medico que coincida con el id proporcionado por parametro, retoranando dicho Medico
        /// </summary>
        /// <param name="id">El id para buscar</param>
        /// <returns>El Medico que contiene dicho id</returns>
        public Medico BuscarPorId(int idDeMedico)
        {
            Medico medicoNuevo = new Medico();
            try
            {
                string sentencia = "SELECT * FROM Medico where idDeMedico=@idDeMedico";
                SqlCommand comandoSql = new SqlCommand(sentencia, this.sqlConnection);
                comandoSql.Parameters.AddWithValue("idDeMedico", idDeMedico);
                this.sqlConnection.Open();
                SqlDataReader dataReader = comandoSql.ExecuteReader();
                AtencionSql tablaAtencion = new("Server = (local)\\sqlexpress ; Database = TP4_AlvarezMartinAndres_DB; Trusted_Connection = true ;");

                while (dataReader.Read())
                {
                    medicoNuevo.IdDeMedico = int.Parse(dataReader["idDeMedico"].ToString());
                    medicoNuevo.Nombre = dataReader["nombre"].ToString();
                    medicoNuevo.Edad = int.Parse(dataReader["edad"].ToString());
                    medicoNuevo.Dni = int.Parse(dataReader["dni"].ToString());
                    medicoNuevo.Sexo = (sexoEnum)int.Parse(dataReader["sexo"].ToString());
                    medicoNuevo.Matricula = int.Parse(dataReader["matricula"].ToString());
                    medicoNuevo.PacientesAtendidos = tablaAtencion.buscarAtencionesDeUnPacienteMedianteSuId(medicoNuevo.IdDeMedico);

                }
                return medicoNuevo;
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
        /// Importa todos los Medicos que existen en la tabla Medico de la database TP4_AlvarezMartinAndres_DB
        /// </summary>
        /// <returns>List<Medico> con todos los Medicos de la tabla </Paciente></returns>
        public List<Medico> Leer()
        {
            List<Medico> lista = new List<Medico>();
            try
            {
                string sentencia = "SELECT * FROM Medico";
                using (SqlConnection conexion = new SqlConnection(MedicoSql.conexion))
                {
                    conexion.Open();
                    SqlCommand sqlCommand = new SqlCommand(sentencia, conexion);
                    SqlDataReader dataReader = sqlCommand.ExecuteReader();
                    AtencionSql tablaAtencion = new("Server = (local)\\sqlexpress ; Database = TP4_AlvarezMartinAndres_DB; Trusted_Connection = true ;");

                    while (dataReader.Read())
                    {
                        Medico medicoNuevo = new Medico();
                        medicoNuevo.IdDeMedico = int.Parse(dataReader["idDeMedico"].ToString());
                        medicoNuevo.Nombre = dataReader["nombre"].ToString();
                        medicoNuevo.Edad = int.Parse(dataReader["edad"].ToString());
                        medicoNuevo.Dni = int.Parse(dataReader["dni"].ToString());
                        medicoNuevo.Sexo = (sexoEnum)Enum.Parse(typeof(sexoEnum), dataReader["sexo"].ToString());
                        medicoNuevo.Matricula = int.Parse(dataReader["matricula"].ToString());
                        medicoNuevo.PacientesAtendidos = tablaAtencion.buscarAtencionesDeUnPacienteMedianteSuId(medicoNuevo.IdDeMedico);

                        lista.Add(medicoNuevo);
                    }
                }

                return lista;
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
        public string Agregar(Medico objetoParaAgregar)
        {
            string retunrAux = string.Empty;

            try
            {
                if (MisComandosSql.VerificarSingularidad("Medico", "idDeMedico", objetoParaAgregar.IdDeMedico, MedicoSql.conexion))
                {
                    using (SqlConnection sqlConnection = new SqlConnection(MedicoSql.conexion))
                    {
                        sqlConnection.Open();
                        string sentencia = "INSERT INTO Medico ( nombre, edad, dni," +
                            " sexo, matricula) " +
                            "VALUES ( @nombre, @edad, @dni," +
                            " @sexo, @matricula)";

                        SqlCommand sqlCommand = new SqlCommand(sentencia, sqlConnection);
                        sqlCommand.Parameters.AddWithValue("nombre", objetoParaAgregar.Nombre);
                        sqlCommand.Parameters.AddWithValue("edad", objetoParaAgregar.Edad);
                        sqlCommand.Parameters.AddWithValue("dni", objetoParaAgregar.Dni);
                        sqlCommand.Parameters.AddWithValue("sexo", objetoParaAgregar.Sexo.ToString());
                        sqlCommand.Parameters.AddWithValue("matricula", objetoParaAgregar.Matricula);

                        sqlCommand.ExecuteNonQuery();
                        return retunrAux;
                    }
                }

                return retunrAux;

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Elimina un Medico de la tabla Medico de la database TP4_AlvarezMartinAndres_DB
        /// </summary>
        /// <param name="idDeMedico">El id del Medico a eliminar</param>
        public void Borrar(int idDeMedico)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(MedicoSql.conexion))
                {
                    string sentencia = "DELETE FROM Medico WHERE idDeMedico = @idDeMedico";
                    SqlCommand comandoSql = new SqlCommand(sentencia, sqlConnection);
                    comandoSql.Parameters.Clear();
                    comandoSql.Parameters.AddWithValue("idDeMedico", idDeMedico);
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
