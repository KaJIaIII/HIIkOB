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
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
        }
        Form form;

        private void button1_Click(object sender, EventArgs e)
        {
            
           
            this.Close();
            form = new AuthForm();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            form = new FormTkani();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            form = new FormFurnitura();
            form.Show();
        }
    }
}
