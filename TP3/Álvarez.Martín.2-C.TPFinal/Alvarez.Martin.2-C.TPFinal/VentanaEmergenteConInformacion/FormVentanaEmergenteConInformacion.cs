using System;
using System.Windows.Forms;

namespace VentanaEmergenteConInformacion
{
    public partial class frmVentanaEmergenteConInformacion : Form
    {
        private string informacionMostrada;
        private string tituloDelForm;

        #region CONSTRUCTOR Y PROPIEDADES

        /// <summary>
        /// Constructor del form frmVentanemergenteConInformacion, inicializa los controles
        /// </summary>
        public frmVentanaEmergenteConInformacion()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor del form frmVentanemergenteConInformacion, incializa los controles, el titulo del form y la información mostrada
        /// </summary>
        /// <param name="informacionParaMostrar"></param>
        /// <param name="tituloParaMostrar"></param>
        public frmVentanaEmergenteConInformacion(string informacionParaMostrar, string tituloParaMostrar) : this()
        {
            this.tituloDelForm = tituloParaMostrar;
            this.informacionMostrada = informacionParaMostrar;
        }

        #endregion

        #region EVENTO FORM

        /// <summary>
        /// Evento load del form
        /// </summary>
        /// <param name="sender">emisor del evento</param>
        /// <param name="e">Información de dicho evento</param>
        private void frmVentanaEmergenteConInformacion_Load(object sender, EventArgs e)
        {
            this.Text = tituloDelForm;
            this.rtbInformacionPedida.Text = this.informacionMostrada;
        }

        #endregion

    }
}
