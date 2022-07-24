using Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MenuPrincipal
{
    public partial class frmNuevaAtencion : Form
    {
        private List<Paciente> listaDePacientesNueva;
        private List<Medico> listaDeMedicosNueva;
        private List<Atencion> listaDeAtencionNueva;
        private Atencion atencionCreada;

        #region CONSTRUCTORES Y PROPIEDADES

        /// <summary>
        /// Constructor de frmNuevaAtencon, inicializa los controles y la atencionCreada
        /// </summary>
        public frmNuevaAtencion()
        {
            InitializeComponent();
            this.atencionCreada = new();
            this.ListaDeAtencionNueva = new();
        }

        /// <summary>
        /// Constructor de frmNuevaAtencon, inicializa los controles,la atencionCreada junto con las listas de pacientes y medicos
        /// </summary>
        /// <param name="listaDeMedicos">lista completa de los medicos del sistema</param>
        /// <param name="listaDePacientes">lista completa de los pacientes del sistema</param>
        public frmNuevaAtencion(List<Medico> listaDeMedicos, List<Paciente> listaDePacientes, List<Atencion> listaDeAtecion) : this()
        {
            this.listaDePacientesNueva = listaDePacientes;
            this.ListaDeMedicosNueva = listaDeMedicos;
            this.listaDeAtencionNueva = listaDeAtecion;
        }

        /// <summary>
        /// Propiedad de listaDePacientesNueva, remplaza o da un valor a dicho atributo
        /// </summary>
        public List<Paciente> ListaDePacientesNueva { get => listaDePacientesNueva; set => listaDePacientesNueva = value; }

        /// <summary>
        /// Propiedad de listaDeAtencionNueva, remplaza od a un valor a dicho atributo
        /// </summary>
        public List<Medico> ListaDeMedicosNueva { get => listaDeMedicosNueva; set => listaDeMedicosNueva = value; }

        /// <summary>
        /// Propiedad de listaDeAtencionNueva, remplaza o da un valor a dicho atributo
        /// </summary>
        public List<Atencion> ListaDeAtencionNueva { get => listaDeAtencionNueva; set => listaDeAtencionNueva = value; }

        #endregion


        /// <summary>
        /// Ejecuta el form frmVentanaEmergenteConInputBox para redactar el motivo de la consulta de la atención
        /// </summary>
        /// <param name="sender">emisor del evento</param>
        /// <param name="e">Información de dicho evento</param>
        private void bttnRedactarMotivoDeLaConsulta_Click(object sender, EventArgs e)
        {
            if (this.atencionCreada is not null)
            {
                frmVentanaEmergenteConInputBox ventanaEmergentePidiendoMotivoDeConsulta = new(atencionCreada.MotivoDeLaConsulta, "Escribiendo motivo de la consulta", "Redacte el motivo de la consulta:");
                ventanaEmergentePidiendoMotivoDeConsulta.ShowDialog();
                atencionCreada.MotivoDeLaConsulta = ventanaEmergentePidiendoMotivoDeConsulta.informacionEscrita;
            }

        }

        /// <summary>
        /// Ejecuta el form frmVentanaEmergenteConInputBox para redactar el diagnostico de la atención
        /// </summary>
        /// <param name="sender">emisor del evento</param>
        /// <param name="e">Información de dicho evento</param>
        private void bttnRedactarDiagnostico_Click(object sender, EventArgs e)
        {
            if (this.atencionCreada is not null)
            {
                frmVentanaEmergenteConInputBox ventanaEmergentePidiendoMotivoDeConsulta = new(atencionCreada.Diagnostico, "Escribiendo el  diagnostico", "Redacte el diagnostico:");
                ventanaEmergentePidiendoMotivoDeConsulta.ShowDialog();
                atencionCreada.Diagnostico = ventanaEmergentePidiendoMotivoDeConsulta.informacionEscrita;
            }
        }

        /// <summary>
        /// Ejecuta el form frmVentanaEmergenteConInputBox para redactar el tratamiento que se le dio al finalizar dicha atención
        /// </summary>
        /// <param name="sender">emisor del evento</param>
        /// <param name="e">Información de dicho evento</param>
        private void bttnRedactarTratamiento_Click(object sender, EventArgs e)
        {
            if (this.atencionCreada is not null)
            {
                frmVentanaEmergenteConInputBox ventanaEmergentePidiendoMotivoDeConsulta = new(atencionCreada.Tratamiento, "Escribiendo  la consulta", "Redacte la consulta:");
                ventanaEmergentePidiendoMotivoDeConsulta.ShowDialog();
                atencionCreada.Tratamiento = ventanaEmergentePidiendoMotivoDeConsulta.informacionEscrita;
            }
        }



        /// <summary>
        /// Finaliza la atención verificando que el paciente exista en la lista, luego lo modifica agregando la atención a su atributo "ListaDeAtenciones"
        /// </summary>
        /// <param name="sender">emisor del evento</param>
        /// <param name="e">Información de dicho evento</param>
        private void bttnFinalizarAtencion_Click(object sender, EventArgs e)
        {
            bool sePuedeCrearAtencion = true;

            try
            {
                if (!int.TryParse(txtIdDePaciente.Text, out int auxNum)) // SI SE VALIDA TODOS LOS DATOS SE CREA LA ATENCIÓN AGREGANDOLA AL PACIENTE Y MEDICO
                {
                    MessageBox.Show("El id  de paciente no puede contener caracteres", "Error al crear Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    sePuedeCrearAtencion = false;
                }
                else
                {
                    Paciente auxPaciente = Paciente.BuscarPacienteEnListaMedianteId(int.Parse(txtIdDePaciente.Text), this.listaDePacientesNueva);
                    if (auxPaciente is null)
                    {
                        MessageBox.Show("No coincide ningun paciente con la id brindada", "Error al crear Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        sePuedeCrearAtencion = false;
                    }
                    else
                    {
                        if (!int.TryParse(txtIdDeMedico.Text, out int auxNumDos))
                        {
                            MessageBox.Show("El id  del medico no puede contener caracteres", "Error al crear Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            sePuedeCrearAtencion = false;
                        }
                        else
                        {
                            Medico auxMedico = Medico.BuscarPacienteEnListaMedianteId(int.Parse(txtIdDePaciente.Text), this.ListaDeMedicosNueva);
                            if (auxMedico is null)
                            {
                                MessageBox.Show("No coincide ningun médico con la id brindada", "Error al crear Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                sePuedeCrearAtencion = false;
                            }
                            else
                            {
                                if (sePuedeCrearAtencion == false && string.IsNullOrEmpty(this.atencionCreada.MotivoDeLaConsulta) && string.IsNullOrEmpty(this.atencionCreada.Tratamiento) && string.IsNullOrEmpty(this.atencionCreada.Diagnostico))
                                {
                                    MessageBox.Show("Existen campos incompletos necesarios para crear una atención", "Error al crear Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                }
                                else
                                {
                                    this.listaDePacientesNueva.Remove(auxPaciente);//REFRESCO INFORMACION DE LA ATENCION
                                    auxPaciente.ListaDeAtenciones.Add(atencionCreada);
                                    this.ListaDePacientesNueva.Add(auxPaciente);
                                    this.ListaDeMedicosNueva.Remove(auxMedico);
                                    auxMedico.PacientesAtendidos.Add(atencionCreada);
                                    this.ListaDeMedicosNueva.Add(auxMedico);

                                    this.atencionCreada.IdDeAtencion = this.listaDeAtencionNueva.Count + 1;
                                    this.atencionCreada.IdDeMedico = int.Parse(txtIdDeMedico.Text);
                                    this.atencionCreada.IdDePaciente = int.Parse(txtIdDePaciente.Text);
                                    this.atencionCreada.FechaDeLaAtencion = DateTime.Now;
                                    this.listaDeAtencionNueva.Add(atencionCreada);

                                    MessageBox.Show("¡Atención generado con exito!", "Se finalizó la atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al finalizar atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

