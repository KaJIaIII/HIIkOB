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
    public partial class AuthForm : Form
    {

        Form reg;

        public AuthForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
          

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            reg = new RegForm();
            reg.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
