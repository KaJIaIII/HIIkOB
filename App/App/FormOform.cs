using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    public partial class FormOform : Form
    {
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

        }
    }
}
