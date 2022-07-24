
namespace MenuPrincipal
{
    partial class frmVentanaEmergenteConInputBoxSimple
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVentanaEmergenteConInputBoxSimple));
            this.lblTextoPidiendoAlgo = new System.Windows.Forms.Label();
            this.txtInformacionEscrita = new System.Windows.Forms.TextBox();
            this.bttnAceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTextoPidiendoAlgo
            // 
            this.lblTextoPidiendoAlgo.AutoSize = true;
            this.lblTextoPidiendoAlgo.Location = new System.Drawing.Point(12, 22);
            this.lblTextoPidiendoAlgo.Name = "lblTextoPidiendoAlgo";
            this.lblTextoPidiendoAlgo.Size = new System.Drawing.Size(111, 15);
            this.lblTextoPidiendoAlgo.TabIndex = 0;
            this.lblTextoPidiendoAlgo.Text = "Texto pidiendo algo";
            // 
            // txtInformacionEscrita
            // 
            this.txtInformacionEscrita.Location = new System.Drawing.Point(12, 51);
            this.txtInformacionEscrita.Name = "txtInformacionEscrita";
            this.txtInformacionEscrita.Size = new System.Drawing.Size(272, 23);
            this.txtInformacionEscrita.TabIndex = 1;
            // 
            // bttnAceptar
            // 
            this.bttnAceptar.Location = new System.Drawing.Point(109, 94);
            this.bttnAceptar.Name = "bttnAceptar";
            this.bttnAceptar.Size = new System.Drawing.Size(75, 23);
            this.bttnAceptar.TabIndex = 2;
            this.bttnAceptar.Text = "Aceptar";
            this.bttnAceptar.UseVisualStyleBackColor = true;
            this.bttnAceptar.Click += new System.EventHandler(this.bttnAceptar_Click);
            // 
            // frmVentanaEmergenteConInputBoxSimple
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(295, 129);
            this.Controls.Add(this.bttnAceptar);
            this.Controls.Add(this.txtInformacionEscrita);
            this.Controls.Add(this.lblTextoPidiendoAlgo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmVentanaEmergenteConInputBoxSimple";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Titulo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTextoPidiendoAlgo;
        private System.Windows.Forms.TextBox txtInformacionEscrita;
        private System.Windows.Forms.Button bttnAceptar;
    }
}

