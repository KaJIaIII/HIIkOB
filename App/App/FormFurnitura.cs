using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
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

            DataGridViewImageColumn img = new DataGridViewImageColumn();
            img.Name = "img";
            img.HeaderText = "Картинка";
            dataGridView1.Columns.Add(img);
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Value != null)
                {
                    string basePath = "C:/Users/User12/Git/izobr/";
                    string filename = dataGridView1.Rows[i].Cells[0].Value.ToString() + ".jpg";
                    string fullPath = basePath + filename;
                    Image image;
                    if (File.Exists(fullPath))
                    {
                        image = Image.FromFile(fullPath);
                    }
                    else
                    {
                        image = Image.FromFile(basePath + "empty.jpg");
                    }
                    dataGridView1.Rows[i].Cells["img"].Value = image;
                }
            }
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }
    }
}
