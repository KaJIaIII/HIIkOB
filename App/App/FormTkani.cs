using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    public partial class FormTkani : Form
    {
        public FormTkani()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection(Properties.Settings.Default.dbConnectionSettings);
        Form form;

        private void button1_Click(object sender, EventArgs e)
        {
            

            this.Close();
            form = new AuthForm();
            form.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormTkani_Load(object sender, EventArgs e)
        {
            string query = "SELECT * FROM dbo.tkani";
            SqlDataAdapter sda = new SqlDataAdapter(query, connection);
            DataSet ds = new DataSet();
            sda.Fill(ds, "tkani");
            dataGridView1.DataSource = ds.Tables["tkani"];

        }
    }
}
