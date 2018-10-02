using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgenteConector
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿ESta seguro que desea desinstalar el programa?", "Desinstalación", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Iniciar Servicio") {
                button2.Text = "Detener Servicio";
                pictureBox1.Hide();
                pictureBox2.Show();
                button1.Enabled = true;
            }
            else if(button2.Text == "Detener Servicio")
            {
                button2.Text = "Iniciar Servicio";
                pictureBox1.Show();
                pictureBox2.Hide();
                button1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form frm2 = new Form2();
            frm2.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //AgenteConector.WebServiceLicenses ws = new AgenteConector.WebServiceLicenses();
           // ws.Credentials = System.Net.CredentialCache.DefaultCredentials;
            //ws.PreAuthenticate = true;
            //ws.ConsultaIndividualSUCIS(tipoID, numID);

            button2.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = false;
            button6.Enabled = true;
            button7.Enabled = true;
        }
    }
}
