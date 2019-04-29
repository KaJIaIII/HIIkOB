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
    public partial class FormFurnitura : Form
    {
        public FormFurnitura()
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

        private void FormFurnitura_Load(object sender, EventArgs e)
        {
            string query = "SELECT * FROM dbo.furnitura";
            SqlDataAdapter sda = new SqlDataAdapter(query, connection);
            DataSet ds = new DataSet();
            sda.Fill(ds, "furnitura");
            dataGridView1.DataSource = ds.Tables["furnitura"];
        }
    }
}
