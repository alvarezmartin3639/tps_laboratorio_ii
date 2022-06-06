using System;
using System.Windows.Forms;

namespace VentanaEmergenteConInputBoxSimple
{
    public partial class frmVentanaEmergenteConInputBoxSimple : Form
    {
        private string informacionEscrita;

        #region CONSTRUCTORES Y PROPIEDADES

        /// <summary>
        /// 
        /// </summary>
        public frmVentanaEmergenteConInputBoxSimple() : this("Ingresar dato", "Porfavor ingrese el dato solicitado")
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tituloDelForm"></param>
        /// <param name="textoPidiendoDatos"></param>
        public frmVentanaEmergenteConInputBoxSimple(string tituloDelForm, string textoPidiendoDatos)
        {
            InitializeComponent();
            this.Text = tituloDelForm;
            this.lblTextoPidiendoAlgo.Text = textoPidiendoDatos;
        }

        /// <summary>
        /// 
        /// </summary>
        public string InformacionEscrita { get => informacionEscrita; set => informacionEscrita = value; }

        #endregion


        #region EVENTOS BUTTONS

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bttnAceptar_Click(object sender, EventArgs e)
        {
            informacionEscrita = this.txtInformacionEscrita.Text;
            this.Close();
        }

        #endregion


    }
}
