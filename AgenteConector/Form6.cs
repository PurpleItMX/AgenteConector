using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AgenteConector
{
    public partial class Form6 : Form
    {
        public static string gbDB;
        public static string gbUser;
        public static string gbPass;
        public static string gbInstance;
        public static string gbName;
        public static string gbModulo;
        public static string gbDays;
        public static string gbPeriodicity;
        public static string gbTime;


        public Form6(String instance, String db, String user, String password, String name, String modulo, String Days, String Periodicity, String Time)
        {
            InitializeComponent();
            gbInstance = instance;
            gbDB = db;
            gbUser = user;
            gbPass = password;
            gbName = name;
            gbModulo = modulo;
            gbDays = Days;
            gbPeriodicity = Periodicity;
            gbTime = Time;
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "")
            {
                button4.Enabled = true;
            }
            else {
                button4.Enabled = false;
            }
                
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String connDsnName = "DSN="+gbInstance+"; DataBase="+gbDB+ ";Uid=" +gbUser+ "; Pwd="+gbPass+ ";";
            String SqlQuery = richTextBox1.Text;
            using (System.Data.Odbc.OdbcConnection conn = new System.Data.Odbc.OdbcConnection(connDsnName))
            {
                try
                {
                    conn.Open();
                    System.Data.Odbc.OdbcCommand command = new System.Data.Odbc.OdbcCommand(SqlQuery, conn);
                    System.Data.Odbc.OdbcDataReader reader= command.ExecuteReader();
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);
                    dataGridView1.DataSource = dataTable;
                    //DataTable schemaTable = reader.GetSchemaTable();

                    /*foreach (DataRow row in schemaTable.Rows)
                    {
                        foreach (DataColumn column in schemaTable.Columns)
                        {
                            Console.WriteLine(String.Format("{0} = {1}",
                               column.ColumnName, row[column]));
                        }
                    }*/
                    //dataGridView1.Update();
                    //while (reader.Read())
                    //{
                    //dataGridView1.Rows.Add("five", "six", "seven", "eight");
                    //MessageBox.Show(reader[0].ToString());
                    // MessageBox.Show(reader[1].ToString());
                    //}                  
                    dataGridView1.Update();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio un error al realalizar la consulta");
                    Console.WriteLine("Ocurrio un error al realalizar la consulta");
                    Console.WriteLine(ex.Message);
                    conn.Close();
                    this.Hide();
                }
                conn.Close();
                button3.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            MySqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                Console.WriteLine("Openning Connection ...");

                conn.Open();

                Console.WriteLine("Connection successful!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.Read();
            MessageBox.Show("Datos Guardados");
            this.Hide();
        }

    }
}
