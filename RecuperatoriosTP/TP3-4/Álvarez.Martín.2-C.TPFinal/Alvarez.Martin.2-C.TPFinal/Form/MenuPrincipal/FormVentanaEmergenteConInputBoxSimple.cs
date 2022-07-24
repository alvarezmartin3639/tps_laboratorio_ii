using System;
using System.Windows.Forms;

namespace MenuPrincipal
{
    public partial class frmVentanaEmergenteConInputBoxSimple : Form
    {
        private string informacionEscrita;

        #region CONSTRUCTORES Y PROPIEDADES

        /// <summary>
        /// Constructor sin parametros de frmVentanaEmergenteConInputBoxSimple, instancia el titulo y el label del form
        /// </summary>
        public frmVentanaEmergenteConInputBoxSimple() : this("Ingresar dato", "Porfavor ingrese el dato solicitado")
        {

        }

        /// <summary>
        /// Construye un frmVentanaEmergenteConInputBoxSimple, con el titulo y texto que pide el input
        /// </summary>
        /// <param name="tituloDelForm">El titulo del formulario </param>
        /// <param name="textoPidiendoDatos">El texto que aparece al pedir un dato</param>
        public frmVentanaEmergenteConInputBoxSimple(string tituloDelForm, string textoPidiendoDatos)
        {
            InitializeComponent();
            this.Text = tituloDelForm;
            this.lblTextoPidiendoAlgo.Text = textoPidiendoDatos;
        }

        /// <summary>
        /// Propiedad de informacionEscrita, permite pre-cargar una información escrita y retornar el valor
        /// </summary>
        public string InformacionEscrita { get => informacionEscrita; set => informacionEscrita = value; }

        #endregion


        #region EVENTOS BUTTONS

        /// <summary>
        /// Evento Click de aceptar, guarda lo escrito en la propiedad InformacionEscrita, luego se cierra
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
