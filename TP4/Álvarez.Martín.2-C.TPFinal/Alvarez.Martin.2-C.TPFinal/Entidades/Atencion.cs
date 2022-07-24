using System;

namespace Entidades
{
    public class Atencion
    {
        private int idDeAtencion;
        private int idDeMedico;
        private int idDePaciente;
        private string motivoDeLaConsulta;
        private string tratamiento;
        private string diagnostico;
        private DateTime fechaDeLaAtencion;


        /// <summary>
        /// Construye una atención definiendo instanciando el dateTime
        /// </summary>
        public Atencion()
        {
            this.FechaDeLaAtencion = new DateTime();
        }

        /// <summary>
        /// Construye una atención entre un paciente y un medico
        /// </summary>
        /// <param name="idDeAtencion">El identificador de la atención</param>
        /// <param name="idDeMedico">El identificador del médico que atiende</param>
        /// <param name="idDePaciente">El identificador del paciente que es atendido</param>
        /// <param name="motivoDeLaConsulta">El motivo por el cual se atiende</param>
        /// <param name="tratamiento">El tratamiento que recibe</param>
        /// <param name="diagnostico">El diagnostico que recibió del médico </param>
        /// <param name="fechaDeLaAtencion">La fecha que se realizó la atención</param>
        public Atencion(int idDeAtencion, int idDeMedico, int idDePaciente, string motivoDeLaConsulta, string tratamiento, string diagnostico, DateTime fechaDeLaAtencion)
        {
            this.IdDeAtencion = idDeAtencion;
            this.IdDeMedico = idDeMedico;
            this.IdDePaciente = idDePaciente;
            this.MotivoDeLaConsulta = motivoDeLaConsulta;
            this.Tratamiento = tratamiento;
            this.Diagnostico = diagnostico;
            this.FechaDeLaAtencion = fechaDeLaAtencion;
        }


        /// <summary>
        /// Propiedad que administra el atributo idDeAtencion
        /// </summary>
        public int IdDeAtencion { get => idDeAtencion; set => idDeAtencion = value; }

        /// <summary>
        /// Propiedad que administra el atributo idDeMedico
        /// </summary>
        public int IdDeMedico { get => idDeMedico; set => idDeMedico = value; }

        /// <summary>
        /// Propiedad que administra el atributo idDePaciente
        /// </summary>
        public int IdDePaciente { get => idDePaciente; set => idDePaciente = value; }

        /// <summary>
        /// Propiedad que administra el atributo motivoDeLaConsulta
        /// </summary>
        public string MotivoDeLaConsulta { get => motivoDeLaConsulta; set => motivoDeLaConsulta = value; }

        /// <summary>
        /// Propiedad que administra el atributo tratamiento
        /// </summary>
        public string Tratamiento { get => tratamiento; set => tratamiento = value; }

        /// <summary>
        /// Propiedad que administra el atributo diagnostico
        /// </summary>
        public string Diagnostico { get => diagnostico; set => diagnostico = value; }

        /// <summary>
        /// Propiedad que administra el atributo fechaDeLaAtencion
        /// </summary>
        public DateTime FechaDeLaAtencion { get => fechaDeLaAtencion; set => fechaDeLaAtencion = value; }





    }
}
