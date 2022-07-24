using Entidades;
using System;
using System.Windows.Forms;

namespace MenuPrincipal
{
    public partial class frmMostrarUnPaciente : Form
    {
        private Paciente pacienteMostrado;

        #region CONSTRUCTORES Y PROPIEDADES

        /// <summary>
        /// Constructor de frmMostrarUnPaciente, inicializa los controles
        /// </summary>
        public frmMostrarUnPaciente()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor de frmMostrarUnPaciente, inicializa los controles y el pacienteMostrado
        /// </summary>
        /// <param name="pacienteParaMostrar"> El paciente que se va a mostrar en el form</param>
        public frmMostrarUnPaciente(Paciente pacienteParaMostrar) : this()
        {
            this.pacienteMostrado = pacienteParaMostrar;
        }

        #endregion


        #region EVENTOS FORM

        /// <summary>
        /// Evento load del form, carga el form con los campos del Paciente
        /// </summary>
        /// <param name="sender">emisor del evento</param>
        /// <param name="e">Información de dicho evento</param>
        private void frmMostrarUnPaciente_Load(object sender, EventArgs e)
        {
            try
            {
                this.CargarControlesConPaciente();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar el paciente al form", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion


        #region EVENTOS BUTTONS

        /// <summary>
        /// Muestra los antecedentesMedicos de pacienteMostrado utilizando el form frmVentanaEmergenteConInformacion
        /// </summary>
        /// <param name="sender">emisor del evento</param>
        /// <param name="e">Información de dicho evento</param>
        private void bttnVerMasAntecedentesMedicos_Click(object sender, EventArgs e)
        {
            if (this.pacienteMostrado.AntecedentesMedicos is not null && this.pacienteMostrado is not null)
            {
                frmVentanaEmergenteConInformacion nuevaVentanaEmergente = new(this.pacienteMostrado.AntecedentesMedicos, $"Antencedentes medicos de {this.pacienteMostrado.Nombre}");
                nuevaVentanaEmergente.Show();
            }
            else
                MessageBox.Show("No hay pacientes cargados o sus datos contienen un formato incorrecto para mostrar", "Error al buscar pacientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Muestra las atencionesPrevias de pacienteMostrado utilizando el form frmMostrarLista
        /// </summary>
        /// <param name="sender">emisor del evento</param>
        /// <param name="e">Información de dicho evento</param>
        private void bttnVerMasAtencionesPrevias_Click(object sender, EventArgs e)
        {
            if (this.pacienteMostrado.ListaDeAtenciones is not null)
            {
                frmMostrarLista listaDeAtenciones = new(this.pacienteMostrado.ListaDeAtenciones);
                listaDeAtenciones.Show();
            }
            else
                MessageBox.Show("No hay pacientes cargados o  sus datos contienen un formato incorrecto para mostrar", "Error al buscar pacientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        #region METODOS

        /// <summary>
        /// Carga los controles con los campos de pacienteMostrado
        /// </summary>
        public void CargarControlesConPaciente()
        {
            if (this.pacienteMostrado is not null)
            {
                this.txtDni.Text = pacienteMostrado.Dni.ToString();
                this.txtEdad.Text = pacienteMostrado.Edad.ToString();
                this.txtId.Text = pacienteMostrado.IdDePaciente.ToString();
                this.txtNombre.Text = pacienteMostrado.Nombre;
                this.txtSexo.Text = pacienteMostrado.Sexo.ToString();
                this.txtTratamientoEnCurso.Text = pacienteMostrado.TratamientoEnCurso.ToString();
            }
            else
                MessageBox.Show("No hay pacientes cargados o  sus datos contienen un formato incorrecto para mostrar", "Error al buscar pacientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Deshabilita bttnVerMasatencionesPrevias y bttnVerMasAntecedentesMedicos, si no hay pacientes o medicos en la lista
        /// </summary>
        public void DeshabilitarBotonesSinDatos()
        {
            if (this.pacienteMostrado.ListaDeAtenciones.Count == 0)
                this.bttnVerMasAtencionesPrevias.Enabled = false;

            if (string.IsNullOrEmpty(this.pacienteMostrado.AntecedentesMedicos))
                this.bttnVerMasAntecedentesMedicos.Enabled = false;
        }

        #endregion



    }
}
