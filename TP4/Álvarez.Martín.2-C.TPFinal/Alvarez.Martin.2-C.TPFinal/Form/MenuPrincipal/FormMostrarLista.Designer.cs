
namespace MenuPrincipal
{
    partial class frmMostrarLista
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMostrarLista));
            this.msnMenu = new System.Windows.Forms.MenuStrip();
            this.tlsmiArchivo = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsmiArchivoExportar = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsmiVer = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsmiVerHistorialDeAtenciones = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsmiVerHistorialDeAtencionesDeLaPersonaSeleccionada = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvLista = new System.Windows.Forms.DataGridView();
            this.msnMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            this.SuspendLayout();
            // 
            // msnMenu
            // 
            this.msnMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsmiArchivo,
            this.tlsmiVer});
            this.msnMenu.Location = new System.Drawing.Point(0, 0);
            this.msnMenu.Name = "msnMenu";
            this.msnMenu.Size = new System.Drawing.Size(963, 24);
            this.msnMenu.TabIndex = 1;
            this.msnMenu.Text = "menuStrip1";
            // 
            // tlsmiArchivo
            // 
            this.tlsmiArchivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsmiArchivoExportar});
            this.tlsmiArchivo.Name = "tlsmiArchivo";
            this.tlsmiArchivo.Size = new System.Drawing.Size(60, 20);
            this.tlsmiArchivo.Text = "Archivo";
            // 
            // tlsmiArchivoExportar
            // 
            this.tlsmiArchivoExportar.Name = "tlsmiArchivoExportar";
            this.tlsmiArchivoExportar.Size = new System.Drawing.Size(127, 22);
            this.tlsmiArchivoExportar.Text = "Exportar...";
            this.tlsmiArchivoExportar.Click += new System.EventHandler(this.tlsmiArchivoExportar_Click);
            // 
            // tlsmiVer
            // 
            this.tlsmiVer.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsmiVerHistorialDeAtenciones});
            this.tlsmiVer.Name = "tlsmiVer";
            this.tlsmiVer.Size = new System.Drawing.Size(35, 20);
            this.tlsmiVer.Text = "Ver";
            // 
            // tlsmiVerHistorialDeAtenciones
            // 
            this.tlsmiVerHistorialDeAtenciones.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsmiVerHistorialDeAtencionesDeLaPersonaSeleccionada});
            this.tlsmiVerHistorialDeAtenciones.Name = "tlsmiVerHistorialDeAtenciones";
            this.tlsmiVerHistorialDeAtenciones.Size = new System.Drawing.Size(194, 22);
            this.tlsmiVerHistorialDeAtenciones.Text = "Historial de atenciones";
            // 
            // tlsmiVerHistorialDeAtencionesDeLaPersonaSeleccionada
            // 
            this.tlsmiVerHistorialDeAtencionesDeLaPersonaSeleccionada.Name = "tlsmiVerHistorialDeAtencionesDeLaPersonaSeleccionada";
            this.tlsmiVerHistorialDeAtencionesDeLaPersonaSeleccionada.Size = new System.Drawing.Size(193, 22);
            this.tlsmiVerHistorialDeAtencionesDeLaPersonaSeleccionada.Text = "Persona seleccionada..";
            this.tlsmiVerHistorialDeAtencionesDeLaPersonaSeleccionada.Click += new System.EventHandler(this.tlsmiVerHistorialDeAtencionesDeLaPersonaSeleccionada_Click);
            // 
            // dgvLista
            // 
            this.dgvLista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLista.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvLista.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLista.Location = new System.Drawing.Point(0, 27);
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.ReadOnly = true;
            this.dgvLista.RowTemplate.Height = 25;
            this.dgvLista.Size = new System.Drawing.Size(963, 545);
            this.dgvLista.TabIndex = 2;
            this.dgvLista.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLista_CellContentDoubleClick);
            // 
            // frmMostrarLista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(963, 573);
            this.Controls.Add(this.dgvLista);
            this.Controls.Add(this.msnMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msnMenu;
            this.MaximizeBox = false;
            this.Name = "frmMostrarLista";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de personas";
            this.Load += new System.EventHandler(this.frmMostrarLista_Load);
            this.msnMenu.ResumeLayout(false);
            this.msnMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip msnMenu;
        private System.Windows.Forms.ToolStripMenuItem tlsmiArchivo;
        private System.Windows.Forms.ToolStripMenuItem tlsmiArchivoExportar;
        private System.Windows.Forms.DataGridView dgvLista;
        private System.Windows.Forms.ToolStripMenuItem tlsmiVer;
        private System.Windows.Forms.ToolStripMenuItem tlsmiVerHistorialDeAtenciones;
        private System.Windows.Forms.ToolStripMenuItem tlsmiVerHistorialDeAtencionesDeLaPersonaSeleccionada;
    }
}

