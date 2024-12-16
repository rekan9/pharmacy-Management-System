using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace pharmacymansys
{
    public partial class NewGrp : Form
    {
        public NewGrp()
        {
            InitializeComponent();
        }

        static string connectionString = "User Id=hr;Password=hr;Data Source=localhost:1521/orcl";


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    if (string.IsNullOrWhiteSpace(this.textBox1.Text))
                    {
                        MessageBox.Show("Fill the Group name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (conn.State != ConnectionState.Open)
                        {
                            conn.Open();
                        }

                        OracleCommand cmd = new OracleCommand(
                            "INSERT INTO MED_GROUP(GNAME,GDESCRIPTION,NOTES) VALUES('" + textBox1.Text + "','" +
                            richTextBox1.Text + "','" + richTextBox2.Text + "')", conn);
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            MessageBox.Show("Information Uploaded...");
                            this.Close();
                        }
                    }

                    conn.Close();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}