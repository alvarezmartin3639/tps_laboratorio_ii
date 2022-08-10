
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
        private string conexionSql;

        /// <summary>
        /// Constructor estatico, instancia el atributo estatico conexion con la información del server
        /// </summary>
        static PacienteSql()
        {
           conexion = "Server = .\\sqlexpress ; Database = TP4_AlvarezMartinAndres_DB; Trusted_Connection = true ;";
        }

        /// <summary>
        /// Constructor encargado de instanciar el string conexion y el sqlConnection
        /// </summary>
        /// <param name="conexionSettings">La configuración para conectarse al servidor sql</param>
        public PacienteSql(string conexionSettings)
        {
            this.sqlConnection = new SqlConnection(conexionSettings);
            this.conexionSql = conexionSettings;
        }

        /// <summary>
        /// Busca un paciente en la database TP4_AlvarezMartinAndres_DB y lo retorna
        /// </summary>
        /// <param name="idDePaciente"></param>
        /// <returns>el paciente si lo encontró</returns>
        public Paciente BuscarPorId(int idDePaciente)
        {
            Paciente pacienteNuevo = new();

            try
            {

                string sentencia = "SELECT * FROM Paciente where idDePaciente=@idDePaciente";
                SqlCommand comandoSql = new(sentencia, this.sqlConnection);
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
                    pacienteNuevo.ListaDeAtenciones = tablaAtencion.BuscarAtencionesDeUnPacienteMedianteSuId(pacienteNuevo.IdDePaciente);
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
        public static List<Paciente> Leer()
        {
            List<Paciente> lista = new();
            try
            {
                string sentencia = "SELECT * FROM Paciente";
                using (SqlConnection sqlConnection = new(PacienteSql.conexion))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new(sentencia, sqlConnection);
                    SqlDataReader dataReader = sqlCommand.ExecuteReader();
                    AtencionSql tablaAtencion = new("Server = (local)\\sqlexpress ; Database = TP4_AlvarezMartinAndres_DB; Trusted_Connection = true ;");

                    while (dataReader.Read())
                    {
                        Paciente pacienteNuevo = new();
                        pacienteNuevo.IdDePaciente = int.Parse(dataReader["idDePaciente"].ToString());
                        pacienteNuevo.Nombre = dataReader["nombre"].ToString();
                        pacienteNuevo.Edad = int.Parse(dataReader["edad"].ToString());
                        pacienteNuevo.Dni = int.Parse(dataReader["dni"].ToString());
                        pacienteNuevo.Sexo = (sexoEnum)Enum.Parse(typeof(sexoEnum), dataReader["sexo"].ToString());
                        pacienteNuevo.AntecedentesMedicos = dataReader["antecedentesMedicos"].ToString();
                        pacienteNuevo.TratamientoEnCurso = bool.Parse(dataReader["tratamientoEnCurso"].ToString());
                        pacienteNuevo.ListaDeAtenciones = tablaAtencion.BuscarAtencionesDeUnPacienteMedianteSuId(pacienteNuevo.IdDePaciente);
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
        public bool Agregar(Paciente objetoParaAgregar)
        {

            try
            {
                MisComandosSql misCommandosSql = new(PacienteSql.conexion);
                bool retorno = false;
                if (MisComandosSql.VerificarSingularidad("Paciente", "dni", objetoParaAgregar.Dni, PacienteSql.conexion))
                {

                    using (SqlConnection sqlConnection = new(this.conexionSql))
                    {
                        sqlConnection.Open();
                        string sentencia = "INSERT INTO Paciente ( nombre, edad, dni," +
                            " sexo, antecedentesMedicos, tratamientoEnCurso) " +
                            "VALUES ( @nombre, @edad, @dni," +
                            " @sexo, @antecedentesMedicos, @tratamientoEnCurso)";

                        SqlCommand sqlCommand = new(sentencia, sqlConnection);
                        sqlCommand.Parameters.AddWithValue("nombre", objetoParaAgregar.Nombre);
                        sqlCommand.Parameters.AddWithValue("edad", objetoParaAgregar.Edad);
                        sqlCommand.Parameters.AddWithValue("dni", objetoParaAgregar.Dni);
                        sqlCommand.Parameters.AddWithValue("sexo", objetoParaAgregar.Sexo.ToString());
                        sqlCommand.Parameters.AddWithValue("antecedentesMedicos", objetoParaAgregar.AntecedentesMedicos);
                        sqlCommand.Parameters.AddWithValue("tratamientoEnCurso", objetoParaAgregar.TratamientoEnCurso.ToString());

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
        /// Elimina un Paciente de la tabla Paciente de ladatabase TP4_AlvarezMartinAndres_DB
        /// </summary>
        /// <param name="idDePaciente">El id del paciente a eliminar</param>

        public static void Borrar(int idDePaciente)
        {
            try
            {
                using (SqlConnection sqlConnection = new(PacienteSql.conexion))
                {
                    string sentencia = "DELETE FROM Paciente WHERE idDePaciente = @idDePaciente";
                    SqlCommand comandoSql = new(sentencia, sqlConnection);
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
