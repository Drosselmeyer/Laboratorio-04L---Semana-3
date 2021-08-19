using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio_04L___Semana_3
{
    public partial class Form1 : Form
    {
        string mensaje;
        int contar = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //El evento se ejecuta al cargar el formulario
            mensaje = "Aun no ha presionado boton contar";
            lblMensaje.Text = mensaje;
        }

        private void btnContar_Click(object sender, EventArgs e)
        {
            //int contar = 0;
            contar = contar + 1;

            mensaje = "Presiono el boton contar, un total de " + Convert.ToString(contar) + " veces";
            lblMensaje.Text = mensaje;
        }

        private void btnReinicio_Click(object sender, EventArgs e)
        {
            
            contar = 0;

            mensaje = "Presiono el boton contar, un total de " + Convert.ToString(contar) + " veces";
            lblMensaje.Text = mensaje;
        }

        private void btnFin_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
