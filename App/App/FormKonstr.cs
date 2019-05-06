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
    public partial class FormKonstr : Form
    {
        SqlConnection connection = new SqlConnection(Properties.Settings.Default.dbConnectionSettings);


        public FormKonstr()
        {
            InitializeComponent();
        }

        private void FormKonstr_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Draw();
        }
        public void Draw()
        {
            Graphics g = panel1.CreateGraphics();
            g.Clear(Color.White);
            Pen pen = new Pen(Color.Black, 3);
            g.DrawRectangle(pen, 25, 25, 300, 500);
        }

       
        private void FormKonstr_Load(object sender, EventArgs e)
        {

        }
    }
}
