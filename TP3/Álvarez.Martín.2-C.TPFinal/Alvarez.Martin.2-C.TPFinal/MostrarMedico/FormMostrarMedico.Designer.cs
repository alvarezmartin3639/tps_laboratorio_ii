
namespace MostrarMedico
{
    partial class frmAgMedico
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblidMedico = new System.Windows.Forms.Label();
            this.bttnHistorialAtencionesPaciente = new System.Windows.Forms.Button();
            this.lblHistorialDeAtencionesPaciente = new System.Windows.Forms.Label();
            this.lblSexoMedico = new System.Windows.Forms.Label();
            this.txtSexoMedico = new System.Windows.Forms.TextBox();
            this.lblEdadMedico = new System.Windows.Forms.Label();
            this.txtEdadMedico = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.lblNombreMedico = new System.Windows.Forms.Label();
            this.txtNombreMedico = new System.Windows.Forms.TextBox();
            this.lblMatriculaMedico = new System.Windows.Forms.Label();
            this.txtMatriculaMedico = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.panel1.Controls.Add(this.lblidMedico);
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(315, 26);
            this.panel1.TabIndex = 100;
            // 
            // lblidMedico
            // 
            this.lblidMedico.AutoSize = true;
            this.lblidMedico.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblidMedico.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblidMedico.Location = new System.Drawing.Point(105, 4);
            this.lblidMedico.Name = "lblidMedico";
            this.lblidMedico.Size = new System.Drawing.Size(84, 18);
            this.lblidMedico.TabIndex = 41;
            this.lblidMedico.Text = "Paciente id ";
            // 
            // bttnHistorialAtencionesPaciente
            // 
            this.bttnHistorialAtencionesPaciente.BackColor = System.Drawing.Color.Teal;
            this.bttnHistorialAtencionesPaciente.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bttnHistorialAtencionesPaciente.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bttnHistorialAtencionesPaciente.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bttnHistorialAtencionesPaciente.Location = new System.Drawing.Point(260, 193);
            this.bttnHistorialAtencionesPaciente.Name = "bttnHistorialAtencionesPaciente";
            this.bttnHistorialAtencionesPaciente.Size = new System.Drawing.Size(66, 23);
            this.bttnHistorialAtencionesPaciente.TabIndex = 120;
            this.bttnHistorialAtencionesPaciente.Text = "Ver mas";
            this.bttnHistorialAtencionesPaciente.UseVisualStyleBackColor = false;
            // 
            // lblHistorialDeAtencionesPaciente
            // 
            this.lblHistorialDeAtencionesPaciente.AutoSize = true;
            this.lblHistorialDeAtencionesPaciente.Font = new System.Drawing.Font("Georgia", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblHistorialDeAtencionesPaciente.Location = new System.Drawing.Point(18, 193);
            this.lblHistorialDeAtencionesPaciente.Name = "lblHistorialDeAtencionesPaciente";
            this.lblHistorialDeAtencionesPaciente.Size = new System.Drawing.Size(155, 17);
            this.lblHistorialDeAtencionesPaciente.TabIndex = 118;
            this.lblHistorialDeAtencionesPaciente.Text = "Historial de atenciones:";
            // 
            // lblSexoMedico
            // 
            this.lblSexoMedico.AutoSize = true;
            this.lblSexoMedico.Font = new System.Drawing.Font("Georgia", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSexoMedico.Location = new System.Drawing.Point(17, 122);
            this.lblSexoMedico.Name = "lblSexoMedico";
            this.lblSexoMedico.Size = new System.Drawing.Size(43, 17);
            this.lblSexoMedico.TabIndex = 112;
            this.lblSexoMedico.Text = "Sexo:";
            // 
            // txtSexoMedico
            // 
            this.txtSexoMedico.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSexoMedico.Location = new System.Drawing.Point(137, 123);
            this.txtSexoMedico.Name = "txtSexoMedico";
            this.txtSexoMedico.Size = new System.Drawing.Size(187, 16);
            this.txtSexoMedico.TabIndex = 113;
            // 
            // lblEdadMedico
            // 
            this.lblEdadMedico.AutoSize = true;
            this.lblEdadMedico.Font = new System.Drawing.Font("Georgia", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblEdadMedico.Location = new System.Drawing.Point(17, 84);
            this.lblEdadMedico.Name = "lblEdadMedico";
            this.lblEdadMedico.Size = new System.Drawing.Size(44, 17);
            this.lblEdadMedico.TabIndex = 110;
            this.lblEdadMedico.Text = "Edad:";
            // 
            // txtEdadMedico
            // 
            this.txtEdadMedico.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEdadMedico.Location = new System.Drawing.Point(138, 85);
            this.txtEdadMedico.Name = "txtEdadMedico";
            this.txtEdadMedico.Size = new System.Drawing.Size(187, 16);
            this.txtEdadMedico.TabIndex = 111;
            // 
            // button3
            // 
            this.button3.AccessibleName = "btnModificarJugador";
            this.button3.BackColor = System.Drawing.Color.Teal;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button3.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button3.Location = new System.Drawing.Point(191, 241);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(66, 23);
            this.button3.TabIndex = 109;
            this.button3.Text = "Modificar";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Teal;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button4.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button4.Location = new System.Drawing.Point(119, 241);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(66, 23);
            this.button4.TabIndex = 106;
            this.button4.Text = "Agregar";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Teal;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button5.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button5.Location = new System.Drawing.Point(16, 241);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(97, 23);
            this.button5.TabIndex = 108;
            this.button5.Text = "Nuevo paciente";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Teal;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button6.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button6.Location = new System.Drawing.Point(263, 241);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(66, 23);
            this.button6.TabIndex = 107;
            this.button6.Text = "Borrar";
            this.button6.UseVisualStyleBackColor = false;
            // 
            // lblNombreMedico
            // 
            this.lblNombreMedico.AutoSize = true;
            this.lblNombreMedico.Font = new System.Drawing.Font("Georgia", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNombreMedico.Location = new System.Drawing.Point(17, 52);
            this.lblNombreMedico.Name = "lblNombreMedico";
            this.lblNombreMedico.Size = new System.Drawing.Size(64, 17);
            this.lblNombreMedico.TabIndex = 101;
            this.lblNombreMedico.Text = "Nombre:";
            // 
            // txtNombreMedico
            // 
            this.txtNombreMedico.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNombreMedico.Location = new System.Drawing.Point(140, 52);
            this.txtNombreMedico.Name = "txtNombreMedico";
            this.txtNombreMedico.Size = new System.Drawing.Size(187, 16);
            this.txtNombreMedico.TabIndex = 104;
            // 
            // lblMatriculaMedico
            // 
            this.lblMatriculaMedico.AutoSize = true;
            this.lblMatriculaMedico.Font = new System.Drawing.Font("Georgia", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMatriculaMedico.Location = new System.Drawing.Point(18, 156);
            this.lblMatriculaMedico.Name = "lblMatriculaMedico";
            this.lblMatriculaMedico.Size = new System.Drawing.Size(76, 17);
            this.lblMatriculaMedico.TabIndex = 121;
            this.lblMatriculaMedico.Text = "Matricula: ";
            // 
            // txtMatriculaMedico
            // 
            this.txtMatriculaMedico.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMatriculaMedico.Location = new System.Drawing.Point(138, 157);
            this.txtMatriculaMedico.Name = "txtMatriculaMedico";
            this.txtMatriculaMedico.Size = new System.Drawing.Size(187, 16);
            this.txtMatriculaMedico.TabIndex = 122;
            // 
            // frmAgMedico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(342, 272);
            this.Controls.Add(this.lblMatriculaMedico);
            this.Controls.Add(this.txtMatriculaMedico);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bttnHistorialAtencionesPaciente);
            this.Controls.Add(this.lblHistorialDeAtencionesPaciente);
            this.Controls.Add(this.lblSexoMedico);
            this.Controls.Add(this.txtSexoMedico);
            this.Controls.Add(this.lblEdadMedico);
            this.Controls.Add(this.txtEdadMedico);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.lblNombreMedico);
            this.Controls.Add(this.txtNombreMedico);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "frmAgMedico";
            this.Text = "Información del medico";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblidMedico;
        private System.Windows.Forms.Button bttnHistorialAtencionesPaciente;
        private System.Windows.Forms.Label lblHistorialDeAtencionesPaciente;
        private System.Windows.Forms.Label lblSexoMedico;
        private System.Windows.Forms.TextBox txtSexoMedico;
        private System.Windows.Forms.Label lblEdadMedico;
        private System.Windows.Forms.TextBox txtEdadMedico;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label lblNombreMedico;
        private System.Windows.Forms.TextBox txtNombreMedico;
        private System.Windows.Forms.Label lblMatriculaMedico;
        private System.Windows.Forms.TextBox txtMatriculaMedico;
    }
}

