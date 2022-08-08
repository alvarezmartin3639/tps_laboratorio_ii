using Entidades;
using Extension;
using GestorArchivos;
using GestorSql;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
namespace MenuPrincipal
{
    public partial class FormMenuPrincipal : Form
    {
        private List<Paciente> listaPacientesSeleccionados;
        private List<Medico> listaMedicosSeleccionados;
        private List<Atencion> listaAtencionesSeleccionadas;
        private List<TurnoMedico> listaTurnosMedicosSeleccionados;
        private List<TurnoMedico> listaTurnosRestanesDeHoy;
        private Paciente pacienteAtendido;
        private Medico medicoLogeado;
        public bool estaLogeadoElMedico;
        private bool estadoActualDelServidorSql;
        private bool estadoAnteriorDelServidorSql;
        public delegate void ComprobadorConexionSqlHandler();
        public event ComprobadorConexionSqlHandler OnCambioEnElEstadoDelServidorSql;
        private Thread threadVerificarConexionSql;
        private CancellationTokenSource cancellationToken;
        private string strConexionSql;

        #region CONSTRUCTORES Y PROPIEDADES

        /// <summary>
        /// Constructor del frmMenuPrincipal, instancia listaMedicosSeleccionados, listaDepacientesSeleccionados, ListaDeAtencionesSeleccionadas y medicoLogeado.
        /// </summary>
        public FormMenuPrincipal()
        {
            InitializeComponent();
            this.grbSqlError.Hide();

            this.listaMedicosSeleccionados = new();
            this.listaPacientesSeleccionados = new();
            this.listaAtencionesSeleccionadas = new();
            this.listaTurnosMedicosSeleccionados = new();
            this.listaTurnosRestanesDeHoy = new();
            this.estadoActualDelServidorSql = MisComandosSql.VerificarConexionConSql("Server = .\\sqlexpress ; Database = TP4_AlvarezMartinAndres_DB; Trusted_Connection = true ;");
            this.estadoAnteriorDelServidorSql = !this.estadoActualDelServidorSql;
            this.tlsmiArchivo.Available = false;
            this.cancellationToken = new();
            this.lblErrorSql.Text = "No se puede conectar con el servidor SQL, abra un ticket o trabaje de manera \n offline hasta que se solucione \nTrabaje de manera offline utilizando archivos, al terminar envielos a x@soporte.com";
            this.strConexionSql = "Server = .\\sqlexpress ; Database = TP4_AlvarezMartinAndres_DB; Trusted_Connection = true ;";
            this.estaLogeadoElMedico = false;
            txtNombrePaciente.ReadOnly = true;

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
            this.HarcodeoAtenciones();
            this.HarcodeoPaciente();
            this.HarcodeoMedicos();
            this.HarcodeoTurnosMedicos();
            this.OnCambioEnElEstadoDelServidorSql += this.c_CambiarControlesFormDependiendoEstadoDeConexion;
            this.threadVerificarConexionSql = new Thread(() => ComprobarEstadoDelServidor());
            threadVerificarConexionSql.Start();


        }

