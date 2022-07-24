using Entidades;
using GestorArchivos;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MenuPrincipal
{
    public partial class frmMostrarLista : Form
    {
        private enum listaCargadaEnForm { Paciente, Medico, Atenciones };

        private listaCargadaEnForm entidadUsadaEnForm;
        List<Paciente> listaPaciente;
        List<Medico> listaMedicos;
        List<Atencion> listaAtenciones;

        #region CONSTRUCTORES Y PROPIEDADES

        /// <summary>
        /// Constructor de frmMostrarLista, instancia la lista de médicos, pacientes y atencionés
        /// </summary>
        public frmMostrarLista() : this(new List<Medico>(), new List<Paciente>(), new List<Atencion>())
        {
        }

        /// <summary>
        /// Constructor de frmMostrarLista, inicializa la lista de médico, pacientes,  atencionés e instancia el dataGrid con la listaPacientes 
        /// </summary>
        /// <param name="listaPaciente">lista completa de los pacientes del sistema</param>
        public frmMostrarLista(List<Paciente> listaPaciente) : this(new List<Medico>(), listaPaciente, new List<Atencion>())
        {
            this.dgvLista.DataSource = listaPaciente;
            this.entidadUsadaEnForm = listaCargadaEnForm.Paciente;
            this.OrdenarDataGridDePaciente();
        }

        /// <summary>
        /// Constructor de frmMostrarLista, inicializa la lista de médico, pacientes,  atencionés e instancia el dataGrid con la listaAtenciones 
        /// </summary>
        /// <param name="listaAtenciones">lista completa de las atenciones del sistema</param>
        public frmMostrarLista(List<Atencion> listaAtenciones) : this(new List<Medico>(), new List<Paciente>(), listaAtenciones)
        {
            this.dgvLista.DataSource = listaAtenciones;
            tlsmiVer.Available = false;
            this.Text = "Listado de atenciones";
            this.entidadUsadaEnForm = listaCargadaEnForm.Atenciones;
            this.OrdenarDataGridDeAtenciones();
        }

        /// <summary>
        /// Constructor de frmMostrarLista, inicializa la lista de médico, pacientes,  atencionés e instancia el dataGrid con la listaMedicos 
        /// </summary>
        /// <param name="listaMedicos">lista completa de los medicos del sistema</param>
        public frmMostrarLista(List<Medico> listaMedicos) : this(listaMedicos, new List<Paciente>(), new List<Atencion>())
        {
            this.dgvLista.DataSource = listaMedicos;
            this.Text = "Listado de medicos";
            this.entidadUsadaEnForm = listaCargadaEnForm.Medico;
            this.OrdenarDataGridDeMedico();
        }

        /// <summary>
        /// Constructor de frmMostrarLista, inicializa la lista de médico, pacientes con sus parametros correspondientes
        /// </summary>
        /// <param name="listaMedicos">lista completa de los medicos del sistema</param>
        /// <param name="listaPacientes">lista completa de los pacientes del sistema</param>
        /// <param name="listaAtenciones">lista completa de las atenciones del sistema</param>
        public frmMostrarLista(List<Medico> listaMedicos, List<Paciente> listaPacientes, List<Atencion> listaAtenciones)
        {
            InitializeComponent();
            this.listaMedicos = listaMedicos;
            this.listaPaciente = listaPacientes;
            this.listaAtenciones = listaAtenciones;
        }

        #endregion


        #region EVENTOS FORM

        /// <summary>
        /// Evento load del form, deshabilita tlsmiArchivosExportar y tlsmiVer si la lista de pacientes o medicos está vacia
        /// </summary>
        /// <param name="sender">emisor del evento</param>
        /// <param name="e">Información de dicho evento</param>
        private void frmMostrarLista_Load(object sender, EventArgs e)
        {
            if (this.listaPaciente.Count == 0 && this.entidadUsadaEnForm == listaCargadaEnForm.Paciente || this.listaMedicos.Count == 0 && this.entidadUsadaEnForm == listaCargadaEnForm.Medico)
            {
                tlsmiArchivoExportar.Enabled = false;
                tlsmiVer.Enabled = false;
            }
        }

        #endregion

        #region EVENTOS MENUSTRIP

        /// <summary>
        /// Ejecuta el form frmMostrarLista para mostrar la lista de ateniciones de la persona seleccionada
        /// </summary>
        /// <param name="sender">emisor del evento</param>
        /// <param name="e">Información de dicho evento</param>
        private void tlsmiVerHistorialDeAtencionesDeLaPersonaSeleccionada_Click(object sender, EventArgs e)
        {

            try
            {
                frmMostrarLista mostrarAtenciones;

                if (this.entidadUsadaEnForm == listaCargadaEnForm.Paciente)
                {
                    Paciente auxPaciente = new();
                    auxPaciente = (Paciente)this.dgvLista.CurrentRow.DataBoundItem;
                    if (auxPaciente.ListaDeAtenciones is not null)
                    {
                        mostrarAtenciones = new frmMostrarLista(auxPaciente.ListaDeAtenciones);
                        mostrarAtenciones.Show();
                    }
                    else
                        MessageBox.Show("No se encontró un paciente, cree uno y vuelva a intentar", "Error al buscar pacientes", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    Medico auxMedico = new();
                    auxMedico = (Medico)this.dgvLista.CurrentRow.DataBoundItem;
                    if (auxMedico is not null)
                    {
                        mostrarAtenciones = new frmMostrarLista(auxMedico.PacientesAtendidos);
                        mostrarAtenciones.Show();
                    }
                    else
                        MessageBox.Show("No se encontró un medico, cree uno y vuelva a intentar", "Error al buscar medico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al acceder al historial de atenciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Serializa un Paciente, Medico o atención dependiendo del enum entidadUsadaEnForm
        /// </summary>
        /// <param name="sender">emisor del evento</param>
        /// <param name="e">Información de dicho evento</param>
        private void tlsmiArchivoExportar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.entidadUsadaEnForm == listaCargadaEnForm.Paciente && this.listaPaciente is not null)
                {
                    Serializador<List<Paciente>> serializadorDePaciente = new Serializador<List<Paciente>>();
                    serializadorDePaciente.EscribirPreguntandoRutaDelArhivo(this.listaPaciente);
                }
                else if (this.entidadUsadaEnForm == listaCargadaEnForm.Medico && this.listaMedicos is not null)
                {
                    Serializador<List<Medico>> serializadorDeMedico = new Serializador<List<Medico>>();
                    serializadorDeMedico.EscribirPreguntandoRutaDelArhivo(this.listaMedicos);
                }
                else
                {
                    if (this.listaAtenciones is not null)
                    {
                        Serializador<List<Atencion>> serializadorDeAtencion = new Serializador<List<Atencion>>();
                        serializadorDeAtencion.EscribirPreguntandoRutaDelArhivo(this.listaAtenciones);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al intentar exportar archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion


        #region EVENTOS DATAGRIDVIEW

        /// <summary>
        /// Evento de el DataGridView, al hacer click sobre un texto ejecuta el form frmVentanaEmergenteConInformacion para mostrar su contenido
        /// </summary>
        /// <param name="sender">emisor del evento</param>
        /// <param name="e">Información de dicho evento</param>
        private void dgvLista_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvLista is not null)
            {
                frmVentanaEmergenteConInformacion frmMuestraDelContenidoDelDataGridView = new(this.dgvLista[e.ColumnIndex, e.RowIndex].Value.ToString(), $"Mostrando información seleccionanda");
                frmMuestraDelContenidoDelDataGridView.ShowDialog();
            }
        }

        #endregion


        #region METODOS


        /// <summary>
        /// Ordena el datagridview del paciente
        /// </summary>
        private void OrdenarDataGridDePaciente()
        {
            if (this.dgvLista is not null)
            {
                this.dgvLista.Columns["IdDePaciente"].DisplayIndex = 0;
                this.dgvLista.Columns["Nombre"].DisplayIndex = 1;
                this.dgvLista.Columns["AntecedentesMedicos"].DisplayIndex = 2;
                this.dgvLista.Columns["Edad"].DisplayIndex = 3;
                this.dgvLista.Columns["Sexo"].DisplayIndex = 4;
                this.dgvLista.Columns["TratamientoEnCurso"].DisplayIndex = 5;
                this.dgvLista.Columns["Dni"].DisplayIndex = 6;
            }

        }

        /// <summary>
        /// Ordena el datagridview del medico
        /// </summary>
        private void OrdenarDataGridDeMedico()
        {
            if (this.dgvLista is not null)
            {
                this.dgvLista.Columns["IdDeMedico"].DisplayIndex = 0;
                this.dgvLista.Columns["Nombre"].DisplayIndex = 1;
                this.dgvLista.Columns["Edad"].DisplayIndex = 2;
                this.dgvLista.Columns["Sexo"].DisplayIndex = 3;
                this.dgvLista.Columns["Matricula"].DisplayIndex = 4;
            }
        }

        /// <summary>
        /// Ordena el datagridview de las atenciones
        /// </summary>
        private void OrdenarDataGridDeAtenciones()
        {
            if (this.dgvLista is not null)
            {
                this.dgvLista.Columns["IdDeAtencion"].DisplayIndex = 0;
                this.dgvLista.Columns["IdDeMedico"].DisplayIndex = 1;
                this.dgvLista.Columns["IdDePaciente"].DisplayIndex = 2;
                this.dgvLista.Columns["MotivoDeLaConsulta"].DisplayIndex = 3;
                this.dgvLista.Columns["Tratamiento"].DisplayIndex = 4;
                this.dgvLista.Columns["Diagnostico"].DisplayIndex = 5;
                this.dgvLista.Columns["FechaDeLaAtencion"].DisplayIndex = 6;
            }

        }

        #endregion


    }
}
