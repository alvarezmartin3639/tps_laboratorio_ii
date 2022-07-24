using Entidades;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MenuPrincipal
{
    public partial class frmNuevoPaciente : Form
    {
        private List<Paciente> nuevaListaDePacientes;
        private string antecedentesMedicos;
        private bool seCreoPaciente;

        #region CONSTRUCTORES  Y PROPIEDADES

        /// <summary>
        /// Constructor de formNuevoPaciente, inicializa la nuevaListaDePacientes
        /// </summary>
        public frmNuevoPaciente() : this(new List<Paciente>())
        {
        }

        /// <summary>
        /// Constructor de formNuevoPaciente, referencia nuevaListaDePacientes con la lista pasada por parametro
        /// </summary>
        /// <param name="listaDePacientesCompleta"> La lista completa de los pacientes del sistema</param>
        public frmNuevoPaciente(List<Paciente> listaDePacientesCompleta)
        {
            InitializeComponent();
            this.NuevaListaDePacientes = listaDePacientesCompleta;
        }

        /// <summary>
        /// Propiedad que administra el atributo nuevaListaDePacientes, contiene todos los pacientes ingresados en el sistema
        /// </summary>
        public List<Paciente> NuevaListaDePacientes { get => nuevaListaDePacientes; set => nuevaListaDePacientes = value; }

        /// <summary>
        /// Propiedad que muestra si se creo o no un nuevoPaciente
        /// </summary>
        public bool SeCreoPaciente { get => seCreoPaciente; }

        #endregion


        #region EVENTOS FORM

        /// <summary>
        /// Evento load, agrega los valores de sexoEnum al cmbSexo
        /// </summary>
        /// <param name="sender">emisor del evento</param>
        /// <param name="e">Información de dicho evento</param>
        private void FormNuevoPaciente_Load(object sender, EventArgs e)
        {
            this.cmbSexo.Items.Add(sexoEnum.Hombre.ToString());
            this.cmbSexo.Items.Add(sexoEnum.Mujer.ToString());
            this.cmbSexo.Items.Add(sexoEnum.Otro.ToString());
        }


        #endregion


        #region EVENTOS BUTTON
        /// <summary>
        /// Redacta el campo antedecentesMedicos de Paciente, utilizando el form frmVentanaEmergenteConInputBox
        /// </summary>
        /// <param name="sender">emisor del evento</param>
        /// <param name="e">Información de dicho evento</param>
        private void bttnRedactarAntecedentesMedicos_Click(object sender, EventArgs e)
        {
            frmVentanaEmergenteConInputBox redactarAntecedentes = new();
            redactarAntecedentes.ShowDialog();
            this.antecedentesMedicos = redactarAntecedentes.informacionEscrita;
        }

        /// <summary>
        /// Evento click de bttnAceptar, agrega un paciente a nuevaListaDePacientes verificando los valores
        /// </summary>
        /// <param name="sender">emisor del evento</param>
        /// <param name="e">Información de dicho evento</param>
        private void bttnAceptar_Click(object sender, EventArgs e)
        {
            this.AgregarPacienteEnLaLista();
            this.Close();
        }
        #endregion


        #region METODOS
        /// <summary>
        /// Crea un paciente utilizando los controles del form, instancia el id utilizando el tamaño de nuevaListaDePacientes
        /// </summary>
        /// <returns>un Paciente con los controles del Form</returns>
        private Paciente CrearPacienteConInformacionDelForm()
        {
            Paciente paciente = new();

            paciente.Nombre = txtNombre.Text;
            paciente.Edad = int.Parse(txtEdad.Text);
            paciente.Sexo = (sexoEnum)Enum.Parse(typeof(sexoEnum), this.cmbSexo.Text);
            paciente.AntecedentesMedicos = this.antecedentesMedicos;
            paciente.IdDePaciente = this.NuevaListaDePacientes.Count + 1;
            paciente.Dni = int.Parse(txtDni.Text);
            return paciente;
        }

        /// <summary>
        /// Verifica los datos de txtNombre, lblEdad y  cmbSexo
        /// </summary>
        private void VerificarInputsDelForm()
        {
            if (!(txtNombre.Text.All(c => char.IsLetter(c) || char.IsWhiteSpace(c))))
                throw new FormatoIncorrectoException("Nombre con formato invalido");

            if (int.TryParse(this.lblEdad.Text, out int der))
                throw new FormatoIncorrectoException("Edad con formato invalido");

            if (this.cmbSexo.Text == "Hombre" && this.cmbSexo.Text == "Mujer" && this.cmbSexo.Text == "Otro")
                throw new FormatoIncorrectoException("Sexo con formato invalido");
        }

        /// <summary>
        /// Agrega un paciente a la lista, verificando los controles del form
        /// </summary>
        private void AgregarPacienteEnLaLista()
        {
            try
            {
                this.VerificarInputsDelForm();
                this.NuevaListaDePacientes.Add(this.CrearPacienteConInformacionDelForm());
                MessageBox.Show("Se creo el paciente con exito!", "Paciente creado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.seCreoPaciente = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al crear paciente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion


    }
}
