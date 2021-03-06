using Entidades;
using MostrarUnPaciente;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VentanaEmergenteConInputBox;

namespace NuevaAtencion
{
    public partial class frmNuevaAtencion : Form
    {
        private List<Paciente> listaDePacientesNueva;
        private List<Medico> listaDeMedicosNueva;
        private Atencion atencionCreada;

        #region CONSTRUCTORES Y PROPIEDADES

        /// <summary>
        /// Constructor de frmNuevaAtencon, inicializa los controles y la atencionCreada
        /// </summary>
        public frmNuevaAtencion()
        {
            InitializeComponent();
            this.atencionCreada = new();
        }

        /// <summary>
        /// Constructor de frmNuevaAtencon, inicializa los controles,la atencionCreada junto con las listas de pacientes y medicos
        /// </summary>
        /// <param name="listaDeMedicos">lista completa de los medicos del sistema</param>
        /// <param name="listaDePacientes">lista completa de los pacientes del sistema</param>
        public frmNuevaAtencion(List<Medico> listaDeMedicos, List<Paciente> listaDePacientes) : this()
        {
            this.listaDePacientesNueva = listaDePacientes;
            this.listaDeMedicosNueva = listaDeMedicos;
        }

        /// <summary>
        /// Propiedad de listaDePacientesNueva, remplaza o da un valor a dicho atributo
        /// </summary>
        public List<Paciente> ListaDePacientesNueva { get => listaDePacientesNueva; set => listaDePacientesNueva = value; }

        #endregion


        /// <summary>
        /// Ejecuta el form frmVentanaEmergenteConInputBox para redactar el motivo de la consulta de la atención
        /// </summary>
        /// <param name="sender">emisor del evento</param>
        /// <param name="e">Información de dicho evento</param>
        private void bttnRedactarMotivoDeLaConsulta_Click(object sender, EventArgs e)
        {
            frmVentanaEmergenteConInputBox ventanaEmergentePidiendoMotivoDeConsulta = new(atencionCreada.MotivoDeLaConsulta, "Escribiendo motivo de la consulta", "Redacte el motivo de la consulta:");
            ventanaEmergentePidiendoMotivoDeConsulta.ShowDialog();
            atencionCreada.MotivoDeLaConsulta = ventanaEmergentePidiendoMotivoDeConsulta.informacionEscrita;
        }

        /// <summary>
        /// Ejecuta el form frmVentanaEmergenteConInputBox para redactar el diagnostico de la atención
        /// </summary>
        /// <param name="sender">emisor del evento</param>
        /// <param name="e">Información de dicho evento</param>
        private void bttnRedactarDiagnostico_Click(object sender, EventArgs e)
        {
            frmVentanaEmergenteConInputBox ventanaEmergentePidiendoMotivoDeConsulta = new(atencionCreada.Diagnostico, "Escribiendo el  diagnostico", "Redacte el diagnostico:");
            ventanaEmergentePidiendoMotivoDeConsulta.ShowDialog();
            atencionCreada.Diagnostico = ventanaEmergentePidiendoMotivoDeConsulta.informacionEscrita;
        }

        /// <summary>
        /// Ejecuta el form frmVentanaEmergenteConInputBox para redactar el tratamiento que se le dio al finalizar dicha atención
        /// </summary>
        /// <param name="sender">emisor del evento</param>
        /// <param name="e">Información de dicho evento</param>
        private void bttnRedactarTratamiento_Click(object sender, EventArgs e)
        {
            frmVentanaEmergenteConInputBox ventanaEmergentePidiendoMotivoDeConsulta = new(atencionCreada.Tratamiento, "Escribiendo  la consulta", "Redacte la consulta:");
            ventanaEmergentePidiendoMotivoDeConsulta.ShowDialog();
            atencionCreada.Tratamiento = ventanaEmergentePidiendoMotivoDeConsulta.informacionEscrita;
        }



        /// <summary>
        /// Finaliza la atención verificando que el paciente exista en la lista, luego lo modifica agregando la atención a su atributo "ListaDeAtenciones"
        /// </summary>
        /// <param name="sender">emisor del evento</param>
        /// <param name="e">Información de dicho evento</param>
        private void bttnFinalizarAtencion_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtIdDePaciente.Text, out int auxNum)) 
                MessageBox.Show("El id  de paciente no puede contener caracteres", "Error al crear Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                Paciente auxPaciente = Paciente.BuscarPacienteEnListaMedianteId(int.Parse(txtIdDePaciente.Text), this.listaDePacientesNueva);
                if (auxPaciente is not null) //SI EXISTE EN LA LISTA AGREGO LA ATENCIÓN Y LO REMPLAZO
                {
                    this.listaDePacientesNueva.Remove(auxPaciente);
                    auxPaciente.ListaDeAtenciones.Add(atencionCreada);
                    this.ListaDePacientesNueva.Add(auxPaciente);
                }
                else
                    MessageBox.Show("No coincide ningun paciente con la id brindada", "Error al crear Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (!int.TryParse(txtIdDeMedico.Text, out int auxNumer))
                MessageBox.Show("El id  del medico no puede contener caracteres", "Error al crear Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                Medico auxMedico = Medico.BuscarPacienteEnListaMedianteId(int.Parse(txtIdDePaciente.Text), this.listaDeMedicosNueva);
                if (auxMedico is not null) //SI EXISTE EN LA LISTA AGREGO LA ATENCIÓN Y LO REMPLAZO
                {
                    this.listaDeMedicosNueva.Remove(auxMedico);
                    auxMedico.PacientesAtendidos.Add(atencionCreada);
                    this.listaDeMedicosNueva.Add(auxMedico);
                }
                else
                    MessageBox.Show("No coincide ningun médico con la id brindada", "Error al crear Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Ejecuta el form frmMostrarUnPaciente para buscar un paciente por id y mostrarlo
        /// </summary>
        /// <param name="sender">emisor del evento</param>
        /// <param name="e">Información de dicho evento</param>
        private void bttnVerDatosIdDePaciente_Click(object sender, EventArgs e)
        {
            Paciente auxPaciente = Paciente.BuscarPacienteEnListaMedianteId(int.Parse(txtIdDePaciente.Text), this.listaDePacientesNueva);

            if (auxPaciente is not null)
            {
                frmMostrarUnPaciente frmMostrarPaciente = new(auxPaciente);
                frmMostrarPaciente.Show();
            }

        }

    }
}

