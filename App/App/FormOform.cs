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
    public partial class FormOform : Form
    {
        SqlConnection connection = new SqlConnection(Properties.Settings.Default.dbConnectionSettings);
        

        public FormOform()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open();


        }

        private void FormOform_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bragarDataSet.izdeliya' table. You can move, or remove it, as needed.
            this.izdeliyaTableAdapter.Fill(this.bragarDataSet.izdeliya);

        }
    }
}
