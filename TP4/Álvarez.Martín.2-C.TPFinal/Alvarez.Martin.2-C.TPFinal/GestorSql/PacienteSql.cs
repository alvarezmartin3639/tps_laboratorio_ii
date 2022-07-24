
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GestorSql
{
    public class PacienteSql : ISqlEntidad<Paciente>
    {
        private SqlConnection sqlConnection;
        private static string conexion;

        /// <summary>
        /// Constructor encargado de instanciar el string conexion y el sqlConnection
        /// </summary>
        /// <param name="conexionSettings">La configuración para conectarse al servidor sql</param>
        public PacienteSql(string conexionSettings)
        {
            PacienteSql.conexion = conexionSettings;
        }

        /// <summary>
        /// Busca un paciente en la database TP4_AlvarezMartinAndres_DB y lo retorna
        /// </summary>
        /// <param name="idDePaciente"></param>
        /// <returns>el paciente si lo encontró</returns>
        public Paciente BuscarPorId(int idDePaciente)
        {
            Paciente pacienteNuevo = new Paciente();

            try
            {

                string sentencia = "SELECT * FROM Paciente where idDePaciente=@idDePaciente";
                SqlCommand comandoSql = new SqlCommand(sentencia, this.sqlConnection);
                comandoSql.Parameters.AddWithValue("idDePaciente", idDePaciente);
                this.sqlConnection.Open();
                SqlDataReader dataReader = comandoSql.ExecuteReader();
                AtencionSql tablaAtencion = new("Server = (local)\\sqlexpress ; Database = TP4_AlvarezMartinAndres_DB; Trusted_Connection = true ;");

                while (dataReader.Read())
                {
                    pacienteNuevo.IdDePaciente = int.Parse(dataReader["idDePaciente"].ToString());
                    pacienteNuevo.Nombre = dataReader["nombre"].ToString();
                    pacienteNuevo.Edad = int.Parse(dataReader["edad"].ToString());
                    pacienteNuevo.Dni = int.Parse(dataReader["dni"].ToString());
                    pacienteNuevo.Sexo = (sexoEnum)int.Parse(dataReader["sexo"].ToString());
                    pacienteNuevo.AntecedentesMedicos = dataReader["antecedentesMedicos"].ToString();
                    pacienteNuevo.TratamientoEnCurso = bool.Parse(dataReader["tratamientoEnCurso"].ToString());
                    pacienteNuevo.ListaDeAtenciones = tablaAtencion.buscarAtencionesDeUnPacienteMedianteSuId(pacienteNuevo.IdDePaciente);
                }

                return pacienteNuevo;
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
        /// Importa todos los pacientes que existen en la tabla Paciente de la database TP4_AlvarezMartinAndres_DB
        /// </summary>
        /// <returns>List<Paciente> con todos los pacientes de la tabla </Paciente></returns>
        public List<Paciente> Leer()
        {
            List<Paciente> lista = new List<Paciente>();
            try
            {
                string sentencia = "SELECT * FROM Paciente";
                using (SqlConnection sqlConnection = new SqlConnection(PacienteSql.conexion))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand(sentencia, sqlConnection);
                    SqlDataReader dataReader = sqlCommand.ExecuteReader();
                    AtencionSql tablaAtencion = new("Server = (local)\\sqlexpress ; Database = TP4_AlvarezMartinAndres_DB; Trusted_Connection = true ;");

                    while (dataReader.Read())
                    {
                        Paciente pacienteNuevo = new Paciente();
                        pacienteNuevo.IdDePaciente = int.Parse(dataReader["idDePaciente"].ToString());
                        pacienteNuevo.Nombre = dataReader["nombre"].ToString();
                        pacienteNuevo.Edad = int.Parse(dataReader["edad"].ToString());
                        pacienteNuevo.Dni = int.Parse(dataReader["dni"].ToString());
                        pacienteNuevo.Sexo = (sexoEnum)Enum.Parse(typeof(sexoEnum), dataReader["sexo"].ToString());
                        pacienteNuevo.AntecedentesMedicos = dataReader["antecedentesMedicos"].ToString();
                        pacienteNuevo.TratamientoEnCurso = bool.Parse(dataReader["tratamientoEnCurso"].ToString());
                        pacienteNuevo.ListaDeAtenciones = tablaAtencion.buscarAtencionesDeUnPacienteMedianteSuId(pacienteNuevo.IdDePaciente);
                        lista.Add(pacienteNuevo);
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
        /// Exporta un paciente a la tabla Paciente de la database TP4_AlvarezMartinAndres_DB
        /// </summary>
        /// <param name="objetoParaAgregar">El paciente para agregar</param>
        /// <returns>Un string confirmando que se guardo un Paciente</returns>
        public string Agregar(Paciente objetoParaAgregar)
        {
            string retunrAux = string.Empty;

            try
            {
                if (MisComandosSql.VerificarSingularidad("Paciente", "idDePaciente", objetoParaAgregar.IdDePaciente, PacienteSql.conexion))
                {
                    using (SqlConnection sqlConnection = new SqlConnection(PacienteSql.conexion))
                    {
                        sqlConnection.Open();
                        string sentencia = "INSERT INTO Paciente ( nombre, edad, dni," +
                            " sexo, antecedentesMedicos, tratamientoEnCurso) " +
                            "VALUES ( @nombre, @edad, @dni," +
                            " @sexo, @antecedentesMedicos, @tratamientoEnCurso)";

                        SqlCommand sqlCommand = new SqlCommand(sentencia, sqlConnection);
                        sqlCommand.Parameters.AddWithValue("nombre", objetoParaAgregar.Nombre);
                        sqlCommand.Parameters.AddWithValue("edad", objetoParaAgregar.Edad);
                        sqlCommand.Parameters.AddWithValue("dni", objetoParaAgregar.Dni);
                        sqlCommand.Parameters.AddWithValue("sexo", objetoParaAgregar.Sexo.ToString());
                        sqlCommand.Parameters.AddWithValue("antecedentesMedicos", objetoParaAgregar.AntecedentesMedicos);
                        sqlCommand.Parameters.AddWithValue("tratamientoEnCurso", objetoParaAgregar.TratamientoEnCurso.ToString());

                        sqlCommand.ExecuteNonQuery();
                        retunrAux = "Se guardo el Paciente";
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
        /// Elimina un Paciente de la tabla Paciente de ladatabase TP4_AlvarezMartinAndres_DB
        /// </summary>
        /// <param name="idDePaciente">El id del paciente a eliminar</param>

        public void Borrar(int idDePaciente)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(PacienteSql.conexion))
                {
                    string sentencia = "DELETE FROM Paciente WHERE idDePaciente = @idDePaciente";
                    SqlCommand comandoSql = new SqlCommand(sentencia, sqlConnection);
                    comandoSql.Parameters.Clear();
                    comandoSql.Parameters.AddWithValue("idDePaciente", idDePaciente);
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
