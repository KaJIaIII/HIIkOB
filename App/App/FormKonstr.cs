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
        Form form = new Form();
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
            string rand = Convert.ToString(DateTime.Now);
            connection.Open();

            SqlCommand command = new SqlCommand("INSERT INTO izdeliya (name,weight,length,articul) VALUES (@name,@weight,@lenght,@articul)", connection);
            command.Parameters.AddWithValue("@name", textBox1.Text);
            command.Parameters.AddWithValue("@weight", textBox3.Text);
            command.Parameters.AddWithValue("@lenght", textBox2.Text);
            command.Parameters.AddWithValue("@articul", rand);
            int regged = Convert.ToInt32(command.ExecuteNonQuery());

         

            SqlCommand commandr = new SqlCommand("SELECT max(id) FROM izdeliya", connection);
            SqlDataReader reader = commandr.ExecuteReader();

            string id = "";
            while (reader.Read())
            {
                id = reader[0].ToString();
            }

            connection.Close();
            connection.Open();

            SqlCommand command1 = new SqlCommand("INSERT INTO [tkani izdeliya] ([article tkani],[article izdeliya]) VALUES (@artk,@ariz)", connection);
            command1.Parameters.AddWithValue("@artk", comboBox1.Text);
            command1.Parameters.AddWithValue("@ariz", id);
            int regged1 = Convert.ToInt32(command1.ExecuteNonQuery());

            SqlCommand command2 = new SqlCommand("INSERT INTO [furnitura izdeliya] ([artikul furn],[artikul izdel],width,length,kolichestvo) VALUES (@arfu,@ariz,@width,@lenght,@kolvo)", connection);
            command2.Parameters.AddWithValue("@arfu", comboBox2.Text);
            command2.Parameters.AddWithValue("@ariz", id);
            command2.Parameters.AddWithValue("@width", textBox3.Text);
            command2.Parameters.AddWithValue("@lenght", textBox2.Text);
            command2.Parameters.AddWithValue("@kolvo", "1");
            int regged2 = Convert.ToInt32(command2.ExecuteNonQuery());

            connection.Close();
            MessageBox.Show("Изделие добавлено\n");
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Shir = Convert.ToInt16(textBox2.Text);
            Vis = Convert.ToInt16(textBox3.Text);
            Draw();
        }

        private void button3_Click(object sender, EventArgs e)
        {
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
