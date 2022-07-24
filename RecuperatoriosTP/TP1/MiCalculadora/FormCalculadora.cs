using Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        private readonly IEnumerable<string> array;


        /// <summary>
        /// Muestra messagebox para cierre del windows form al apretar btnCerrar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea cerrar?", "Intentando cerrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Dispose();
            }

        }

        /// <summary>
        /// Convierte de decimal a binario al apretar btnConvertirABinario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (lblResultado.Text != "Valor inválido" || lblResultado.Text != "0")
            {
                lblResultado.Text = Operando.DecimalBinario(lblResultado.Text);
            }
        }


        /// <summary>
        /// Convierte de binario a decimal al apretar btnConvertirADecimal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (lblResultado.Text != "Valor inválido" || lblResultado.Text != "0")
            {
                lblResultado.Text = Operando.BinarioDecimal(lblResultado.Text);
            }


        }



        /// <summary>
        /// Limpia todos los label,listbox y combobox al clickear btnLimpiar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar(sender, e);
        }




        /// <summary>
        /// Resuelve operaciones aritmeticas al clickear btnOperar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultadoOperacion;

            if (int.TryParse(txtNumero1.Text, out _) == false
                || int.TryParse(txtNumero2.Text, out _) == false
                || cmbOperador.Text == string.Empty
                || txtNumero1.Text == string.Empty
                || txtNumero2.Text == string.Empty)
            {
                MessageBox.Show("No se llenó el formulario correctamente.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                resultadoOperacion = FormCalculadora.Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);
                //MOSTRAR OPERACION Y RESULTADO
                lstOperaciones.Items.Add(txtNumero1.Text + " " + cmbOperador.Text + " " + txtNumero2.Text + " = " 
                   + Convert.ToString(resultadoOperacion));

                if (resultadoOperacion == double.MinValue)
                {
                    lblResultado.Text = "Valor inválido";
                }
                else
                {
                    lblResultado.Text = Convert.ToString(resultadoOperacion);
                }
            }

        }

     

        /// <summary>
        /// Constructor por defecto de FormCalculadora.
        /// </summary>
        public FormCalculadora()
        {
            InitializeComponent();
        }



        /// <summary>
        /// Constructor parametrizado de FormCalculadora.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            Limpiar(sender, e);

            cmbOperador.Items.Insert(0, string.Empty);
            cmbOperador.Items.Insert(1, "+");
            cmbOperador.Items.Insert(2, "-");
            cmbOperador.Items.Insert(3, "/");
            cmbOperador.Items.Insert(4, "*");
        }

        /// <summary>
        /// Muestra un messagebox de cierre antes de cerrar el form, permitiendo cancelar el evento de cierre.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea cerrar?", "Intentando cerrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                Dispose();
            }
        }

        /// <summary>
        /// Limpia los textbox, label, listbox y combobox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Limpiar(object sender, EventArgs e)
        {
            txtNumero1.Text = string.Empty;
            txtNumero2.Text = string.Empty;
            lblResultado.Text = "0";
            lstOperaciones.Items.Clear();
            cmbOperador.Text = string.Empty;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Operando numeroUno = new Operando(numero1); 
            Operando numeroDos = new Operando(numero2);

            return Calculadora.Operar(numeroUno, numeroDos, Convert.ToChar(operador)); 
        }

     
    }
}

