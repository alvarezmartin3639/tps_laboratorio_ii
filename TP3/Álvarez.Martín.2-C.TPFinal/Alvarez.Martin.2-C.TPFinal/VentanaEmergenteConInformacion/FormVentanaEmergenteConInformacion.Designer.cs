
namespace VentanaEmergenteConInformacion
{
    partial class frmVentanaEmergenteConInformacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVentanaEmergenteConInformacion));
            this.rtbInformacionPedida = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtbInformacionPedida
            // 
            this.rtbInformacionPedida.Location = new System.Drawing.Point(0, 2);
            this.rtbInformacionPedida.Name = "rtbInformacionPedida";
            this.rtbInformacionPedida.Size = new System.Drawing.Size(520, 352);
            this.rtbInformacionPedida.TabIndex = 0;
            this.rtbInformacionPedida.Text = "";
            // 
            // frmVentanaEmergenteConInformacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(521, 355);
            this.Controls.Add(this.rtbInformacionPedida);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "frmVentanaEmergenteConInformacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmVentanaEmergenteConInformacion_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbInformacionPedida;
    }
}

