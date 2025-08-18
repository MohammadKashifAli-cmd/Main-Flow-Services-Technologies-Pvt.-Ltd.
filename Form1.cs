using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WinFormsDBConnection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    MessageBox.Show("\u2705 Database connection successful!",
                        "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    Homepage homepage = new Homepage();
                    homepage.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("\u274C Database connection failed! " + ex.Message,
                    "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
