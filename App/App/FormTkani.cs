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

            DataGridViewImageColumn img = new DataGridViewImageColumn();
            img.Name = "img";
            img.HeaderText = "Изображение";
            dataGridView1.Columns.Add(img);
            Image image;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                try
                {
                    string filename = dataGridView1.Rows[i].Cells[1].Value.ToString() + ".jpg";
                    if (i == 1)
                    {
                        MessageBox.Show(filename);
                    }
                    image = Image.FromFile(@"C:\Users\User12\Git\" + filename);
                }
                catch
                {
                    image = Image.FromFile(@"C:\Users\User12\Git\izobr\tkan1.jpg");
                }
                dataGridView1.Rows[i].Cells["img"].Value = image;
            }

            connection.Close();



        }
    }
}
