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
    public partial class AddMgf : Form
    {
        public AddMgf()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Utilities.ResetAllControls(this);
        }

        static string connectionString = "User Id=hr;Password=hr;Data Source=localhost:1521/orcl";

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.textBox1.Text) || string.IsNullOrWhiteSpace(this.textBox2.Text) || string.IsNullOrWhiteSpace(richTextBox1.Text))
            {
                MessageBox.Show("Fill all the requierd field correctly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    using (OracleConnection conn = new OracleConnection(connectionString))
                    {
                        conn.Open();
                        string sqlquery = "INSERT INTO MFG_INFO(MGF_NAME,MFG_ADD,MFG_PHN) VALUES('" + textBox1.Text +
                                          "','" + richTextBox1.Text + "','" + textBox2.Text + "')";
                        OracleCommand cmd = new OracleCommand(sqlquery, conn);
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            cmd.Dispose();
                            this.Hide();
                            adminControls adc = new adminControls();
                            adc.Show();
                        } 
                    }
                    
                }
                catch (Exception exe)
                {
                    MessageBox.Show(exe.Message);
                }
            }
        }

        private void AddMgf_FormClosing(object sender, FormClosingEventArgs e)
        {
            adminControls adm = new adminControls();
            adm.Show();
            this.Hide();
        }
    }
}
