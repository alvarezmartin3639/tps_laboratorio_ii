
namespace MenuPrincipal
{
    partial class frmVentanaEmergenteConInputBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVentanaEmergenteConInputBox));
            this.lblTextoPidiendoAlgo = new System.Windows.Forms.Label();
            this.bttnAceptar = new System.Windows.Forms.Button();
            this.rtbInformacionEscrita = new System.Windows.Forms.RichTextBox();
            this.bttnDeshacerCambios = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTextoPidiendoAlgo
            // 
            this.lblTextoPidiendoAlgo.AutoSize = true;
            this.lblTextoPidiendoAlgo.Location = new System.Drawing.Point(12, 19);
            this.lblTextoPidiendoAlgo.Name = "lblTextoPidiendoAlgo";
            this.lblTextoPidiendoAlgo.Size = new System.Drawing.Size(111, 15);
            this.lblTextoPidiendoAlgo.TabIndex = 0;
            this.lblTextoPidiendoAlgo.Text = "Texto pidiendo algo";
            // 
            // bttnAceptar
            // 
            this.bttnAceptar.Location = new System.Drawing.Point(12, 336);
            this.bttnAceptar.Name = "bttnAceptar";
            this.bttnAceptar.Size = new System.Drawing.Size(75, 23);
            this.bttnAceptar.TabIndex = 2;
            this.bttnAceptar.Text = "Aceptar";
            this.bttnAceptar.UseVisualStyleBackColor = true;
            this.bttnAceptar.Click += new System.EventHandler(this.bttnAceptar_Click);
            // 
            // rtbInformacionEscrita
            // 
            this.rtbInformacionEscrita.Location = new System.Drawing.Point(12, 37);
            this.rtbInformacionEscrita.Name = "rtbInformacionEscrita";
            this.rtbInformacionEscrita.Size = new System.Drawing.Size(520, 293);
            this.rtbInformacionEscrita.TabIndex = 4;
            this.rtbInformacionEscrita.Text = "";
            // 
            // bttnDeshacerCambios
            // 
            this.bttnDeshacerCambios.Location = new System.Drawing.Point(420, 336);
            this.bttnDeshacerCambios.Name = "bttnDeshacerCambios";
            this.bttnDeshacerCambios.Size = new System.Drawing.Size(112, 23);
            this.bttnDeshacerCambios.TabIndex = 5;
            this.bttnDeshacerCambios.Text = "Deshacer cambios";
            this.bttnDeshacerCambios.UseVisualStyleBackColor = true;
            this.bttnDeshacerCambios.Click += new System.EventHandler(this.bttnDeshacerCambios_Click);
            // 
            // frmVentanaEmergenteConInputBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(540, 361);
            this.Controls.Add(this.bttnDeshacerCambios);
            this.Controls.Add(this.rtbInformacionEscrita);
            this.Controls.Add(this.bttnAceptar);
            this.Controls.Add(this.lblTextoPidiendoAlgo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmVentanaEmergenteConInputBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Titulo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTextoPidiendoAlgo;
        private System.Windows.Forms.Button bttnAceptar;
        private System.Windows.Forms.RichTextBox rtbInformacionEscrita;
        private System.Windows.Forms.Button bttnDeshacerCambios;
    }
}

