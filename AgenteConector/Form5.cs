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
    public partial class Form5 : Form
    {
        public static string gbDB;
        public static string gbUser;
        public static string gbPass;
        public static string gbInstance;
        public static string gbName;
        public static string gbModulo;

        public Form5(String instance, String db, String user, String password, String name, String modulo)
        {
            InitializeComponent();
            gbInstance = instance;
            gbDB = db;
            gbUser = user;
            gbPass = password;
            gbName = name;
            gbModulo = modulo;
        }

        private void Form5_Load(object sender, EventArgs e)
        {

            comboBox1.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
         if (textBox1.Text != "") {

                if (comboBox1.SelectedItem.ToString() != null)
                {
                    button3.Enabled = true;
                }else {
                    button3.Enabled = false;
                }
            }else{
                button3.Enabled = false;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {

                if (comboBox1.SelectedItem.ToString() != null)
                {
                    button3.Enabled = true;
                }else{
                    button3.Enabled = false;
                }
            }else{
                button3.Enabled = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {

                if (comboBox1.SelectedItem.ToString() != null)
                {
                    button3.Enabled = true;
                }
                else
                {
                    button3.Enabled = false;
                }
            }
            else
            {
                button3.Enabled = false;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form form6 = new Form6(gbInstance, gbDB, gbUser, gbPass, gbName, gbModulo, textBox1.Text, comboBox1.SelectedItem.ToString(), dateTimePicker1.ToString());
            form6.ShowDialog();
            this.Hide();
        }
    }
}
