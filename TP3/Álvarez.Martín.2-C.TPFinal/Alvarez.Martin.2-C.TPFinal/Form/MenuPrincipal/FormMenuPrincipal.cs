using Entidades;
using GestorArchivos;
using MostrarLista;
using MostrarUnPaciente;
using NuevaAtencion;
using NuevoPaciente;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VentanaEmergenteConInputBoxSimple;

namespace MenuPrincipal
{
    public partial class FormMenuPrincipal : Form
    {
        private List<Paciente> listaPacientesSeleccionados;
        private List<Medico> listaMedicosSeleccionados;
        private List<Atencion> listaAtencionesSeleccionadas;
        private Medico medicoLogeado;


        #region CONSTRUCTORES Y PROPIEDADES

        /// <summary>
        /// Constructor del frmMenuPrincipal, instancia listaMedicosSeleccionados, listaDepacientesSeleccionados, ListaDeAtencionesSeleccionadas y medicoLogeado.
        /// </summary>
        public FormMenuPrincipal()
        {
            InitializeComponent();
            this.listaMedicosSeleccionados = new();
            this.listaPacientesSeleccionados = new();
            this.listaAtencionesSeleccionadas = new();
            this.medicoLogeado = new();
        }

        #endregion


        #region EVENTOS FORM

        /// <summary>
        /// Evento load del form, deshabilita los menuStrip dependiendo si la lista de  Paciente, Medico y Atenciones está vacia
        /// </summary>
        /// <param name="sender">emisor del evento</param>
        /// <param name="e">Información de dicho evento</param>
        private void FormMenuPrincipal_Load(object sender, EventArgs e)
        {
            this.HarcodeoMedicos();
            this.harcodeoPaciente();
            this.harcodeoAtenciones();

            this.DeshabilitarMenuStripSiLaListaEstaVacia();
        }

        /// <summary>
        /// Evento FormClosing del form, pregunta si se desea salir y el usuario lo desea se sale del form
        /// </summary>
        /// <param name="sender">emisor del evento</param>
        /// <param name="e">Información de dicho evento</param>
        private void FormMenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea salir?, todos los datos no guardados se perderán.", "Está apunto de salir del programa...", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                e.Cancel = true;
        }

        #endregion


        #region EVENTOS MENUSTRIP

        /// <summary>
        /// Se ejecuta el form frmNuevoPaciente para agregar un nuevo paciente a la lista
        /// </summary>
        /// <param name="sender">emisor del evento</param>
        /// <param name="e">Información de dicho evento</param>
        private void tlsmiPacienteAgregar_Click(object sender, EventArgs e)
        {
            frmNuevoPaciente agregarPaciente = new frmNuevoPaciente(listaPacientesSeleccionados);
            agregarPaciente.ShowDialog();
            this.listaPacientesSeleccionados = agregarPaciente.NuevaListaDePacientes;
        }

        /// <summary>
        /// Se ejecuta el form frmMostrarLista para mostrar la lista de pacientes
        /// </summary>
        /// <param name="sender">emisor del evento</param>
        /// <param name="e">Información de dicho evento</param>
        private void tlsmiPacienteMostrarLista_Click(object sender, EventArgs e)
        {
            frmMostrarLista mostrarListaPacientes = new frmMostrarLista(this.listaPacientesSeleccionados);
            mostrarListaPacientes.Show();
        }

        /// <summary>
        /// Se ejecuta el form frmNuevaAtencion para generar una nueva atención médica
        /// </summary>
        /// <param name="sender">emisor del evento</param>
        /// <param name="e">Información de dicho evento</param>
        private void tlsmiNuevaAtencion_Click(object sender, EventArgs e)
        {
            frmNuevaAtencion nuevaAtencion = new(this.listaMedicosSeleccionados, this.listaPacientesSeleccionados);
            nuevaAtencion.Show();
            this.listaPacientesSeleccionados = nuevaAtencion.ListaDePacientesNueva;
        }

