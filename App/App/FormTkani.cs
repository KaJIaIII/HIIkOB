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
    public partial class FormTkani : Form
    {
        public FormTkani()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection(Properties.Settings.Default.dbConnectionSettings);
        Form form;
        DataSet ds;
        SqlDataAdapter sda;

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
            MessageBox.Show(App.Global.Role);
            string query = "SELECT * FROM dbo.tkani";
            sda = new SqlDataAdapter(query, connection);
            ds = new DataSet();
            sda.Fill(ds, "tkani");
            dataGridView1.DataSource = ds.Tables["tkani"];

            DataGridViewImageColumn img = new DataGridViewImageColumn();
            img.Name = "img";
            img.HeaderText = "Картинка";
            dataGridView1.Columns.Add(img);
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].Cells[1].Value != null)
                {
                    string basePath = "C:/Users/User12/Git/izobr/";
                    string filename = dataGridView1.Rows[i].Cells[1].Value.ToString() + ".jpg";
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

        private void button2_Click(object sender, EventArgs e)
        {
            DataSet changes = this.ds.GetChanges();
            if (changes != null)
            {
                SqlCommandBuilder builder = new SqlCommandBuilder(sda);
                builder.GetInsertCommand();

                int updatesRows = this.sda.Update(changes,"tkani");
                this.ds.AcceptChanges();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow items in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.RemoveAt(items.Index);
            }
            this.button2_Click(sender, e);
        }
    }
}
