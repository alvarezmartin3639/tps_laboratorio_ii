
namespace MenuPrincipal
{
    partial class FormMenuPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMenuPrincipal));
            this.mnsOpciones = new System.Windows.Forms.MenuStrip();
            this.tlsmiArchivo = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsmiArchivoImportar = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsmiArchivoImportarPacientes = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsmiArchivoImportarMedicos = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsmiArchivoExportar = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsmiArchivoExportarPacientes = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsmiArchivoExportarMedicos = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsmPaciente = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsmiPacienteAgregar = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsmiPacienteMostrarTodosLosPacientes = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsmiMostrarTodosMisPacientes = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsmiBuscarPacientePorId = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsmMedico = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsmiMostrarTodosLosMedicos = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsmiNuevaAtencion = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsOpciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnsOpciones
            // 
            this.mnsOpciones.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.mnsOpciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsmiArchivo,
            this.tlsmPaciente,
            this.tlsmMedico,
            this.tlsmiNuevaAtencion});
            this.mnsOpciones.Location = new System.Drawing.Point(0, 0);
            this.mnsOpciones.Name = "mnsOpciones";
            this.mnsOpciones.Size = new System.Drawing.Size(745, 24);
            this.mnsOpciones.TabIndex = 0;
            this.mnsOpciones.Text = "menuStrip1";
            // 
            // tlsmiArchivo
            // 
            this.tlsmiArchivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsmiArchivoImportar,
            this.tlsmiArchivoExportar});
            this.tlsmiArchivo.Name = "tlsmiArchivo";
            this.tlsmiArchivo.Size = new System.Drawing.Size(60, 20);
            this.tlsmiArchivo.Text = "Archivo";
            // 
            // tlsmiArchivoImportar
            // 
            this.tlsmiArchivoImportar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsmiArchivoImportarPacientes,
            this.tlsmiArchivoImportarMedicos});
            this.tlsmiArchivoImportar.Name = "tlsmiArchivoImportar";
            this.tlsmiArchivoImportar.Size = new System.Drawing.Size(120, 22);
            this.tlsmiArchivoImportar.Text = "Importar";
            // 
            // tlsmiArchivoImportarPacientes
            // 
            this.tlsmiArchivoImportarPacientes.Name = "tlsmiArchivoImportarPacientes";
            this.tlsmiArchivoImportarPacientes.Size = new System.Drawing.Size(124, 22);
            this.tlsmiArchivoImportarPacientes.Text = "Pacientes";
            this.tlsmiArchivoImportarPacientes.Click += new System.EventHandler(this.tlsmiArchivoImportarPacientes_Click);
            // 
            // tlsmiArchivoImportarMedicos
            // 
            this.tlsmiArchivoImportarMedicos.Name = "tlsmiArchivoImportarMedicos";
            this.tlsmiArchivoImportarMedicos.Size = new System.Drawing.Size(124, 22);
            this.tlsmiArchivoImportarMedicos.Text = "Medicos";
            this.tlsmiArchivoImportarMedicos.Click += new System.EventHandler(this.tlsmiArchivoImportarMedicos_Click);
            // 
            // tlsmiArchivoExportar
            // 
            this.tlsmiArchivoExportar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsmiArchivoExportarPacientes,
            this.tlsmiArchivoExportarMedicos});
            this.tlsmiArchivoExportar.Name = "tlsmiArchivoExportar";
            this.tlsmiArchivoExportar.Size = new System.Drawing.Size(120, 22);
            this.tlsmiArchivoExportar.Text = "Exportar";
            // 
            // tlsmiArchivoExportarPacientes
            // 
            this.tlsmiArchivoExportarPacientes.Name = "tlsmiArchivoExportarPacientes";
            this.tlsmiArchivoExportarPacientes.Size = new System.Drawing.Size(124, 22);
            this.tlsmiArchivoExportarPacientes.Text = "Pacientes";
            this.tlsmiArchivoExportarPacientes.Click += new System.EventHandler(this.tlsmiArchivoExportarPacientes_Click);
            // 
            // tlsmiArchivoExportarMedicos
            // 
            this.tlsmiArchivoExportarMedicos.Name = "tlsmiArchivoExportarMedicos";
            this.tlsmiArchivoExportarMedicos.Size = new System.Drawing.Size(124, 22);
            this.tlsmiArchivoExportarMedicos.Text = "Medicos";
            this.tlsmiArchivoExportarMedicos.Click += new System.EventHandler(this.tlsmiArchivoExportarMedicos_Click);
            // 
            // tlsmPaciente
            // 
            this.tlsmPaciente.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsmiPacienteAgregar,
            this.tlsmiPacienteMostrarTodosLosPacientes,
            this.tlsmiMostrarTodosMisPacientes,
            this.tlsmiBuscarPacientePorId});
            this.tlsmPaciente.Name = "tlsmPaciente";
            this.tlsmPaciente.Size = new System.Drawing.Size(64, 20);
            this.tlsmPaciente.Text = "Paciente";
            // 
            // tlsmiPacienteAgregar
            // 
            this.tlsmiPacienteAgregar.Name = "tlsmiPacienteAgregar";
            this.tlsmiPacienteAgregar.Size = new System.Drawing.Size(226, 22);
            this.tlsmiPacienteAgregar.Text = "Agregar";
            this.tlsmiPacienteAgregar.Click += new System.EventHandler(this.tlsmiPacienteAgregar_Click);
            // 
            // tlsmiPacienteMostrarTodosLosPacientes
            // 
            this.tlsmiPacienteMostrarTodosLosPacientes.Name = "tlsmiPacienteMostrarTodosLosPacientes";
            this.tlsmiPacienteMostrarTodosLosPacientes.Size = new System.Drawing.Size(226, 22);
            this.tlsmiPacienteMostrarTodosLosPacientes.Text = "Mostrar todos los pacientes";
            this.tlsmiPacienteMostrarTodosLosPacientes.Click += new System.EventHandler(this.tlsmiPacienteMostrarLista_Click);
            // 
            // tlsmiMostrarTodosMisPacientes
            // 
            this.tlsmiMostrarTodosMisPacientes.Name = "tlsmiMostrarTodosMisPacientes";
            this.tlsmiMostrarTodosMisPacientes.Size = new System.Drawing.Size(226, 22);
            this.tlsmiMostrarTodosMisPacientes.Text = "Mostrar todos mis pacientes.";
            // 
            // tlsmiBuscarPacientePorId
            // 
            this.tlsmiBuscarPacientePorId.Name = "tlsmiBuscarPacientePorId";
            this.tlsmiBuscarPacientePorId.Size = new System.Drawing.Size(226, 22);
            this.tlsmiBuscarPacientePorId.Text = "Buscar paciente por id";
            this.tlsmiBuscarPacientePorId.Click += new System.EventHandler(this.tlsmiBuscarPacientePorId_Click);
            // 
            // tlsmMedico
            // 
            this.tlsmMedico.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsmiMostrarTodosLosMedicos});
            this.tlsmMedico.Name = "tlsmMedico";
            this.tlsmMedico.Size = new System.Drawing.Size(59, 20);
            this.tlsmMedico.Text = "Medico";
            // 
            // tlsmiMostrarTodosLosMedicos
            // 
            this.tlsmiMostrarTodosLosMedicos.Name = "tlsmiMostrarTodosLosMedicos";
            this.tlsmiMostrarTodosLosMedicos.Size = new System.Drawing.Size(214, 22);
            this.tlsmiMostrarTodosLosMedicos.Text = "Mostrar todos los medicos";
            this.tlsmiMostrarTodosLosMedicos.Click += new System.EventHandler(this.tlsmiMostrarTodosLosMedicos_Click);
            // 
            // tlsmiNuevaAtencion
            // 
            this.tlsmiNuevaAtencion.Name = "tlsmiNuevaAtencion";
            this.tlsmiNuevaAtencion.Size = new System.Drawing.Size(102, 20);
            this.tlsmiNuevaAtencion.Text = "Nueva atención";
            this.tlsmiNuevaAtencion.Click += new System.EventHandler(this.tlsmiNuevaAtencion_Click);
            // 
            // FormMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(745, 428);
            this.Controls.Add(this.mnsOpciones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnsOpciones;
            this.MaximizeBox = false;
            this.Name = "FormMenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hospital Santa Maria";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMenuPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.FormMenuPrincipal_Load);
            this.mnsOpciones.ResumeLayout(false);
            this.mnsOpciones.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnsOpciones;
        private System.Windows.Forms.ToolStripMenuItem tlsmPaciente;
        private System.Windows.Forms.ToolStripMenuItem tlsmiPacienteAgregar;
        private System.Windows.Forms.ToolStripMenuItem tlsmMedico;
        private System.Windows.Forms.ToolStripMenuItem tlsmiNuevaAtencion;
        private System.Windows.Forms.ToolStripMenuItem tlsmiPacienteMostrarTodosLosPacientes;
        private System.Windows.Forms.ToolStripMenuItem tlsmiMostrarTodosLosMedicos;
        private System.Windows.Forms.ToolStripMenuItem tlsmiMostrarTodosMisPacientes;
        private System.Windows.Forms.ToolStripMenuItem tlsmiArchivo;
        private System.Windows.Forms.ToolStripMenuItem tlsmiArchivoImportar;
        private System.Windows.Forms.ToolStripMenuItem tlsmiArchivoImportarPacientes;
        private System.Windows.Forms.ToolStripMenuItem tlsmiArchivoImportarMedicos;
        private System.Windows.Forms.ToolStripMenuItem tlsmiArchivoExportar;
        private System.Windows.Forms.ToolStripMenuItem tlsmiArchivoExportarPacientes;
        private System.Windows.Forms.ToolStripMenuItem tlsmiArchivoExportarMedicos;
        private System.Windows.Forms.ToolStripMenuItem tlsmiBuscarPacientePorId;
    }
}

