
namespace MenuPrincipal
{
    partial class frmNuevaAtencion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNuevaAtencion));
            this.lblMotivoDeLaConsulta = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNuevaAtencion = new System.Windows.Forms.Label();
            this.lblTratamiento = new System.Windows.Forms.Label();
            this.lblDiagnostico = new System.Windows.Forms.Label();
            this.bttnFinalizarAtencion = new System.Windows.Forms.Button();
            this.bttnLimpiarDatos = new System.Windows.Forms.Button();
            this.lblIdDePaciente = new System.Windows.Forms.Label();
            this.txtIdDePaciente = new System.Windows.Forms.TextBox();
            this.bttnRedactarMotivoDeLaConsulta = new System.Windows.Forms.Button();
            this.bttnRedactarDiagnostico = new System.Windows.Forms.Button();
            this.bttnRedactarTratamiento = new System.Windows.Forms.Button();
            this.bttnVerDatosIdDePaciente = new System.Windows.Forms.Button();
            this.lblIdDeMedico = new System.Windows.Forms.Label();
            this.txtIdDeMedico = new System.Windows.Forms.TextBox();
            this.lblNombreMedico = new System.Windows.Forms.Label();
            this.lblNombrePaciente = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMotivoDeLaConsulta
            // 
            this.lblMotivoDeLaConsulta.AutoSize = true;
            this.lblMotivoDeLaConsulta.Font = new System.Drawing.Font("Georgia", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMotivoDeLaConsulta.Location = new System.Drawing.Point(21, 110);
            this.lblMotivoDeLaConsulta.Name = "lblMotivoDeLaConsulta";
            this.lblMotivoDeLaConsulta.Size = new System.Drawing.Size(149, 17);
            this.lblMotivoDeLaConsulta.TabIndex = 9;
            this.lblMotivoDeLaConsulta.Text = "Motivo de la consulta: ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.panel1.Controls.Add(this.lblNuevaAtencion);
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Location = new System.Drawing.Point(1, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(449, 26);
            this.panel1.TabIndex = 104;
            // 
            // lblNuevaAtencion
            // 
            this.lblNuevaAtencion.AutoSize = true;
            this.lblNuevaAtencion.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNuevaAtencion.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblNuevaAtencion.Location = new System.Drawing.Point(119, 0);
            this.lblNuevaAtencion.Name = "lblNuevaAtencion";
            this.lblNuevaAtencion.Size = new System.Drawing.Size(115, 18);
            this.lblNuevaAtencion.TabIndex = 1;
            this.lblNuevaAtencion.Text = "Nueva Atención";
            // 
            // lblTratamiento
            // 
            this.lblTratamiento.AutoSize = true;
            this.lblTratamiento.Font = new System.Drawing.Font("Georgia", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTratamiento.Location = new System.Drawing.Point(21, 163);
            this.lblTratamiento.Name = "lblTratamiento";
            this.lblTratamiento.Size = new System.Drawing.Size(91, 17);
            this.lblTratamiento.TabIndex = 13;
            this.lblTratamiento.Text = "Tratamiento:";
            // 
            // lblDiagnostico
            // 
            this.lblDiagnostico.AutoSize = true;
            this.lblDiagnostico.Font = new System.Drawing.Font("Georgia", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDiagnostico.Location = new System.Drawing.Point(21, 136);
            this.lblDiagnostico.Name = "lblDiagnostico";
            this.lblDiagnostico.Size = new System.Drawing.Size(89, 17);
            this.lblDiagnostico.TabIndex = 11;
            this.lblDiagnostico.Text = "Diagnostico: ";
            // 
            // bttnFinalizarAtencion
            // 
            this.bttnFinalizarAtencion.BackColor = System.Drawing.Color.Teal;
            this.bttnFinalizarAtencion.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bttnFinalizarAtencion.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bttnFinalizarAtencion.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bttnFinalizarAtencion.Location = new System.Drawing.Point(21, 194);
            this.bttnFinalizarAtencion.Name = "bttnFinalizarAtencion";
            this.bttnFinalizarAtencion.Size = new System.Drawing.Size(123, 22);
            this.bttnFinalizarAtencion.TabIndex = 15;
            this.bttnFinalizarAtencion.Text = "Finalizar atención";
            this.bttnFinalizarAtencion.UseVisualStyleBackColor = false;
            this.bttnFinalizarAtencion.Click += new System.EventHandler(this.bttnFinalizarAtencion_Click);
            // 
            // bttnLimpiarDatos
            // 
            this.bttnLimpiarDatos.BackColor = System.Drawing.Color.Teal;
            this.bttnLimpiarDatos.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bttnLimpiarDatos.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bttnLimpiarDatos.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bttnLimpiarDatos.Location = new System.Drawing.Point(255, 193);
            this.bttnLimpiarDatos.Name = "bttnLimpiarDatos";
            this.bttnLimpiarDatos.Size = new System.Drawing.Size(106, 22);
            this.bttnLimpiarDatos.TabIndex = 16;
            this.bttnLimpiarDatos.Text = "Limpiar datos";
            this.bttnLimpiarDatos.UseVisualStyleBackColor = false;
            // 
            // lblIdDePaciente
            // 
            this.lblIdDePaciente.AutoSize = true;
            this.lblIdDePaciente.Font = new System.Drawing.Font("Georgia", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblIdDePaciente.Location = new System.Drawing.Point(19, 81);
            this.lblIdDePaciente.Name = "lblIdDePaciente";
            this.lblIdDePaciente.Size = new System.Drawing.Size(100, 17);
            this.lblIdDePaciente.TabIndex = 5;
            this.lblIdDePaciente.Text = "Id de paciente:";
            // 
            // txtIdDePaciente
            // 
            this.txtIdDePaciente.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIdDePaciente.Location = new System.Drawing.Point(224, 82);
            this.txtIdDePaciente.Name = "txtIdDePaciente";
            this.txtIdDePaciente.Size = new System.Drawing.Size(86, 16);
            this.txtIdDePaciente.TabIndex = 7;
            this.txtIdDePaciente.Leave += new System.EventHandler(this.txtIdDePaciente_Leave);
            // 
            // bttnRedactarMotivoDeLaConsulta
            // 
            this.bttnRedactarMotivoDeLaConsulta.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bttnRedactarMotivoDeLaConsulta.Location = new System.Drawing.Point(285, 110);
            this.bttnRedactarMotivoDeLaConsulta.Name = "bttnRedactarMotivoDeLaConsulta";
            this.bttnRedactarMotivoDeLaConsulta.Size = new System.Drawing.Size(76, 20);
            this.bttnRedactarMotivoDeLaConsulta.TabIndex = 10;
            this.bttnRedactarMotivoDeLaConsulta.Text = "Redactar...";
            this.bttnRedactarMotivoDeLaConsulta.UseVisualStyleBackColor = true;
            this.bttnRedactarMotivoDeLaConsulta.Click += new System.EventHandler(this.bttnRedactarMotivoDeLaConsulta_Click);
            // 
            // bttnRedactarDiagnostico
            // 
            this.bttnRedactarDiagnostico.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bttnRedactarDiagnostico.Location = new System.Drawing.Point(285, 136);
            this.bttnRedactarDiagnostico.Name = "bttnRedactarDiagnostico";
            this.bttnRedactarDiagnostico.Size = new System.Drawing.Size(76, 20);
            this.bttnRedactarDiagnostico.TabIndex = 12;
            this.bttnRedactarDiagnostico.Text = "Redactar...";
            this.bttnRedactarDiagnostico.UseVisualStyleBackColor = true;
            this.bttnRedactarDiagnostico.Click += new System.EventHandler(this.bttnRedactarDiagnostico_Click);
            // 
            // bttnRedactarTratamiento
            // 
            this.bttnRedactarTratamiento.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bttnRedactarTratamiento.Location = new System.Drawing.Point(285, 162);
            this.bttnRedactarTratamiento.Name = "bttnRedactarTratamiento";
            this.bttnRedactarTratamiento.Size = new System.Drawing.Size(76, 20);
            this.bttnRedactarTratamiento.TabIndex = 14;
            this.bttnRedactarTratamiento.Text = "Redactar...";
            this.bttnRedactarTratamiento.UseVisualStyleBackColor = true;
            this.bttnRedactarTratamiento.Click += new System.EventHandler(this.bttnRedactarTratamiento_Click);
            // 
            // bttnVerDatosIdDePaciente
            // 
            this.bttnVerDatosIdDePaciente.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bttnVerDatosIdDePaciente.Location = new System.Drawing.Point(316, 79);
            this.bttnVerDatosIdDePaciente.Name = "bttnVerDatosIdDePaciente";
            this.bttnVerDatosIdDePaciente.Size = new System.Drawing.Size(45, 20);
            this.bttnVerDatosIdDePaciente.TabIndex = 6;
            this.bttnVerDatosIdDePaciente.Text = "Info";
            this.bttnVerDatosIdDePaciente.UseVisualStyleBackColor = true;
            this.bttnVerDatosIdDePaciente.Click += new System.EventHandler(this.bttnVerDatosIdDePaciente_Click);
            // 
            // lblIdDeMedico
            // 
            this.lblIdDeMedico.AutoSize = true;
            this.lblIdDeMedico.Font = new System.Drawing.Font("Georgia", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblIdDeMedico.Location = new System.Drawing.Point(21, 53);
            this.lblIdDeMedico.Name = "lblIdDeMedico";
            this.lblIdDeMedico.Size = new System.Drawing.Size(93, 17);
            this.lblIdDeMedico.TabIndex = 2;
            this.lblIdDeMedico.Text = "Id de medico:";
            // 
            // txtIdDeMedico
            // 
            this.txtIdDeMedico.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIdDeMedico.Location = new System.Drawing.Point(224, 54);
            this.txtIdDeMedico.Name = "txtIdDeMedico";
            this.txtIdDeMedico.Size = new System.Drawing.Size(86, 16);
            this.txtIdDeMedico.TabIndex = 3;
            this.txtIdDeMedico.Leave += new System.EventHandler(this.txtIdDeMedico_Leave);
            // 
            // lblNombreMedico
            // 
            this.lblNombreMedico.AutoSize = true;
            this.lblNombreMedico.Location = new System.Drawing.Point(120, 54);
            this.lblNombreMedico.Name = "lblNombreMedico";
            this.lblNombreMedico.Size = new System.Drawing.Size(0, 15);
            this.lblNombreMedico.TabIndex = 4;
            // 
            // lblNombrePaciente
            // 
            this.lblNombrePaciente.AutoSize = true;
            this.lblNombrePaciente.Location = new System.Drawing.Point(120, 81);
            this.lblNombrePaciente.Name = "lblNombrePaciente";
            this.lblNombrePaciente.Size = new System.Drawing.Size(0, 15);
            this.lblNombrePaciente.TabIndex = 8;
            // 
            // frmNuevaAtencion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(360, 227);
            this.Controls.Add(this.lblNombrePaciente);
            this.Controls.Add(this.lblNombreMedico);
            this.Controls.Add(this.txtIdDeMedico);
            this.Controls.Add(this.lblIdDeMedico);
            this.Controls.Add(this.bttnVerDatosIdDePaciente);
            this.Controls.Add(this.bttnRedactarTratamiento);
            this.Controls.Add(this.bttnRedactarDiagnostico);
            this.Controls.Add(this.bttnRedactarMotivoDeLaConsulta);
            this.Controls.Add(this.lblMotivoDeLaConsulta);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblTratamiento);
            this.Controls.Add(this.lblDiagnostico);
            this.Controls.Add(this.bttnFinalizarAtencion);
            this.Controls.Add(this.bttnLimpiarDatos);
            this.Controls.Add(this.lblIdDePaciente);
            this.Controls.Add(this.txtIdDePaciente);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmNuevaAtencion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Atendiendo paciente";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMotivoDeLaConsulta;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblNuevaAtencion;
        private System.Windows.Forms.Label lblTratamiento;
        private System.Windows.Forms.Label lblDiagnostico;
        private System.Windows.Forms.Button bttnFinalizarAtencion;
        private System.Windows.Forms.Button bttnLimpiarDatos;
        private System.Windows.Forms.Label lblIdDePaciente;
        private System.Windows.Forms.TextBox txtIdDePaciente;
        private System.Windows.Forms.Button bttnRedactarMotivoDeLaConsulta;
        private System.Windows.Forms.Button bttnRedactarDiagnostico;
        private System.Windows.Forms.Button bttnRedactarTratamiento;
        private System.Windows.Forms.Button bttnVerDatosIdDePaciente;
        private System.Windows.Forms.Label lblIdDeMedico;
        private System.Windows.Forms.TextBox txtIdDeMedico;
        private System.Windows.Forms.Label lblNombreMedico;
        private System.Windows.Forms.Label lblNombrePaciente;
    }
}

