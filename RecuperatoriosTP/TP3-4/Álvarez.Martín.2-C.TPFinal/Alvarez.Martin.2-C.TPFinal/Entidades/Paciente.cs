using System;
using System.Collections.Generic;

namespace Entidades
{
    public class Paciente : Persona
    {

        private int idDePaciente;
        private List<Atencion> listaDeAtenciones;
        private string antecedentesMedicos;
        private bool tratamientoEnCurso;

        /// <summary>
        /// Construye un Paciente, instanciando listaDeAtenciones y tratamientoEnCurso en false;
        /// </summary>
        public Paciente()
        {
            this.listaDeAtenciones = new();
            this.tratamientoEnCurso = false;
        }

        /// <summary>
        /// Construye un Paciente, indicando sus datos personales y sus datos médicos.
        /// </summary>
        /// <param name="dni">Su documento de la identidad, es único y irremplazable </param>
        /// <param name="edad">Su edad</param>
        /// <param name="nombre">Su nombre</param>
        /// <param name="sexo">Su sexo</param>
        /// <param name="idDePaciente">Su identificador único como cliente</param>
        /// <param name="listaDeAtenciones">Su lista de atenciones, esta contiene datos sobre su salud</param>
        /// <param name="tratamientoEnCurso">Si todavia está en un tratamiento activo</param>
        /// <param name="antecedentesMedicos">Un informe con los antecedentes médicos escritos por un médico</param>
        public Paciente(int dni, int edad, string nombre, sexoEnum sexo, int idDePaciente, List<Atencion> listaDeAtenciones, bool tratamientoEnCurso, string antecedentesMedicos) : base(dni, edad, nombre, sexo)
        {
            this.IdDePaciente = idDePaciente;
            this.ListaDeAtenciones = listaDeAtenciones;
            this.AntecedentesMedicos = antecedentesMedicos;
            this.TratamientoEnCurso = tratamientoEnCurso;
        }


        /// <summary>
        /// Propiedad que administra el atributo idDePaciente, este atributo es único de cada paciente
        /// </summary>
        public int IdDePaciente { get => idDePaciente; set => idDePaciente = value; }

        /// <summary>
        /// Propiedad que administra el atributo listaDeAtenciones, una lista que contiene todas las atenciones que recibió el paciente
        /// </summary>
        public List<Atencion> ListaDeAtenciones { get => listaDeAtenciones; set => listaDeAtenciones = value; }

        /// <summary>
        /// Propiedad que administra el atributo antecedentesMedicos, contiene todos los antecedentes médicos del paciente
        /// </summary>
        public string AntecedentesMedicos { get => antecedentesMedicos; set => antecedentesMedicos = value; }

        /// <summary>
        /// Propiedad que administra el atributo tratamientoEnCurso, hace referencia a si el paciente está en un tratamiento actualmente
        /// </summary>
        public bool TratamientoEnCurso { get => tratamientoEnCurso; set => tratamientoEnCurso = value; }


        /// <summary>
        /// Busca el id de un paciente en la lista pasada como parametro
        /// </summary>
        /// <param name="idDelPaciente">Identificador único de un paciente</param>
        /// <param name="listaDeLosPacientes">Lista de pacientes donde se busca el id</param>
        /// <returns>null si no encontró el paciente en la lista, el paciente si lo encontró</returns>
        public static Paciente BuscarPacienteEnListaMedianteId(int idDelPaciente, List<Paciente> listaDeLosPacientes)
        {
            if (idDelPaciente > 0 && listaDeLosPacientes is not null)
            {
                foreach (Paciente item in listaDeLosPacientes)
                {
                    if (item.idDePaciente == idDelPaciente)
                        return item;
                }
            }
            return null;
        }

        /// <summary>
        /// Sobrecarga el == y compara los atributos idDePaciente y Dni, si coinciden los pacientes son iguales y retorna true
        /// </summary>
        /// <param name="pUno">El primer paciente para comparar</param>
        /// <param name="pDos">El segundo paciente para comparar</param>
        /// <returns>True si son iguales, ArgumentNullException si alguno de los parametros es null</returns>
        public static bool operator ==(Paciente pUno, Paciente pDos)
        {
            if (pUno is not null && pDos is not null)
            {
                return (pUno.idDePaciente == pDos.idDePaciente && pUno.Dni == pDos.Dni);
            }
            else
                throw new ArgumentNullException("Imposible comprarar entre null");
        }

        /// <summary>
        /// Sobrecarga el != y compara los atributos idDePaciente y Dni, si son distintos los pacientes son distintos y retorna true
        /// </summary>
        /// <param name="pUno">El primer paciente para comparar</param>
        /// <param name="pDos">El segundo paciente para comparar</param>
        /// <returns>true si son distintos, ArgumentNullException si alguno de los parametros es null </returns>
        public static bool operator !=(Paciente pUno, Paciente pDos)
        {
            if (pUno is not null && pDos is not null)
                return !(pUno == pDos);
            else
                throw new ArgumentNullException("Imposible comprarar entre null");

        }
    }
}
