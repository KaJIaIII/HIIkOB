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

        int Shir = 10;
        int Vis = 10;

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
            g.DrawRectangle(pen, 25, 25, Shir, Vis);
        }

       
        private void FormKonstr_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bragarDataSet.furnitura' table. You can move, or remove it, as needed.
            this.furnituraTableAdapter.Fill(this.bragarDataSet.furnitura);
            // TODO: This line of code loads data into the 'bragarDataSet.tkani' table. You can move, or remove it, as needed.
            this.tkaniTableAdapter.Fill(this.bragarDataSet.tkani);

        }

        public void fillCombos()
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("INSERT INTO izdeliya (name,weight,length,articul) VALUES (@name,@weight,@lenght,@articul)", connection);
            command.Parameters.AddWithValue("@name", textBox1.Text);
            command.Parameters.AddWithValue("@weight", textBox2.Text);
            command.Parameters.AddWithValue("@lenght", textBox3.Text);
            command.Parameters.AddWithValue("@articul", Convert.ToString(DateTime.Today));
            int regged = Convert.ToInt32(command.ExecuteNonQuery());
            connection.Close();
            MessageBox.Show("Изделие добавлено\n");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Shir = Convert.ToInt16(textBox2.Text);
            Vis = Convert.ToInt16(textBox3.Text);
            Draw();
        }
    }
}
