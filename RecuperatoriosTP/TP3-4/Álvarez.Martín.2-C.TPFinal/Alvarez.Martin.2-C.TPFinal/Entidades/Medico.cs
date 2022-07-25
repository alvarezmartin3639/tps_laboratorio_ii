using System.Collections.Generic;

namespace Entidades
{
    public class Medico : Persona
    {
        private int idDeMedico;
        private int matricula;
        private List<Atencion> atencionesRealizadas;


        /// <summary>
        /// Constructor por defecto de un Medico, instancia la lista de atención
        /// </summary>
        public Medico()
        {
            this.atencionesRealizadas = new List<Atencion>();
        }

        /// <summary>
        /// Construye un médico junto con sus atenciones brindadas
        /// </summary>
        /// <param name="dni">Su documento de la identidad, es único y irremplazable </param>
        /// <param name="edad">Su edad</param>
        /// <param name="nombre">Su nombre</param>
        /// <param name="sexo">Su sexo</param>
        /// <param name="idDeMedico">Su identificador único de médico</param>
        /// <param name="contrasena">Su contraseña, necesaria para logearse</param>
        /// <param name="matricula">Su identificador único que lo habilita a ejercer como médico</param>
        /// <param name="atencionesRealizadas">Sus atenciones realizadas a pacientes</param>
        public Medico(int dni, int edad, string nombre, sexoEnum sexo, int idDeMedico, int matricula, List<Atencion> atencionesRealizadas) : base(dni, edad, nombre, sexo)
        {
            this.idDeMedico = idDeMedico;
            this.matricula = matricula;
            this.atencionesRealizadas = atencionesRealizadas;
        }


        /// <summary>
        /// Propiedad que administra el atributo idDeMedico, su valor debe ser único de cada médico
        /// </summary>
        public int IdDeMedico { get => idDeMedico; set => idDeMedico = value; }

        /// <summary>
        /// Propiedad que administra el atributo matricula, su valor debe ser único de cada médico
        /// </summary>
        public int Matricula { get => matricula; set => matricula = value; }

        /// <summary>
        /// Propiedad que administra el atributo pacientesAtendidos, contiene una lista de todas las atenciones a pacientes de un médico
        /// </summary>
        public List<Atencion> PacientesAtendidos { get => atencionesRealizadas; set => atencionesRealizadas = value; }

        /// <summary>
        /// Verifica que una lista tenga el medico con el id pasado por parametro
        /// </summary>
        /// <param name="list">La lista donde buscar</param>
        /// <param name="idDelMedico">El id del medico a buscar</param>
        /// <returns>True si se encuentra en la lista, false si no se encuentra.</returns>
        public static bool ExisteMedicoEnLalista(List<Medico> list, int idDelMedico)
        {
         bool   retorno = false;
            if(list != null)
            {
                foreach (Medico item in list)
                {
                    if (item.idDeMedico == idDelMedico)
                        return true;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Busca el id de un medico en la lista pasada como parametro
        /// </summary>
        /// <param name="idDelMedico">Identificador único de un medico</param>
        /// <param name="listaDeLosMedicos">Lista de medicos donde se busca el id</param>
        /// <returns>null si no se encontró médico en la lista, el  médico si se lo encontró</returns>
        public static Medico BuscarPacienteEnListaMedianteId(int idDelMedico, List<Medico> listaDeLosMedicos)
        {
            if (idDelMedico > 0 && listaDeLosMedicos is not null)
            {
                foreach (Medico item in listaDeLosMedicos)
                {
                    if (item.idDeMedico == idDelMedico)
                        return item;
                }
            }
            return null;
        }
    }
}