        /// <summary>
        /// Se busca un paciente por id mediante frmVentanaEmergenteConInputBoxSimple y el metodo Paciente.BuscarPacienteEnLaListaMedianteId, luego se lo muestra en el form frmMostrarUnPaciente
        /// </summary>
        /// <param name="sender">emisor del evento</param>
        /// <param name="e">Información de dicho evento</param>
        private void tlsmiBuscarPacientePorId_Click(object sender, EventArgs e)
        {
            try
            {
                frmVentanaEmergenteConInputBoxSimple frmPidiendoId;
                frmMostrarUnPaciente frmMostrandoAlPaciente;
                Paciente auxPaciente;
                int idPedido;

                frmPidiendoId = new frmVentanaEmergenteConInputBoxSimple("Buscar paciente por id", "Ingrese el id del paciente:");
                frmPidiendoId.ShowDialog();
                idPedido = int.Parse(frmPidiendoId.InformacionEscrita);
                auxPaciente = Paciente.BuscarPacienteEnListaMedianteId(idPedido, this.listaPacientesSeleccionados);

                if (auxPaciente is not null)
                {
                    frmMostrandoAlPaciente = new(auxPaciente);
                    frmMostrandoAlPaciente.ShowDialog();
                }
                else
                    MessageBox.Show("No se encontró paciente en la lista", "Error al buscar el paciente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al intentar buscar paciente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Se serializa el campo listaPacientesSeleccionados, preguntando la ruta donde está el archivo
        /// </summary>
        /// <param name="sender">emisor del evento</param>
        /// <param name="e">Información de dicho evento</param>
        private void tlsmiArchivoImportarPacientes_Click(object sender, EventArgs e)
        {
            try
            {
                Serializador<List<Paciente>> serializadorDePaciente = new Serializador<List<Paciente>>();
                this.listaPacientesSeleccionados = serializadorDePaciente.LeerPreguntandoRutaDelArhivo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al intentar importar paciente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Se serializa el campo listaPacientesSeleccionados, preguntando la ruta donde se guardará el archivo
        /// </summary>
        /// <param name="sender">emisor del evento</param>
        /// <param name="e">Información de dicho evento</param>
        private void tlsmiArchivoExportarPacientes_Click(object sender, EventArgs e)
        {
            try
            {
                Serializador<List<Paciente>> serializadorDePaciente = new Serializador<List<Paciente>>();
                serializadorDePaciente.EscribirPreguntandoRutaDelArhivo(this.listaPacientesSeleccionados);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al intentar exportar paciente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Se serializa el campo listaMedicoSeleccionados, preguntando la ruta donde está el archivo
        /// </summary>
        /// <param name="sender">emisor del evento</param>
        /// <param name="e">Información de dicho evento</param>
        private void tlsmiArchivoImportarMedicos_Click(object sender, EventArgs e)
        {
            try
            {
                Serializador<List<Medico>> serializadorDeMedico = new Serializador<List<Medico>>();
                this.listaMedicosSeleccionados = serializadorDeMedico.LeerPreguntandoRutaDelArhivo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al intentar importar medico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Se serializa el campo listaMedicoSeleccionados, preguntando la ruta donde se guardará el archivo
        /// </summary>
        /// <param name="sender">emisor del evento</param>
        /// <param name="e">Información de dicho evento</param>
        private void tlsmiArchivoExportarMedicos_Click(object sender, EventArgs e)
        {
            try
            {
                Serializador<List<Medico>> serializadorDeMedico = new Serializador<List<Medico>>();

                serializadorDeMedico.EscribirPreguntandoRutaDelArhivo(this.listaMedicosSeleccionados);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al intentar exportar medico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        ///  Se ejecuta el form frmMostrarLista para mostrar la lista de todos los médicos
        /// </summary>
        /// <param name="sender">emisor del evento</param>
        /// <param name="e">Información de dicho evento</param>
        private void tlsmiMostrarTodosLosMedicos_Click(object sender, EventArgs e)
        {
            frmMostrarLista mostrarListaDeMedicos = new frmMostrarLista(this.listaMedicosSeleccionados);
            mostrarListaDeMedicos.ShowDialog();
        }

        #endregion
      
    
        #region METODOS
   
        /// <summary>
        /// Deshabilita los MenuStrips dependiendo si al lista de pacientes y médicos está vacia
        /// </summary>
        private void DeshabilitarMenuStripSiLaListaEstaVacia()
        {
            if (this.listaPacientesSeleccionados.Count == 0)
            {
                tlsmPaciente.Enabled = false;
                tlsmiNuevaAtencion.Enabled = false;
            }
            if (this.listaMedicosSeleccionados.Count == 0)
            {
                this.tlsmMedico.Enabled = false;
                tlsmiNuevaAtencion.Enabled = false;
            }
        }

        /// <summary>
        /// Harcodea Médicos para una correción mas rápida del TP
        /// </summary>
        public void HarcodeoMedicos()
        {
            List<Atencion> listaAtencionUna = new();
            List<Atencion> listaAtencionDos = new();
            List<Atencion> listaAtencionTres = new();

            listaAtencionUna.Add(new Atencion(1, 1, 1, "Bulto en el abdomen", "En observación", "Esperando resultados de los analisis", DateTime.Now));
            listaAtencionUna.Add(new Atencion(2, 1, 1, "Trajo los resultados del analasis", "Medicamento xxx", "Cancer", DateTime.Now));
            listaAtencionDos.Add(new Atencion(3, 2, 2, "Dolor de cabeza", "Medicamento yyy", "Esperando resultados de los analisis", DateTime.Now));
            listaAtencionTres.Add(new Atencion(4, 3, 3, "Fatiga ", "Vitaminas aaa", "falta de vitamina", DateTime.Now));

            Medico medicoUno = new(363434343,30, "Álvarez Martín Andrés", sexoEnum.Hombre, 1, "admin",23232, listaAtencionUna);
            Medico medicoDOs = new(232323211, 34, "Roberto de la fuente", sexoEnum.Hombre, 2, "perro", 4242, listaAtencionDos);
            Medico medicoTres = new(6666666, 35, "Julia Lopez", sexoEnum.Hombre, 3, "gato", 1212, listaAtencionTres);

            this.listaMedicosSeleccionados.Add(medicoUno);
            this.listaMedicosSeleccionados.Add(medicoDOs);
            this.listaMedicosSeleccionados.Add(medicoTres);
        }

        /// <summary>
        /// Harcodea Pacientes para una correción mas rápida del TP
        /// </summary>
        public void harcodeoPaciente()
        {
            List<Atencion> listaAtencionUna = new();
            List<Atencion> listaAtencionDos = new();
            List<Atencion> listaAtencionTres = new();

            listaAtencionUna.Add(new Atencion(1, 1, 1, "Bulto en el abdomen", "En observación", "Esperando resultados de los analisis", DateTime.Now));
            listaAtencionUna.Add(new Atencion(2, 1, 1, "Trajo los resultados del analasis", "Medicamento xxx", "Cancer", DateTime.Now));
            listaAtencionDos.Add(new Atencion(3, 2, 2, "Dolor de cabeza", "Medicamento yyy", "Esperando resultados de los analisis", DateTime.Now));
            listaAtencionTres.Add(new Atencion(4, 3, 3, "Fatiga ", "Vitaminas aaa", "falta de vitamina", DateTime.Now));

            this.listaPacientesSeleccionados.Add(new Paciente(34345234, 22, "Roberto juan", sexoEnum.Hombre,1, listaAtencionUna, false, "Nignuno"));
            this.listaPacientesSeleccionados.Add(new Paciente(222222, 11, "Perez juan", sexoEnum.Hombre, 2, listaAtencionDos, false, "Nignuno"));
            this.listaPacientesSeleccionados.Add(new Paciente(44444, 33, "Retrererere juan", sexoEnum.Hombre, 3, listaAtencionTres, false, "Nignuno"));
        }

        /// <summary>
        /// Harcodea Atenicones para una correción mas rápida del TP
        /// </summary>
        public void harcodeoAtenciones()
        {
            this.listaAtencionesSeleccionadas.Add(new Atencion(1, 1, 1, "Bulto en el abdomen", "En observación", "Esperando resultados de los analisis", DateTime.Now));
            this.listaAtencionesSeleccionadas.Add(new Atencion(2, 1, 1, "Trajo los resultados del analasis", "Medicamento xxx", "Cancer", DateTime.Now));
            this.listaAtencionesSeleccionadas.Add(new Atencion(3, 2, 2, "Dolor de cabeza", "Medicamento yyy", "Esperando resultados de los analisis", DateTime.Now));
            this.listaAtencionesSeleccionadas.Add(new Atencion(4, 3, 3, "Fatiga ", "Vitaminas aaa", "falta de vitamina", DateTime.Now));
        }

        #endregion


    }
}
