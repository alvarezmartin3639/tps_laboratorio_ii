
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GestorSql
{
    public class TurnoMedicoSql : ISqlEntidad<TurnoMedico>
    {
        private SqlConnection sqlConnection;
        private static string conexion;

        /// <summary>
        /// Construye un Turno Medico, pasando por parametro la información para conectarse a Sql server;
        /// </summary>
        /// <param name="conexionSettings">La información necesaria para conectarse</param>
        public TurnoMedicoSql(string conexionSettings)
        {
            sqlConnection = new();
            TurnoMedicoSql.conexion = conexionSettings;
        }

        /// <summary>
        /// Busca en la tabla TurnoMedico el medico que coincida con el id proporcionado por parametro, retoranando dicho TurnoMedico
        /// </summary>
        /// <param name="id">El id para buscar</param>
        /// <returns>El Medico que contiene dicho id</returns>
        public TurnoMedico BuscarPorId(int idDeTurnoMedico)
        {
            TurnoMedico turnoMedicoNuevo = new();
            try
            {
                string sentencia = "SELECT * FROM TurnoMedico where idDeTurnoMedico=@idDeTurnoMedico";
                SqlCommand comandoSql = new(sentencia, this.sqlConnection);
                comandoSql.Parameters.AddWithValue("idDeTurnoMedico", idDeTurnoMedico);
                this.sqlConnection.Open();
                SqlDataReader dataReader = comandoSql.ExecuteReader();
                AtencionSql tablaAtencion = new("Server = (local)\\sqlexpress ; Database = TP4_AlvarezMartinAndres_DB; Trusted_Connection = true ;");

                while (dataReader.Read())
                {
                    turnoMedicoNuevo.IdDeMedico = int.Parse(dataReader["idDeMedico"].ToString());
                    turnoMedicoNuevo.IdDePaciente = int.Parse(dataReader["idDePaciente"].ToString());
                    turnoMedicoNuevo.IdDeTurnoMedico = int.Parse(dataReader["idDeTurnoMedico"].ToString());
                    turnoMedicoNuevo.FechaTurno = DateTime.Parse((dataReader["fechaTurno"].ToString()));
                    turnoMedicoNuevo.SeRealizoAtencionDelTurno = bool.Parse((dataReader["seRealizoAtencionDelTurno"].ToString()));

                }
                return turnoMedicoNuevo;
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
        /// Importa todos los TurnoMedico que existen en la tabla Medico de la database TP4_AlvarezMartinAndres_DB
        /// </summary>
        /// <returns>List<turnoMedico> con todos los turnoMedico de la tabla </Paciente></returns>
        public static List<TurnoMedico> Leer()
        {
            List<TurnoMedico> lista = new();
            try
            {
                string sentencia = "SELECT * FROM TurnoMedico";
                using (SqlConnection conexion = new(TurnoMedicoSql.conexion))
                {
                    conexion.Open();
                    SqlCommand sqlCommand = new(sentencia, conexion);
                    SqlDataReader dataReader = sqlCommand.ExecuteReader();
                    AtencionSql tablaAtencion = new("Server = (local)\\sqlexpress ; Database = TP4_AlvarezMartinAndres_DB; Trusted_Connection = true ;");

                    while (dataReader.Read())
                    {
                        TurnoMedico turnoMedicoNuevo = new();
                        turnoMedicoNuevo.IdDeMedico = int.Parse(dataReader["idDeMedico"].ToString());
                        turnoMedicoNuevo.IdDePaciente = int.Parse(dataReader["idDePaciente"].ToString());
                        turnoMedicoNuevo.IdDeTurnoMedico = int.Parse(dataReader["idDeTurnoMedico"].ToString());
                        turnoMedicoNuevo.FechaTurno = DateTime.Parse((dataReader["fechaTurno"].ToString()));
                        turnoMedicoNuevo.SeRealizoAtencionDelTurno = bool.Parse((dataReader["seRealizoAtencionDelTurno"].ToString()));

                        lista.Add(turnoMedicoNuevo);
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
        public bool Agregar(TurnoMedico objetoParaAgregar)
        {

            try
            {
                bool retorno = false;
                using (SqlConnection sqlConnection = new(TurnoMedicoSql.conexion))
                {
                    sqlConnection.Open();
                    string sentencia = "INSERT INTO TurnoMedico ( fechaTurno, idDeMedico," +
                        " idDePaciente, seRealizoAtencionDelTurno) " +
                        "VALUES ( @fechaTurno, @idDeMedico," +
                        " @idDePaciente, @seRealizoAtencionDelTurno)";

                    SqlCommand sqlCommand = new(sentencia, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("fechaTurno", objetoParaAgregar.FechaTurno);
                    sqlCommand.Parameters.AddWithValue("idDeMedico", objetoParaAgregar.IdDeMedico);
                    sqlCommand.Parameters.AddWithValue("idDePaciente", objetoParaAgregar.IdDePaciente);
                    sqlCommand.Parameters.AddWithValue("seRealizoAtencionDelTurno", objetoParaAgregar.SeRealizoAtencionDelTurno.ToString());

                    sqlCommand.ExecuteNonQuery();
                    retorno = true;
                }
                return retorno;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Modifica el atributo seRealizoAtencion de la tabla SQL TurnoMedico, con el valor dado en la lista
        /// </summary>
        /// <param name="lista">Lista de TurnoMedico, la cual se va a recorrer y sobrescribir el valor de seRealizoAtencion</param>
        public static void ModificarTurnoCompletado(TurnoMedico turnoMedico)
        {
            try
            {
                using (SqlConnection sqlConnection = new(TurnoMedicoSql.conexion))
                {
                    sqlConnection.Open();

                    string query = "UPDATE TurnoMedico SET seRealizoAtencionDelTurno = @seRealizoAtencionDelTurno WHERE idDeTurnoMedico = @IdDeTurnoMedico";
                    SqlCommand command = new(query, sqlConnection);
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("IdDeTurnoMedico", turnoMedico.IdDeTurnoMedico);
                    command.Parameters.AddWithValue("seRealizoAtencionDelTurno", turnoMedico.SeRealizoAtencionDelTurno.ToString());
                    command.ExecuteNonQuery();


                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Elimina un TurnoMedico de la tabla TurnoMedico de la database TP4_AlvarezMartinAndres_DB
        /// </summary>
        /// <param name="idDeTurnoMedico">El id del TurnoMedico a eliminar</param>
        public static void Borrar(int idDeTurnoMedico)
        {
            try
            {
                using (SqlConnection sqlConnection = new(TurnoMedicoSql.conexion))
                {
                    string sentencia = "DELETE FROM TurnoMedico WHERE idDeTurnoMedico = @idDeTurnoMedico";
                    SqlCommand comandoSql = new(sentencia, sqlConnection);
                    comandoSql.Parameters.Clear();
                    comandoSql.Parameters.AddWithValue("idDeTurnoMedico", idDeTurnoMedico);
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
