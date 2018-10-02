using System;
using System.Collections;
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
    public partial class Form4 : Form
    {

        public static string gbCn;
        public static string gbInstance;
        public static string gbDB;
        public static string gbUser;
        public static string gbPass;

        public Form4(String cn, String instance, String user, String pass)
        {
            InitializeComponent();
            gbCn = cn;
            gbInstance = instance;
            gbUser = user;
            gbPass = pass;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form frm5 = new Form5(gbInstance, gbDB, gbUser, gbPass, textBox1.Text, comboBox2.SelectedItem.ToString());
            frm5.ShowDialog();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            using (System.Data.Odbc.OdbcConnection conn = new System.Data.Odbc.OdbcConnection(gbCn))
            {
                try
                {
                    conn.Open();
                    System.Data.Odbc.OdbcCommand command = new System.Data.Odbc.OdbcCommand("SELECT name, database_id, create_date FROM sys.databases", conn);
                    System.Data.Odbc.OdbcDataReader reader = command.ExecuteReader();

                    //agrega nombre de base datos
                    comboBox3.Items.Clear();
                    while (reader.Read())
                    {
                        comboBox3.Items.Add(reader[0].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio un error al obtener las bases de datos");
                    Console.WriteLine("Ocurrio un error al obtener las bases de datos");
                    Console.WriteLine(ex.Message);
                    conn.Close();
                    this.Hide();
                }
                //MessageBox.Show("ODBC Conexión Satisfatoria");
                //onsole.WriteLine("ODBC Connection test PASSED!");
                conn.Close();
            }

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (comboBox2.SelectedItem.ToString() != "")
                {
                    button3.Enabled = true;
                }
                else
                {
                    button3.Enabled = false;
                }
            }
            else {
                button3.Enabled = false;
            }
            gbDB = comboBox3.SelectedItem.ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (comboBox3.SelectedItem.ToString() != "")
                {
                    button3.Enabled = true;
                }
                else
                {
                    button3.Enabled = false;
                }
            }
            else {
                button3.Enabled = false;
            }
                
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem.ToString() != ""){
                if (comboBox3.SelectedItem.ToString() != "")
                {
                    if (textBox1.Text != ""){
                        button3.Enabled = true;
                    }
                    else {
                        button3.Enabled = false;
                    }
                }else
                {
                    button3.Enabled = false;
                }
            }else { button3.Enabled = false;
            }
        }
    }
}
