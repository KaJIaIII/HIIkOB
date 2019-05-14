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
    public partial class FormDobtkan : Form
    {
        String filename;
        SqlConnection connection = new SqlConnection(Properties.Settings.Default.dbConnectionSettings);

        public FormDobtkan()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "JPEG images|*.jpg";
            openFileDialog1.InitialDirectory = "C:\\Users\\lickett2019\\Downloads";
            openFileDialog1.Title = "Выбрать картинку";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filename = openFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open();
            try
            {
                SqlCommand command = new SqlCommand("INSERT INTO tkani (name,articul) VALUES (@name,'" + filename + "')", connection);
                command.Parameters.AddWithValue("@name", textBox1.Text);
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Ткань успешно добавлена!\n");
            }
            catch
            {
                MessageBox.Show("Ошибка при добавлении ткани!\n");

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form form = new Form();
            switch (App.Global.Role)
            {
                case "User":
                    form = new UserForm();
                    break;
                case "Director":
                    form = new AdminForm();
                    break;
                case "Ware":
                    form = new WareForm();
                    break;
                case "Manager":
                    form = new ManagerForm();
                    break;
            }

            this.Hide();
            form.Show();
        }
    }
}
