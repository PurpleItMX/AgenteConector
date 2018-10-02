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
    public partial class Form3 : Form
    {

        public static string connDsnName;
        public static string connDsn;
        public static string connUser;
        public static string connPassword;

        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                if (textBox1.Text != "")
                {
                    if(textBox2.Text != "")
                    {
                        connDsn = comboBox1.SelectedItem.ToString();
                        connUser = textBox1.Text;
                        connPassword = textBox2.Text;

                        connDsnName = "DSN=" + comboBox1.SelectedItem.ToString() + "; Uid=" + textBox1.Text + "; Pwd=" + textBox2.Text + ";";
                        using (System.Data.Odbc.OdbcConnection conn = new System.Data.Odbc.OdbcConnection(connDsnName))
                        {
                            try
                            {
                                conn.Open();
                                System.Data.Odbc.OdbcCommand command = new System.Data.Odbc.OdbcCommand("select getDate()", conn);
                                command.ExecuteNonQuery();
                            }
                            catch (Exception ex){
                                MessageBox.Show("ODBC Conexión Fallida revise los datos");
                                Console.WriteLine("ODBC Connection test failed!!!!");
                                Console.WriteLine(ex.Message);
                                conn.Close();
                                return;

                            }
                            MessageBox.Show("ODBC Conexión Satisfatoria");
                            Console.WriteLine("ODBC Connection test PASSED!");
                            conn.Close();
                            button3.Enabled = true;
                        }
                    }
                    else {
                        MessageBox.Show("Es necesario rellenar el campo de Password");
                    }

                }
                else {
                   MessageBox.Show("Es necesario rellenar el campo de Usuario");
                }
            }else{
                MessageBox.Show("Seleccione un OBDC");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form frm4 = new Form4(connDsnName, connDsn, connUser, connPassword);
            frm4.ShowDialog();
            
            this.Hide();
        }

        //para tipo de DNS (ODBC) 
        public enum DataSourceType { System, User }

        private void Form3_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            SortedList listaODBC = new System.Collections.SortedList();
            Microsoft.Win32.RegistryKey reg =
                (Microsoft.Win32.Registry.CurrentUser).OpenSubKey("Software");
            if (reg != null)
            {
                reg = reg.OpenSubKey("ODBC");
                if (reg != null)
                {
                    reg = reg.OpenSubKey("ODBC.INI");
                    if (reg != null)
                    {
                        reg = reg.OpenSubKey("ODBC Data Sources");
                        if (reg != null)
                        {
                            foreach (string sName in reg.GetValueNames())
                            {
                                listaODBC.Add(sName, DataSourceType.User);
                            }
                        }
                        try
                        {
                            reg.Close();
                        }
                        catch { /* ignorar un posible error */ }
                    }
                }
            }

            //agrega lista de obdc a combo
            foreach (DictionaryEntry key in listaODBC)
            {
                comboBox1.Items.Add(key.Key.ToString());
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            button3.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button3.Enabled = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button3.Enabled = false;
        }
    }
}