        /// <summary>
        /// Evento FormClosing del form, pregunta si se desea salir y el usuario lo desea se sale del form
        /// </summary>
        /// <param name="sender">emisor del evento</paramB
        /// <param name="e">Información de dicho evento</param>
        private void FormMenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea salir?, todos los datos no guardados se perderán.", "Está apunto de salir del programa...", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                e.Cancel = true;
                this.cancellationToken.Cancel();
            }
        }


        /// <summary>
        /// Muestra la información del paciente que está siendo atendido
        /// </summary>
        /// <param name="sender">emisor del evento</param>
        /// <param name="e">Información de dicho evento</param>
        private void bttnVerInformacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (pacienteAtendido is not null && this.listaTurnosRestanesDeHoy.Count > 0)
                {
                    frmMostrarUnPaciente frmMostrandoAlPaciente;
                    frmMostrandoAlPaciente = new(pacienteAtendido);
                    frmMostrandoAlPaciente.ShowDialog();
                }
                else
                    MessageBox.Show("No se encontró paciente", "Error al buscar el paciente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al intentar mostrar paciente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Comieza la atención del paciente atendido y si se atiende correctamente lo elimina de la listaDeTurnosPedientes
        /// </summary>
        /// <param name="sender">emisor del evento</param>
        /// <param name="e">Información de dicho evento</param>
        private void bttnComenzarAtencion_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.listaMedicosSeleccionados is not null && this.listaAtencionesSeleccionadas is not null && this.estaLogeadoElMedico == true && this.listaTurnosRestanesDeHoy.Count > 0)
                {
                    frmNuevaAtencion nuevaAtencion = new(this.listaMedicosSeleccionados, this.listaPacientesSeleccionados, this.listaAtencionesSeleccionadas, medicoLogeado.IdDeMedico, pacienteAtendido.IdDePaciente);
                    nuevaAtencion.ShowDialog();
                    this.listaPacientesSeleccionados = nuevaAtencion.ListaDePacientesNueva;
                    this.listaAtencionesSeleccionadas = nuevaAtencion.ListaDeAtencionNueva;
                    this.listaMedicosSeleccionados = nuevaAtencion.ListaDeMedicosNueva;

                    //SI SE GENERÓ LA ATENCION
                    if (nuevaAtencion.SePudoCrearAtencion == true)
                    {
                        //CAMBIO EL ESTADO DE LA ATENCION DEL TURNO A COMPLETADO
                        this.listaTurnosMedicosSeleccionados.First(turno => turno.IdDeTurnoMedico == listaTurnosRestanesDeHoy[0].IdDeTurnoMedico).SeRealizoAtencionDelTurno = true;
                        //ELIMINO EL TURNO DE LOS PENDIENTES DE HOY
                        this.listaTurnosRestanesDeHoy.RemoveAt(0);
                        //CARGO EL SIGUIENTE PACIENTE PARA SER ATENDIDO
                        if (this.listaTurnosRestanesDeHoy.Count > 0)
                        {
                            int idDelSiguientePaciente = this.listaTurnosRestanesDeHoy.First().IdDePaciente;
                            Paciente auxPaciente;
                            auxPaciente = this.listaPacientesSeleccionados.First(paciente => paciente.IdDePaciente == idDelSiguientePaciente);
                            if (auxPaciente is not null)
                                this.pacienteAtendido = auxPaciente;
                            this.txtNombrePaciente.Text = this.pacienteAtendido.Nombre;

                        }
                        else
                        {
                            this.txtNombrePaciente.Text = "Sin pacientes";
                            this.txtNombrePaciente.Enabled = false;
                            this.bttnVerInformacion.Enabled = false;
                            this.bttnComenzarAtencion.Enabled = false;
                            this.bttnVerTurnosRestantes.Enabled = false;

                        }
                    }

                }
                else
                    MessageBox.Show("No hay pacientes o medicos cargados en la lista", "Error al buscar medico o paciente", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al intentar generar una nueva atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Permite logearse a un medico
        /// </summary>
        /// <param name="sender">emisor del evento</param>
        /// <param name="e">Información de dicho evento</param>
        private void bttnIngresarIdMedico_Click(object sender, EventArgs e)
        {
            try
            {
                this.LogeadMedico();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al intentar mostrar la atención proxima", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        /// <summary>
        /// Permite a un medico ver los turnos que falta completar en el dia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bttnVerTurnosRestantes_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.listaTurnosRestanesDeHoy is not null && this.listaTurnosRestanesDeHoy.Count > 0)
                {
                    frmMostrarLista mostrarTodosLosTurnosMedicos = new(this.listaTurnosRestanesDeHoy);
                    mostrarTodosLosTurnosMedicos.ShowDialog();
                }
                else
                    MessageBox.Show("No se encuentran mas turnos disponibles para la atención", "No hay mas turnos que requieran atención...", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al intentar mostrar los turnos medicos de hoy", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            try
            {
                if (this.listaPacientesSeleccionados is not null)
                {
                    frmNuevoPaciente agregarPaciente = new frmNuevoPaciente(listaPacientesSeleccionados);
                    agregarPaciente.ShowDialog();
                    if (agregarPaciente.NuevaListaDePacientes is not null)
                        this.listaPacientesSeleccionados = agregarPaciente.NuevaListaDePacientes;
                }
                else
                    MessageBox.Show("No hay pacientes cargados en la lista", "Error al buscar pacientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al intentar agregar pacientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Se ejecuta el form frmMostrarLista para mostrar la lista de pacientes
        /// </summary>
        /// <param name="sender">emisor del evento</param>
        /// <param name="e">Información de dicho evento</param>
        private void tlsmiPacienteMostrarLista_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.listaPacientesSeleccionados is not null)
                {
                    frmMostrarLista mostrarListaPacientes = new frmMostrarLista(this.listaPacientesSeleccionados);
                    mostrarListaPacientes.Show();
                }
                else
                    MessageBox.Show("No hay pacientes cargados en la lista", "Error al buscar  pacientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al intentar mostrar los pacientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Muestra todos los pacientes de un medico mediante su id
        /// </summary>
        /// <param name="sender">emisor del evento</param>
        /// <param name="e">Información de dicho evento</param>
        private void tlsmiMostrarTodosMisPacientes_Click(object sender, EventArgs e)
        {
            try
            {
                frmVentanaEmergenteConInputBoxSimple frmPidiendoId;
                int idDeMedico;
                List<Paciente> listaDeMisPacientes = new();
                frmPidiendoId = new frmVentanaEmergenteConInputBoxSimple("Buscar pacientes del medico con Id...", "Ingrese su Id de medico:");
                frmPidiendoId.ShowDialog();

                idDeMedico = int.Parse(frmPidiendoId.InformacionEscrita);
                //RECORRO LOS PACIENTES DEL SISTEMA
                foreach (Paciente pacientesTotales in this.listaPacientesSeleccionados)
                {
                    //RECORRO LAS ATENCIONES DE UN PACIENTE
                    foreach (Atencion atencionDelPaciente in pacientesTotales.ListaDeAtenciones)
                    {
                        //VERIFICO QUE EL ID DEL MEDICO QUE LO ATENDIO SEA EL ID DEL MEDICO ELEGIDO Y QUE NO EXISTA EN LA LISTA
                        if (atencionDelPaciente.IdDeMedico == idDeMedico && listaDeMisPacientes.Any(p => p.IdDePaciente == atencionDelPaciente.IdDePaciente) == false)
                        {
                            listaDeMisPacientes.Add(Paciente.BuscarPacienteEnListaMedianteId(atencionDelPaciente.IdDePaciente, this.listaPacientesSeleccionados));
                        }

                    }
                }

                frmMostrarLista mostrarListaPacientes = new frmMostrarLista(listaDeMisPacientes);
                mostrarListaPacientes.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al intentar mostrar los pacientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Se ejecuta el form frmNuevaAtencion para generar una nueva atención médica
        /// </summary>
        /// <param name="sender">emisor del evento</param>
        /// <param name="e">Información de dicho evento</param>
        private void tlsmiNuevaAtencion_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.listaMedicosSeleccionados is not null && this.listaAtencionesSeleccionadas is not null)
                {
                    frmNuevaAtencion nuevaAtencion = new(this.listaMedicosSeleccionados, this.listaPacientesSeleccionados, this.listaAtencionesSeleccionadas);
                    nuevaAtencion.ShowDialog();
                    this.listaPacientesSeleccionados = nuevaAtencion.ListaDePacientesNueva;
                    this.listaAtencionesSeleccionadas = nuevaAtencion.ListaDeAtencionNueva;
                    this.listaMedicosSeleccionados = nuevaAtencion.ListaDeMedicosNueva;
                }
                else
                    MessageBox.Show("No hay pacientes o medicos cargados en la lista", "Error al buscar medico o paciente", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al intentar generar una nueva atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Muestra las atenciones de los pacientes abriendo una instancia de frmMostrarLista de forma modal
        /// </summary>
        /// <param name="sender">emisor del evento</param>
        /// <param name="e">Información de dicho evento</param>
        private void tlsmiMostrarAtencionesDePaciente_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.listaPacientesSeleccionados is not null)
                {
                    Paciente auxPaciente = this.BuscarPacientePorId();

                    if (auxPaciente is not null)
                    {
                        if (auxPaciente.ListaDeAtenciones.Count is 0)
                            MessageBox.Show("El paciente nunca se atendió", "No se pudo encontrar atenciones", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        frmMostrarLista frmMostrandoAtencionesDelPaciente;
                        frmMostrandoAtencionesDelPaciente = new(auxPaciente.ListaDeAtenciones);
                        frmMostrandoAtencionesDelPaciente.ShowDialog();
                    }
                    else
                        MessageBox.Show("No se encontró paciente", "Error al buscar el paciente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al intentar mostrar anteciones del paciente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Se busca un medico por id mediante frmVentanaEmergenteConInputBoxSimple y el metodo Medico.BuscarPacienteEnLaListaMedianteId, luego se lo muestra en el form frmMostrarLista
        /// </summary>
        /// <param name="sender">emisor del evento</param>
        /// <param name="e">Información de dicho evento</param>
        private void tlsmiMostrarAtencionesDeMedico_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.listaMedicosSeleccionados is not null)
                {
                    Medico auxMedico = this.BuscarMedicoPorId();

                    if (auxMedico is not null)
                    {
                        if (auxMedico.PacientesAtendidos.Count is 0)
                            MessageBox.Show("El medico nunca atendió a un paciente", "No se pudo encontrar atenciones", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        frmMostrarLista frmMostrandoAtencionesDelMedico;
                        frmMostrandoAtencionesDelMedico = new(auxMedico.PacientesAtendidos);
                        frmMostrandoAtencionesDelMedico.ShowDialog();
                    }
                    else
                        MessageBox.Show("No se encontró medico", "Error al buscar el medico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al intentar mostrar anteciones del medico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Se muestra todas las atenciones cargadas en el sistema, tanto de medico como de pacientes, eliminando las repetidas.
        /// </summary>
        /// <param name="sender">emisor del evento</param>
        /// <param name="e">Información de dicho evento</param>
        private void tlsmiMostrarTodasLasAtenciones_Click(object sender, EventArgs e)
        {
            try
            {
                // List<Atencion> auxAtencion = this.generarListaAtencionDePacientesYMedicos();
                if (this.listaAtencionesSeleccionadas is not null)
                {
                    frmMostrarLista mostrarTodasLasAtenciones = new(this.listaAtencionesSeleccionadas);
                    mostrarTodasLasAtenciones.ShowDialog();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al intentar mostrar todas las atenciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Se busca un paciente por id mediante frmVentanaEmergenteConInputBoxSimple y el metodo Paciente.BuscarPacienteEnLaListaMedianteId, luego se lo muestra en el form frmMostrarLista
        /// </summary>
        /// <param name="sender">emisor del evento</param>
        /// <param name="e">Información de dicho evento</param>
        private void tlsmiBuscarPacientePorId_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.listaPacientesSeleccionados is not null)
                {
                    Paciente auxPaciente = this.BuscarPacientePorId();

                    if (auxPaciente is not null)
                    {
                        frmMostrarUnPaciente frmMostrandoAlPaciente;
                        frmMostrandoAlPaciente = new(auxPaciente);
                        frmMostrandoAlPaciente.ShowDialog();
                    }
                    else
                        MessageBox.Show("No se encontró paciente en la lista", "Error al buscar el paciente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("No hay pacientes cargados en la lista", "Error al buscar  pacientes", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                List<Paciente> auxListaPacientes = new();
                Serializador<List<Paciente>> serializadorDePaciente = new Serializador<List<Paciente>>();
                auxListaPacientes = serializadorDePaciente.LeerPreguntandoRutaDelArhivo();

                if (auxListaPacientes is not null && auxListaPacientes[0].IdDePaciente is not 0)
                    this.listaPacientesSeleccionados = auxListaPacientes;
                else
                    MessageBox.Show("Los datos cargados no coinciden con un paciente", "Error importar paciente", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (this.listaPacientesSeleccionados is not null)
                {

                    Serializador<List<Paciente>> serializadorDePaciente = new Serializador<List<Paciente>>();
                    serializadorDePaciente.EscribirJsonPreguntandoRuta(this.listaPacientesSeleccionados);
                }
                else
                    MessageBox.Show("No hay pacientes en la lista", "Error exportar paciente", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                List<Medico> auxListaMedicos = new();
                Serializador<List<Medico>> serializadorDeMedico = new Serializador<List<Medico>>();

                auxListaMedicos = serializadorDeMedico.LeerPreguntandoRutaDelArhivo();

                if (auxListaMedicos is not null && auxListaMedicos[0].Matricula is not 0 && auxListaMedicos[0].IdDeMedico is not 0)
                    this.listaMedicosSeleccionados = auxListaMedicos;
                else
                    MessageBox.Show("Los datos cargados no coinciden con un medico", "Error importar medico", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (this.listaMedicosSeleccionados is not null)
                {
                    Serializador<List<Medico>> serializadorDeMedico = new Serializador<List<Medico>>();
                    serializadorDeMedico.EscribirJsonPreguntandoRuta(this.listaMedicosSeleccionados);
                }
                else
                    MessageBox.Show("Los datos cargados no coinciden con un medico", "Error exportar medico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al intentar exportar medico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Se serializa el campo listaAtencionesSeleccionados, preguntando la ruta donde está el archivo
        /// </summary>
        /// <param name="sender">emisor del evento</param>
        /// <param name="e">Información de dicho evento</param>
        private void tlsmiArchivoImportarAtenciones_Click(object sender, EventArgs e)
        {
            try
            {
                List<Atencion> auxListaAtencion = new();
                Serializador<List<Atencion>> serializadorDeAtencion = new Serializador<List<Atencion>>();
                auxListaAtencion = serializadorDeAtencion.LeerPreguntandoRutaDelArhivo();

                if (auxListaAtencion is not null)
                    this.listaAtencionesSeleccionadas = auxListaAtencion;
                else
                    MessageBox.Show("Los datos cargados no coinciden con una Atencion", "Error importar Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al intentar importar Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Se serializa el campo listaTurnosMedicosSeleccionados, preguntando la ruta donde está el archivo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tlsmiArchivoImportarTurnosMedicos_Click(object sender, EventArgs e)
        {
            try
            {
                List<TurnoMedico> auxListaTurnoMedico = new();
                Serializador<List<TurnoMedico>> serializadorDeTurnoMedico = new Serializador<List<TurnoMedico>>();
                auxListaTurnoMedico = serializadorDeTurnoMedico.LeerPreguntandoRutaDelArhivo();

                if (auxListaTurnoMedico is not null)
                    this.listaTurnosMedicosSeleccionados = auxListaTurnoMedico;
                else
                    MessageBox.Show("Los datos cargados no coinciden con un Turno Medico", "Error importar Turno Medico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al intentar importar Turnos Medicos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Se Deserializa el campo listaAtencionesSeleccionados, preguntando la ruta donde se guardará el archivo
        /// </summary>
        /// <param name="sender">emisor del evento</param>
        /// <param name="e">Información de dicho evento</param>
        private void tlsmiArchivoExportarAtenciones_Click(object sender, EventArgs e)
        {
            try
            {
                if (listaAtencionesSeleccionadas is not null)
                {

                    Serializador<List<Atencion>> serializadorDeAtencion = new Serializador<List<Atencion>>();
                    serializadorDeAtencion.EscribirJsonPreguntandoRuta(this.listaAtencionesSeleccionadas);
                }
                else
                    MessageBox.Show("Los datos cargados no coinciden con una Atención", "Error exportar Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al exportar Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        ///  Se ejecuta el form frmMostrarLista para mostrar la lista de todos los médicos
        /// </summary>
        /// <param name="sender">emisor del evento</param>
        /// <param name="e">Información de dicho evento</param>
        private void tlsmiMostrarTodosLosMedicos_Click(object sender, EventArgs e)
        {
            try
            {
                if (listaMedicosSeleccionados is not null)
                {
                    frmMostrarLista mostrarListaDeMedicos = new frmMostrarLista(this.listaMedicosSeleccionados);
                    mostrarListaDeMedicos.ShowDialog();
                }
                else
                    MessageBox.Show("No hay medicos en la lista", "Error al  mostrar medicos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al mostrar medicos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        /// <summary>
        /// Importa toda la información de las tablas Atencio, Paciente y Medico
        /// </summary>
        /// <param name="sender">emisor del evento</param>
        /// <param name="e">Información de dicho evento</param>
        private void tlsmiImportarSQL_Click(object sender, EventArgs e)
        {
            if (this.estadoActualDelServidorSql == false)
            {
                MessageBox.Show("No se puede importar información porque no existe una conexión con el servidor SQL", "No se pudo conectar al servidor...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("¿Está seguro que desea importar los datos de SQL?, al importarse se perderá todos los datos actuales", "Conectando al servidor SQL...", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        PacienteSql nuevoPaciente = new(strConexionSql);
                        AtencionSql nuevaAtencion = new(strConexionSql);
                        MedicoSql nuevoMedico = new(strConexionSql);
                        TurnoMedicoSql nuevoTurno = new(strConexionSql);

                        // INCIALIZO LAS LISTAS CON LOS DATOS SQL
                        this.listaPacientesSeleccionados = nuevoPaciente.Leer();
                        this.listaMedicosSeleccionados = nuevoMedico.Leer();
                        this.listaAtencionesSeleccionadas = nuevaAtencion.Leer();
                        this.listaTurnosMedicosSeleccionados = nuevoTurno.Leer();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error al utilizar base de datos SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        /// <summary>
        /// Exporta toda la información de listaAtencionesSeleccionadas, listaPersonasSeleccionadas y listaMedicosSeleccionados a la data base TP4_AlvarezMartinAndres_DB
        /// </summary>
        /// <param name="sender">emisor del evento</param>
        /// <param name="e">Información de dicho evento</param>
        private void tlsmiExportarSQL_Click(object sender, EventArgs e)
        {
            if (this.estadoActualDelServidorSql == false)
            {
                MessageBox.Show("No se puede exportar información porque no existe una conexión con el servidor SQL", "No se pudo conectar al servidor...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                if (MessageBox.Show("¿Está seguro que exportar las listas a SQL?, verifique que toda la información esté correcta", "Guardando listas en el servidor SQL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        PacienteSql nuevoPaciente = new(strConexionSql);
                        AtencionSql nuevaAtencion = new(strConexionSql);
                        MedicoSql nuevoMedico = new(strConexionSql);
                        TurnoMedicoSql nuevoTurnoMedico = new(strConexionSql);

                        foreach (Paciente item in this.listaPacientesSeleccionados)
                            nuevoPaciente.Agregar(item);
                        foreach (Atencion item in this.listaAtencionesSeleccionadas)
                            nuevaAtencion.Agregar(item);
                        foreach (Medico item in this.listaMedicosSeleccionados)
                            nuevoMedico.Agregar(item);
                        foreach (TurnoMedico item in this.listaTurnosMedicosSeleccionados)
                            nuevoTurnoMedico.ModificarTurnoCompletado(item);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error al utilizar base de datos SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        #endregion


        #region METODOS

        /// <summary>
        /// Serializa la listaAtencionesSeleccionadas, listaPacientesSeleccionados, listaMedicosSeleccionados en la carpeta BackUp del ejecutable.
        /// </summary>
        public void CrearBackUpDeDatos()
        {
            try
            {
                if (this.listaAtencionesSeleccionadas.Count > 0)
                {
                    Serializador<List<Atencion>> serializadorAtencion = new();
                    serializadorAtencion.Escribir(listaAtencionesSeleccionadas, $"{Application.StartupPath}\\Backup\\Atenciones.xml");
                }
                if (this.listaPacientesSeleccionados.Count > 0)
                {
                    Serializador<List<Paciente>> serializadorPaciente = new();
                    serializadorPaciente.Escribir(listaPacientesSeleccionados, $"{Application.StartupPath}\\Backup\\Pacientes.xml");
                }
                if (this.listaMedicosSeleccionados.Count > 0)
                {

                    Serializador<List<Medico>> serializadorMedico = new();
                    serializadorMedico.Escribir(listaMedicosSeleccionados, $"{Application.StartupPath}\\Backup\\Medicos.xml");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al serializar Backup", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Modifica el form dependiendo del estado del servidor, si el servidor está offline se habilitan los archivos y muestra un groupbox notificando el error
        /// </summary>
        public void c_CambiarControlesFormDependiendoEstadoDeConexion()
        {
            try
            {
                if (this.txtConexionSql.InvokeRequired)
                {
                    ComprobadorConexionSqlHandler del = new ComprobadorConexionSqlHandler(this.c_CambiarControlesFormDependiendoEstadoDeConexion);
                    if (this.threadVerificarConexionSql != null)
                        this.txtConexionSql.Invoke(del);
                }
                else
                {
                    if (this.estadoActualDelServidorSql == true)
                    {
                        grbSqlError.Hide();
                        this.grpProximaAtencion.Show();
                        this.tlsmiArchivo.Available = false;
                        this.estadoAnteriorDelServidorSql = this.estadoActualDelServidorSql;

                    }
                    if (this.estadoActualDelServidorSql == false)
                    {
                        grbSqlError.Show();
                        this.grpProximaAtencion.Hide();
                        this.tlsmiArchivo.Available = true;
                        this.estadoAnteriorDelServidorSql = this.estadoActualDelServidorSql;
                        this.CrearBackUpDeDatos();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Manejador del evento OnCambioEnElEstadoDelServidorSql, verifica cada 3 segundos que exista conexión con la data base TP4_AlvarezMartinAndres_DB
        /// </summary>
        public void ComprobarEstadoDelServidor()
        {
            try
            {
                if (this.OnCambioEnElEstadoDelServidorSql is not null)
                {
                    do
                    {
                        estadoAnteriorDelServidorSql = estadoActualDelServidorSql;
                        estadoActualDelServidorSql = MisComandosSql.VerificarConexionConSql(this.strConexionSql);
                        if (this.estadoActualDelServidorSql != this.estadoAnteriorDelServidorSql)
                        {
                            this.OnCambioEnElEstadoDelServidorSql.Invoke();
                            MessageBox.Show($"Servidor {this.estadoActualDelServidorSql.ToString()}");
                        }
                        Thread.Sleep(3000);
                    } while (threadVerificarConexionSql.IsAlive);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al revisar conexión con el servidor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        /// <summary>
        /// Busca un paciente dentro de la lista mediante su id y devuelve dicho paciente, si no existe devuevle null
        /// </summary>
        /// <returns>el paciente si lo econtró, null si no está en la lista</returns>
        public Paciente BuscarPacientePorId()
        {

            if (this.listaPacientesSeleccionados is not null)
            {
                int id;
                frmVentanaEmergenteConInputBoxSimple frmPidiendoId;
                Paciente auxPaciente;

                frmPidiendoId = new frmVentanaEmergenteConInputBoxSimple("Buscar paciente por id", "Ingrese el id del paciente:");
                frmPidiendoId.ShowDialog();
                id = int.Parse(frmPidiendoId.InformacionEscrita);
                auxPaciente = Paciente.BuscarPacienteEnListaMedianteId(id, this.listaPacientesSeleccionados);
                if (auxPaciente is not null)
                    return auxPaciente;
            }
            else
                MessageBox.Show("Lista vacia", "Error al buscar el paciente", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return null;
        }



        /// <summary>
        /// Busca un medico dentro de la lista mediante su id y devuelve dicho medico, si no existe devuevle null
        /// </summary>
        /// <returns>el paciente si lo econtró, null si no está en la lista</returns>
        public Medico BuscarMedicoPorId()
        {
            try
            {
                if (this.listaMedicosSeleccionados is not null)
                {
                    int id;
                    frmVentanaEmergenteConInputBoxSimple frmPidiendoId;
                    Medico auxMedico;

                    frmPidiendoId = new frmVentanaEmergenteConInputBoxSimple("Buscar paciente por id", "Ingrese el id del paciente:");
                    frmPidiendoId.ShowDialog();
                    id = int.Parse(frmPidiendoId.InformacionEscrita);
                    auxMedico = Medico.BuscarPacienteEnListaMedianteId(id, this.listaMedicosSeleccionados);
                    if (auxMedico is not null)
                        return auxMedico;
                }
                else
                    MessageBox.Show("Lista vacia", "Error al buscar el medico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al buscar el medico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            return null;
        }



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
            List<Atencion> listaAtencionCuatro = new();
            List<Atencion> listaAtencionCinco = new();

            listaAtencionUna.Add(new Atencion(1, 1, 1, "Bulto en el abdomen", "En observación", "Esperando resultados de los analisis", DateTime.Now));
            listaAtencionUna.Add(new Atencion(2, 1, 1, "Trajo los resultados del analasis", "Medicamento xxx", "Cancer", DateTime.Now));
            listaAtencionDos.Add(new Atencion(3, 2, 2, "Dolor de cabeza", "Medicamento yyy", "Esperando resultados de los analisis", DateTime.Now));
            listaAtencionTres.Add(new Atencion(4, 3, 3, "Fatiga ", "Vitaminas aaa", "falta de vitamina", DateTime.Now));
            listaAtencionCuatro.Add(new Atencion(5, 4, 4, "Dolor de rodilla ", "Descanso", "dolor articular", DateTime.Now));
            listaAtencionCinco.Add(new Atencion(6, 5, 5, "Descamación en la piel ", "Pomada xxx", "Hongos", DateTime.Now));


            Medico medicoUno = new(363434343, 30, "Álvarez Martín Andrés", sexoEnum.Hombre, 1, 23232, listaAtencionUna);
            Medico medicoDOs = new(232323211, 34, "Roberto de la fuente", sexoEnum.Hombre, 2, 4242, listaAtencionDos);
            Medico medicoTres = new(6666666, 35, "Julia Lopez", sexoEnum.Mujer, 3, 666656, listaAtencionTres);
            Medico medicoCuatro = new(77777, 36, "Roberta Lopez", sexoEnum.Mujer, 4, 34343, listaAtencionCuatro);
            Medico medicoCinco = new(22222, 22, "Josefa Hernesta", sexoEnum.Mujer, 5, 212122, listaAtencionCinco);

            this.listaMedicosSeleccionados.Add(medicoUno);
            this.listaMedicosSeleccionados.Add(medicoDOs);
            this.listaMedicosSeleccionados.Add(medicoTres);
            this.listaMedicosSeleccionados.Add(medicoCuatro);
            this.listaMedicosSeleccionados.Add(medicoCinco);

        }




        /// <summary>
        /// Harcodea Pacientes para una correción mas rápida del TP
        /// </summary>
        public void HarcodeoPaciente()
        {
            List<Atencion> listaAtencionUna = new();
            List<Atencion> listaAtencionDos = new();
            List<Atencion> listaAtencionTres = new();
            List<Atencion> listaAtencionCuatro = new();
            List<Atencion> listaAtencionCinco = new();

            listaAtencionUna.Add(new Atencion(1, 1, 1, "Bulto en el abdomen", "En observación", "Esperando resultados de los analisis", DateTime.Now));
            listaAtencionUna.Add(new Atencion(2, 1, 1, "Trajo los resultados del analasis", "Medicamento xxx", "Cancer", DateTime.Now));
            listaAtencionDos.Add(new Atencion(3, 2, 2, "Dolor de cabeza", "Medicamento yyy", "Esperando resultados de los analisis", DateTime.Now));
            listaAtencionTres.Add(new Atencion(4, 3, 3, "Fatiga ", "Vitaminas aaa", "falta de vitamina", DateTime.Now));
            listaAtencionCuatro.Add(new Atencion(5, 4, 4, "Dolor de rodilla ", "Descanso", "dolor articular", DateTime.Now));
            listaAtencionCinco.Add(new Atencion(6, 5, 5, "Descamación en la piel ", "Pomada xxx", "Hongos", DateTime.Now));

            this.listaPacientesSeleccionados.Add(new Paciente(34345234, 22, "Roberto juan", sexoEnum.Hombre, 1, listaAtencionUna, false, "AntecedentesMedico de Roberto juan"));
            this.listaPacientesSeleccionados.Add(new Paciente(222222, 11, "Perez juan", sexoEnum.Hombre, 2, listaAtencionDos, false, "AntecedentesMedico de Perez juan"));
            this.listaPacientesSeleccionados.Add(new Paciente(44444, 33, "Hernesto juan", sexoEnum.Hombre, 3, listaAtencionTres, false, "AntecedentesMedico de Hernesto juan"));
            this.listaPacientesSeleccionados.Add(new Paciente(3434343, 21, "Francisco", sexoEnum.Hombre, 4, listaAtencionCuatro, true, "AntecedentesMedico de Francisco"));
            this.listaPacientesSeleccionados.Add(new Paciente(212121, 16, "Julia Lopez", sexoEnum.Mujer, 5, listaAtencionCinco, true, "AntecedentesMedico de Julia Lopez"));

        }



        /// <summary>
        /// Harcodea Atenicones para una correción mas rápida del TP
        /// </summary>
        public void HarcodeoAtenciones()
        {
            this.listaAtencionesSeleccionadas.Add(new Atencion(1, 1, 1, "Bulto en el abdomen", "En observación", "Esperando resultados de los analisis", DateTime.Now));
            this.listaAtencionesSeleccionadas.Add(new Atencion(2, 1, 1, "Trajo los resultados del analasis", "Medicamento xxx", "Cancer", DateTime.Now));
            this.listaAtencionesSeleccionadas.Add(new Atencion(3, 2, 2, "Dolor de cabeza", "Medicamento yyy", "Esperando resultados de los analisis", DateTime.Now));
            this.listaAtencionesSeleccionadas.Add(new Atencion(4, 3, 3, "Fatiga ", "Vitaminas aaa", "falta de vitamina", DateTime.Now));
            this.listaAtencionesSeleccionadas.Add(new Atencion(5, 4, 4, "Dolor de rodilla ", "Descanso", "dolor articular", DateTime.Now));
            this.listaAtencionesSeleccionadas.Add(new Atencion(6, 5, 5, "Descamación en la piel ", "Pomada xxx", "Hongos", DateTime.Now));

        }

        /// <summary>
        /// Harcodea TurnosMedicos para una correción mas rápida del TP
        /// </summary>
        public void HarcodeoTurnosMedicos()
        {
            this.listaTurnosMedicosSeleccionados.Add(new TurnoMedico(1, 1, 1, new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 1, DateTime.Now.Minute, 1), false));
            this.listaTurnosMedicosSeleccionados.Add(new TurnoMedico(2, 1, 1, new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 2, DateTime.Now.Minute, 2), false));
            this.listaTurnosMedicosSeleccionados.Add(new TurnoMedico(3, 2, 2, new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 3, DateTime.Now.Minute, 3), false));
            this.listaTurnosMedicosSeleccionados.Add(new TurnoMedico(4, 3, 3, new DateTime(2022, 5, 18, 5, 2, 23), false));
            this.listaTurnosMedicosSeleccionados.Add(new TurnoMedico(5, 4, 4, new DateTime(2022, 5, 19, 5, 2, 23), false));
            this.listaTurnosMedicosSeleccionados.Add(new TurnoMedico(6, 5, 5, new DateTime(2022, 5, 20, 5, 2, 23), false));
        }

        /// <summary>
        /// Retorna una lista de atenciones nuevas, la cual es una combinación de la lista de Medicos y Pacientes, eliminando los id de atenciones repetidos 
        /// </summary>
        /// <returns>Una list<Atencion> con todas las atenciones, null si no está instanciada la lista de pacientes o medicos</Atencion></returns>
        public List<Atencion> generarListaAtencionDePacientesYMedicos()
        {
            if (this.listaPacientesSeleccionados is not null && this.listaMedicosSeleccionados is not null)
            {
                List<Atencion> auxAtencion = new();

                //CREO LA LISTA DE ATENCIONES
                this.listaPacientesSeleccionados.ForEach((paciente) => auxAtencion.AddRange(paciente.ListaDeAtenciones));
                this.listaMedicosSeleccionados.ForEach((medico) => auxAtencion.AddRange(medico.PacientesAtendidos));
                //LA ORDENO POR ID
                auxAtencion.Sort((a, b) => a.IdDeAtencion - b.IdDeAtencion);
                //AGRUPO POR EL ID Y AGREGO UNICAMENTE EL PRIMERO DE CADA ID     
                return auxAtencion.OrganizarListaDeAtenciones();
            }

            return null;
        }



        /// <summary>
        /// Cambia el color a los controles que muestran la información del servidor SQL
        /// </summary>
        /// <param name="colorParaCambiar">EL color que se cambia</param>
        public void CambiarColorControlesDeSql(Color colorParaCambiar)
        {
            this.txtConexionSql.BackColor = colorParaCambiar;
            this.lblServidorSql.ForeColor = colorParaCambiar;
        }


        /// <summary>
        /// Permite ingresar el medico al sistema, a su ves se modifica los controles para ayudarlo a atender
        /// </summary>
        private void LogeadMedico()
        {
            int idMedico;

            if (!string.IsNullOrEmpty(txtIngreseSuIdDeMedico.Text) && int.TryParse(this.txtIngreseSuIdDeMedico.Text, out idMedico) && this.listaTurnosRestanesDeHoy is not null)
            {
                if (this.estaLogeadoElMedico = listaMedicosSeleccionados.Any(p => p.IdDeMedico == idMedico))
                {
                    //SE LOGEA EL MEDICO
                    medicoLogeado = this.listaMedicosSeleccionados.First(p => p.IdDeMedico == idMedico);
                    try
                    {


                        //RETORNO LA LISTA DE TURNOS NO ATENDIDOS DE HOY PARA EL MEDICO LOGEADO
                        this.listaTurnosRestanesDeHoy = this.listaTurnosMedicosSeleccionados.FindAll(turnoMedico => turnoMedico.IdDeMedico == idMedico && turnoMedico.FechaTurno.Day == DateTime.Now.Day && turnoMedico.SeRealizoAtencionDelTurno == false);
                        if (this.listaTurnosRestanesDeHoy.Count > 0)
                        {
                            this.listaTurnosRestanesDeHoy.OrderByDescending(t => t.FechaTurno);
                            //BUSCO AL PRIMER PACIENTE
                            pacienteAtendido = this.listaPacientesSeleccionados.First(p => p.IdDePaciente == this.listaTurnosRestanesDeHoy[0].IdDePaciente);
                            txtNombrePaciente.Text = $"{pacienteAtendido.Nombre}";
                        }
                        else
                            this.txtNombrePaciente.Text = "Sin pacientes";

                        if (this.txtNombrePaciente.Enabled == false)
                        {
                            this.txtNombrePaciente.Enabled = true;
                            this.bttnComenzarAtencion.Enabled = true;
                            this.bttnVerInformacion.Enabled = true;
                            this.bttnVerTurnosRestantes.Enabled = true;
                        }
                        if (this.estaLogeadoElMedico == false || this.txtNombrePaciente.Text == "Sin pacientes")
                        {
                            this.txtNombrePaciente.Enabled = false;
                            this.bttnComenzarAtencion.Enabled = false;
                            this.bttnVerInformacion.Enabled = false;
                            this.bttnVerTurnosRestantes.Enabled = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message,"Error al logear al medico", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
        
                }

            }

            #endregion



        }
    }
}
