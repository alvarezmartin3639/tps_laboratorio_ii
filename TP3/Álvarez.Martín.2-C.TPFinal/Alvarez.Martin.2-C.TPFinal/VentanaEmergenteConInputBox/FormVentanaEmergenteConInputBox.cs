using System;
using System.Windows.Forms;

namespace VentanaEmergenteConInputBox
{
    public partial class frmVentanaEmergenteConInputBox : Form
    {
        public string informacionEscrita;
        public string backUpInformacionEscrita;

        #region CONSTRUCTORES Y PROPIEDADES
        /// <summary>
        /// Constructor del form frmVentanaEmergenteConInputBox, incializa los controles
        /// </summary>
        public frmVentanaEmergenteConInputBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor del form frmVentanaEmergenteConInputBox, incializa los controles, el titulo del form y el label pidiendo los datos
        /// </summary>
        /// <param name="tituloDelForm">El titulo del formulario </param>
        /// <param name="textoPidiendoDatos">El texto que se le va a dar al usuario para pedirle los datos </param>
        public frmVentanaEmergenteConInputBox(string tituloDelForm, string textoPidiendoDatos) : this(string.Empty, tituloDelForm, textoPidiendoDatos)
        {

        }

        /// <summary>
        /// Constructor del form frmVentanaEmergenteConInputBox, incializa los controles, el titulo del form , el label pidiendo los datos e imprime la información pasada en el parametro informacionEscritaAnterior
        /// </summary>
        /// <param name="informacionEscritaAnterior">La información que tenia escrita anteriormente</param>
        /// <param name="tituloDelForm">El titulo del formulario </param>
        /// <param name="textoPidiendoDatos">El texto que se le va a dar al usuario para pedirle los datos </param>
        public frmVentanaEmergenteConInputBox(string informacionEscritaAnterior, string tituloDelForm, string textoPidiendoDatos) : this()
        {
            this.informacionEscrita = informacionEscritaAnterior;
            this.Text = tituloDelForm;
            this.lblTextoPidiendoAlgo.Text = textoPidiendoDatos;
            this.rtbInformacionEscrita.Text = informacionEscritaAnterior;
        }

        #endregion

        #region EVENTOS BUTTONS

        /// <summary>
        /// Evento click de bttnAceptar, sobreescribe el atributo informacionEscrita por el texto de rtbInformacionEscrita
        /// </summary>
        /// <param name="sender">emisor del evento</param>
        /// <param name="e">Información de dicho evento</param>
        private void bttnAceptar_Click(object sender, EventArgs e)
        {
            this.informacionEscrita = rtbInformacionEscrita.Text;
            this.Close();
        }

        /// <summary>
        /// Evento click de bttnDeshacerCambios, da la oportunidad al usuario a deshacer los camibos del control rtbInformacionEscrita
        /// </summary>
        /// <param name="sender">emisor del evento</param>
        /// <param name="e">Información de dicho evento</param>
        private void bttnDeshacerCambios_Click(object sender, EventArgs e)
        {
            this.rtbInformacionEscrita.Text = this.backUpInformacionEscrita;
        }

        #endregion


    }
}
