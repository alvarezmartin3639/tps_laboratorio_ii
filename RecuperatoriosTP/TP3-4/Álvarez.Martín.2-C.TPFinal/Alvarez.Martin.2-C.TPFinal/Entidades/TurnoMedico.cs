using System;

namespace Entidades
{
    public class TurnoMedico
    {
        private DateTime fechaTurno;
        private int idDeMedico;
        private int idDePaciente;
        private int idDeTurnoMedico;
        private bool seRealizoAtencionDelTurno;

        /// <summary>
        /// Construye un turnoMedico
        /// </summary>
        public TurnoMedico()
        {
            this.IdDeMedico = 0;
            this.IdDePaciente = 0;
            this.FechaTurno = DateTime.Now;
            this.IdDeTurnoMedico = 0;
            this.seRealizoAtencionDelTurno = false;
        }

        /// <summary>
        /// Construye un TurnoMedico inciando sus atributos
        /// </summary>
        /// <param name="idDeTurnoMedico"></param>
        /// <param name="idDeMedico"></param>
        /// <param name="idDePaciente"></param>
        /// <param name="fechaTurno"></param>
        /// <param name="seRealizoAtencionDelTurno"></param>
        public TurnoMedico(int idDeTurnoMedico, int idDeMedico, int idDePaciente, DateTime fechaTurno, bool seRealizoAtencionDelTurno)
        {
            this.IdDeMedico = idDeMedico;
            this.IdDePaciente = idDePaciente;
            this.FechaTurno = fechaTurno;
            this.idDeTurnoMedico = idDeTurnoMedico;
            this.seRealizoAtencionDelTurno = seRealizoAtencionDelTurno;
        }

        /// <summary>
        /// Propiedad que permite recibir y dar un valor al atributo fechaTurno
        /// </summary>
        public DateTime FechaTurno { get => fechaTurno; set => fechaTurno = value; }

        /// <summary>
        /// Propeidad que permite recibir y dar un valor al atributo idDeMedico
        /// </summary>
        public int IdDeMedico { get => idDeMedico; set => idDeMedico = value; }

        /// <summary>
        /// Propeidad que permite recibir y dar un valor al atributo idDePaciente
        /// </summary>
        public int IdDePaciente { get => idDePaciente; set => idDePaciente = value; }

        /// <summary>
        /// Propeidad que permite recibir y dar un valor al atributo IdDeTurnoMedico
        /// </summary>
        public int IdDeTurnoMedico { get => idDeTurnoMedico; set => idDeTurnoMedico = value; }
        /// <summary>
        /// Propeidad que permite recibir y dar un valor al atributo SeRealizoAtencionDelTurno
        /// </summary>
        public bool SeRealizoAtencionDelTurno { get => seRealizoAtencionDelTurno; set => seRealizoAtencionDelTurno = value; }
    }
}
