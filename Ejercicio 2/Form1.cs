using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_2
{
    public partial class Form1 : Form
    {

        //Variables globales
        double TasaI = 0.12;


        //Validación
        public static Boolean IsNumeric(string valor)
        {
            double result;
            return double.TryParse(valor, out result);
        }
        
        public Form1()
        {
            InitializeComponent();
        }

        private void rdbInteres3_CheckedChanged(object sender, EventArgs e)
        {
            if(rdbInteres3.Checked == true)
            {
                txtTasaInteresEx.Enabled = true;
                txtTasaInteresEx.Focus();
            }
            else
            {
                txtTasaInteresEx.Text = "0";
                txtTasaInteresEx.Enabled = false;
            }
        }

        private void rdbInteres1_Click(object sender, EventArgs e)
        {
            TasaI = 0.12;
        }

        private void rdbInteres2_Click(object sender, EventArgs e)
        {
            TasaI = 0.235;
        }

        private void btnFin_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAnalisis_Click(object sender, EventArgs e)
        {
            //Declaramos variables
            string NomEmpre;
            double MontoInic = 0, MontoFin = 0;
            int Tiempo;

            NomEmpre = txtEmpresa.Text;
            NomEmpre = NomEmpre.Trim();

            if(NomEmpre.Length == 0)
            {
                MessageBox.Show("Debe indicar el nombre de la empresa", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmpresa.Focus();
                return;
            }
            if (!(IsNumeric(txtMonto.Text)))
            {
                MessageBox.Show("Valor de monto incorrecto", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMonto.Focus();
                return;
            }
            else
            {
                MontoInic = Convert.ToDouble(txtMonto.Text);
                if (!(MontoInic > 0))
                {
                    MessageBox.Show("Valor del monto no puede ser negativo", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMonto.Focus();
                    return;
                }
            }

            Tiempo = Convert.ToInt32(txtTiempo.Text);

            txtTasaInteresEx.Text = txtTasaInteresEx.Text.Trim();

            if(rdbInteres3.Checked == true)
            {
                if(txtTasaInteresEx.Text.Length > 0)
                {
                    if(!(IsNumeric(txtTasaInteresEx.Text)== true))
                    {
                        MessageBox.Show("Tasa interes incorrecto", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtTasaInteresEx.Text = "0";
                        txtTasaInteresEx.Focus();
                        return;
                    }
                    TasaI = Convert.ToDouble(txtTasaInteresEx.Text) / 100;
                }

                else
                {
                    MessageBox.Show("Aun no han indicado una tasa de interes", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTasaInteresEx.Focus();
                }
            }

            MontoFin = (1 + TasaI);
            MontoFin = MontoInic * (Math.Pow(Convert.ToDouble(MontoFin), Tiempo));
            //TasaI *= 100;

            lstResult.Items.Clear();
            lstResult.Items.Add("Empresa: " + txtEmpresa.Text);
            lstResult.Items.Add("Monto: $" + MontoInic + ", Tasa anual: " + TasaI*100);
            lstResult.Items.Add("Monto a pagar: $" + MontoFin); 


        }
    }
}
