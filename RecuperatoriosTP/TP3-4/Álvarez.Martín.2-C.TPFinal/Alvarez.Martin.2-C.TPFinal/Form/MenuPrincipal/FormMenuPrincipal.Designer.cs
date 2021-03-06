
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
            this.tlsmiArchivoImportarAtenciones = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsmiArchivoExportar = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsmiArchivoExportarPacientes = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsmiArchivoExportarMedicos = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsmiArchivoExportarAtenciones = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsmPaciente = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsmiPacienteAgregar = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsmiPacienteMostrarTodosLosPacientes = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsmiMostrarTodosMisPacientes = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsmiBuscarPacientePorId = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsmMedico = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsmiMostrarTodosLosMedicos = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsmAtencion = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsmiNuevaAtencion = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsmiMostrarTodasLasAtenciones = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsmiMostrarAtencionesDe = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsmiMostrarAtencionesDeMedico = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsmiMostrarAtencionesDePaciente = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsmSQL = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsmiImportarSQL = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsmiExportarCambiosSQL = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlSql = new System.Windows.Forms.Panel();
            this.picSql = new System.Windows.Forms.PictureBox();
            this.lblServidorSql = new System.Windows.Forms.Label();
            this.pnlSqlTitulo = new System.Windows.Forms.Panel();
            this.txtConexionSql = new System.Windows.Forms.TextBox();
            this.grbSqlError = new System.Windows.Forms.GroupBox();
            this.lblErrorSql = new System.Windows.Forms.Label();
            this.mnsOpciones.SuspendLayout();
            this.pnlSql.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSql)).BeginInit();
            this.pnlSqlTitulo.SuspendLayout();
            this.grbSqlError.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnsOpciones
            // 
            this.mnsOpciones.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.mnsOpciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsmiArchivo,
            this.tlsmPaciente,
            this.tlsmMedico,
            this.tlsmAtencion,
            this.tlsmSQL});
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
            this.tlsmiArchivoImportarMedicos,
            this.tlsmiArchivoImportarAtenciones});
            this.tlsmiArchivoImportar.Name = "tlsmiArchivoImportar";
            this.tlsmiArchivoImportar.Size = new System.Drawing.Size(180, 22);
            this.tlsmiArchivoImportar.Text = "Importar";
            // 
            // tlsmiArchivoImportarPacientes
            // 
            this.tlsmiArchivoImportarPacientes.Name = "tlsmiArchivoImportarPacientes";
            this.tlsmiArchivoImportarPacientes.Size = new System.Drawing.Size(133, 22);
            this.tlsmiArchivoImportarPacientes.Text = "Pacientes";
            this.tlsmiArchivoImportarPacientes.Click += new System.EventHandler(this.tlsmiArchivoImportarPacientes_Click);
            // 
            // tlsmiArchivoImportarMedicos
            // 
            this.tlsmiArchivoImportarMedicos.Name = "tlsmiArchivoImportarMedicos";
            this.tlsmiArchivoImportarMedicos.Size = new System.Drawing.Size(133, 22);
            this.tlsmiArchivoImportarMedicos.Text = "Medicos";
            this.tlsmiArchivoImportarMedicos.Click += new System.EventHandler(this.tlsmiArchivoImportarMedicos_Click);
            // 
            // tlsmiArchivoImportarAtenciones
            // 
            this.tlsmiArchivoImportarAtenciones.Name = "tlsmiArchivoImportarAtenciones";
            this.tlsmiArchivoImportarAtenciones.Size = new System.Drawing.Size(133, 22);
            this.tlsmiArchivoImportarAtenciones.Text = "Atenciones";
            this.tlsmiArchivoImportarAtenciones.Click += new System.EventHandler(this.tlsmiArchivoImportarAtenciones_Click);
            // 
            // tlsmiArchivoExportar
            // 
            this.tlsmiArchivoExportar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsmiArchivoExportarPacientes,
            this.tlsmiArchivoExportarMedicos,
            this.tlsmiArchivoExportarAtenciones});
            this.tlsmiArchivoExportar.Name = "tlsmiArchivoExportar";
            this.tlsmiArchivoExportar.Size = new System.Drawing.Size(180, 22);
            this.tlsmiArchivoExportar.Text = "Exportar";
            // 
            // tlsmiArchivoExportarPacientes
            // 
            this.tlsmiArchivoExportarPacientes.Name = "tlsmiArchivoExportarPacientes";
            this.tlsmiArchivoExportarPacientes.Size = new System.Drawing.Size(133, 22);
            this.tlsmiArchivoExportarPacientes.Text = "Pacientes";
            this.tlsmiArchivoExportarPacientes.Click += new System.EventHandler(this.tlsmiArchivoExportarPacientes_Click);
            // 
            // tlsmiArchivoExportarMedicos
            // 
            this.tlsmiArchivoExportarMedicos.Name = "tlsmiArchivoExportarMedicos";
            this.tlsmiArchivoExportarMedicos.Size = new System.Drawing.Size(133, 22);
            this.tlsmiArchivoExportarMedicos.Text = "Medicos";
            this.tlsmiArchivoExportarMedicos.Click += new System.EventHandler(this.tlsmiArchivoExportarMedicos_Click);
            // 
            // tlsmiArchivoExportarAtenciones
            // 
            this.tlsmiArchivoExportarAtenciones.Name = "tlsmiArchivoExportarAtenciones";
            this.tlsmiArchivoExportarAtenciones.Size = new System.Drawing.Size(133, 22);
            this.tlsmiArchivoExportarAtenciones.Text = "Atenciones";
            this.tlsmiArchivoExportarAtenciones.Click += new System.EventHandler(this.tlsmiArchivoExportarAtenciones_Click);
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
            // tlsmAtencion
            // 
            this.tlsmAtencion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsmiNuevaAtencion,
            this.tlsmiMostrarTodasLasAtenciones,
            this.tlsmiMostrarAtencionesDe});
            this.tlsmAtencion.Name = "tlsmAtencion";
            this.tlsmAtencion.Size = new System.Drawing.Size(67, 20);
            this.tlsmAtencion.Text = "Atencion";
            // 
            // tlsmiNuevaAtencion
            // 
            this.tlsmiNuevaAtencion.Name = "tlsmiNuevaAtencion";
            this.tlsmiNuevaAtencion.Size = new System.Drawing.Size(224, 22);
            this.tlsmiNuevaAtencion.Text = "Nueva atención";
            this.tlsmiNuevaAtencion.Click += new System.EventHandler(this.tlsmiNuevaAtencion_Click);
            // 
            // tlsmiMostrarTodasLasAtenciones
            // 
            this.tlsmiMostrarTodasLasAtenciones.Name = "tlsmiMostrarTodasLasAtenciones";
            this.tlsmiMostrarTodasLasAtenciones.Size = new System.Drawing.Size(224, 22);
            this.tlsmiMostrarTodasLasAtenciones.Text = "Mostrar todas las atenciones";
            this.tlsmiMostrarTodasLasAtenciones.Click += new System.EventHandler(this.tlsmiMostrarTodasLasAtenciones_Click);
            // 
            // tlsmiMostrarAtencionesDe
            // 
            this.tlsmiMostrarAtencionesDe.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsmiMostrarAtencionesDeMedico,
            this.tlsmiMostrarAtencionesDePaciente});
            this.tlsmiMostrarAtencionesDe.Name = "tlsmiMostrarAtencionesDe";
            this.tlsmiMostrarAtencionesDe.Size = new System.Drawing.Size(224, 22);
            this.tlsmiMostrarAtencionesDe.Text = "Mostrar atenciones de...";
            // 
            // tlsmiMostrarAtencionesDeMedico
            // 
            this.tlsmiMostrarAtencionesDeMedico.Name = "tlsmiMostrarAtencionesDeMedico";
            this.tlsmiMostrarAtencionesDeMedico.Size = new System.Drawing.Size(119, 22);
            this.tlsmiMostrarAtencionesDeMedico.Text = "Medico";
            this.tlsmiMostrarAtencionesDeMedico.Click += new System.EventHandler(this.tlsmiMostrarAtencionesDeMedico_Click);
            // 
            // tlsmiMostrarAtencionesDePaciente
            // 
            this.tlsmiMostrarAtencionesDePaciente.Name = "tlsmiMostrarAtencionesDePaciente";
            this.tlsmiMostrarAtencionesDePaciente.Size = new System.Drawing.Size(119, 22);
            this.tlsmiMostrarAtencionesDePaciente.Text = "Paciente";
            this.tlsmiMostrarAtencionesDePaciente.Click += new System.EventHandler(this.tlsmiMostrarAtencionesDePaciente_Click);
            // 
            // tlsmSQL
            // 
            this.tlsmSQL.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsmiImportarSQL,
            this.tlsmiExportarCambiosSQL});
            this.tlsmSQL.Name = "tlsmSQL";
            this.tlsmSQL.Size = new System.Drawing.Size(40, 20);
            this.tlsmSQL.Text = "SQL";
            // 
            // tlsmiImportarSQL
            // 
            this.tlsmiImportarSQL.Name = "tlsmiImportarSQL";
            this.tlsmiImportarSQL.Size = new System.Drawing.Size(177, 22);
            this.tlsmiImportarSQL.Text = "Importar...";
            this.tlsmiImportarSQL.Click += new System.EventHandler(this.tlsmiImportarSQL_Click);
            // 
            // tlsmiExportarCambiosSQL
            // 
            this.tlsmiExportarCambiosSQL.Name = "tlsmiExportarCambiosSQL";
            this.tlsmiExportarCambiosSQL.Size = new System.Drawing.Size(177, 22);
            this.tlsmiExportarCambiosSQL.Text = "Exportar Cambios...";
            this.tlsmiExportarCambiosSQL.Click += new System.EventHandler(this.tlsmiExportarSQL_Click);
            // 
            // pnlSql
            // 
            this.pnlSql.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnlSql.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSql.Controls.Add(this.picSql);
            this.pnlSql.Controls.Add(this.lblServidorSql);
            this.pnlSql.Controls.Add(this.pnlSqlTitulo);
            this.pnlSql.Location = new System.Drawing.Point(6, 22);
            this.pnlSql.Name = "pnlSql";
            this.pnlSql.Size = new System.Drawing.Size(133, 128);
            this.pnlSql.TabIndex = 49;
            // 
            // picSql
            // 
            this.picSql.ErrorImage = null;
            this.picSql.Image = ((System.Drawing.Image)(resources.GetObject("picSql.Image")));
            this.picSql.InitialImage = null;
            this.picSql.Location = new System.Drawing.Point(25, 34);
            this.picSql.Name = "picSql";
            this.picSql.Size = new System.Drawing.Size(81, 63);
            this.picSql.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSql.TabIndex = 48;
            this.picSql.TabStop = false;
            // 
            // lblServidorSql
            // 
            this.lblServidorSql.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblServidorSql.ForeColor = System.Drawing.Color.Brown;
            this.lblServidorSql.Location = new System.Drawing.Point(3, 96);
            this.lblServidorSql.Name = "lblServidorSql";
            this.lblServidorSql.Size = new System.Drawing.Size(125, 31);
            this.lblServidorSql.TabIndex = 48;
            this.lblServidorSql.Text = "Offline";
            this.lblServidorSql.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlSqlTitulo
            // 
            this.pnlSqlTitulo.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.pnlSqlTitulo.Controls.Add(this.txtConexionSql);
            this.pnlSqlTitulo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnlSqlTitulo.Location = new System.Drawing.Point(-1, -1);
            this.pnlSqlTitulo.Name = "pnlSqlTitulo";
            this.pnlSqlTitulo.Size = new System.Drawing.Size(133, 25);
            this.pnlSqlTitulo.TabIndex = 47;
            // 
            // txtConexionSql
            // 
            this.txtConexionSql.BackColor = System.Drawing.Color.Brown;
            this.txtConexionSql.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtConexionSql.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtConexionSql.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtConexionSql.ForeColor = System.Drawing.SystemColors.Menu;
            this.txtConexionSql.Location = new System.Drawing.Point(0, 0);
            this.txtConexionSql.Name = "txtConexionSql";
            this.txtConexionSql.ReadOnly = true;
            this.txtConexionSql.Size = new System.Drawing.Size(133, 25);
            this.txtConexionSql.TabIndex = 43;
            this.txtConexionSql.Text = "SQL";
            this.txtConexionSql.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // grbSqlError
            // 
            this.grbSqlError.Controls.Add(this.lblErrorSql);
            this.grbSqlError.Controls.Add(this.pnlSql);
            this.grbSqlError.Location = new System.Drawing.Point(69, 125);
            this.grbSqlError.Name = "grbSqlError";
            this.grbSqlError.Size = new System.Drawing.Size(561, 159);
            this.grbSqlError.TabIndex = 42;
            this.grbSqlError.TabStop = false;
            this.grbSqlError.Text = "SQL Error";
            // 
            // lblErrorSql
            // 
            this.lblErrorSql.AutoSize = true;
            this.lblErrorSql.Location = new System.Drawing.Point(145, 50);
            this.lblErrorSql.Name = "lblErrorSql";
            this.lblErrorSql.Size = new System.Drawing.Size(0, 15);
            this.lblErrorSql.TabIndex = 50;
            // 
            // FormMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(745, 428);
            this.Controls.Add(this.grbSqlError);
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
            this.pnlSql.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picSql)).EndInit();
            this.pnlSqlTitulo.ResumeLayout(false);
            this.pnlSqlTitulo.PerformLayout();
            this.grbSqlError.ResumeLayout(false);
            this.grbSqlError.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnsOpciones;
        private System.Windows.Forms.ToolStripMenuItem tlsmPaciente;
        private System.Windows.Forms.ToolStripMenuItem tlsmiPacienteAgregar;
        private System.Windows.Forms.ToolStripMenuItem tlsmMedico;
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
        private System.Windows.Forms.ToolStripMenuItem tlsmAtencion;
        private System.Windows.Forms.ToolStripMenuItem tlsmiNuevaAtencion;
        private System.Windows.Forms.ToolStripMenuItem tlsmiMostrarTodasLasAtenciones;
        private System.Windows.Forms.ToolStripMenuItem tlsmiMostrarAtencionesDe;
        private System.Windows.Forms.ToolStripMenuItem tlsmiMostrarAtencionesDeMedico;
        private System.Windows.Forms.ToolStripMenuItem tlsmiMostrarAtencionesDePaciente;
        private System.Windows.Forms.Panel pnlSql;
        private System.Windows.Forms.PictureBox picSql;
        private System.Windows.Forms.Label lblServidorSql;
        private System.Windows.Forms.Panel pnlSqlTitulo;
        private System.Windows.Forms.TextBox txtConexionSql;
        private System.Windows.Forms.ToolStripMenuItem tlsmSQL;
        private System.Windows.Forms.ToolStripMenuItem tlsmiImportarSQL;
        private System.Windows.Forms.GroupBox grbSqlError;
        private System.Windows.Forms.ToolStripMenuItem tlsmiExportarCambiosSQL;
        private System.Windows.Forms.ToolStripMenuItem tlsmiArchivoImportarAtenciones;
        private System.Windows.Forms.ToolStripMenuItem tlsmiArchivoExportarAtenciones;
        private System.Windows.Forms.Label lblErrorSql;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem onToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem offToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem onToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem offToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dToolStripMenuItem;
    }
}

