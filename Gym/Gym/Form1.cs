using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Gym
{
    public partial class Form1 : Form
    {
        DataSet ds;
        public Form1()
        {
            InitializeComponent();
            
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            NpgsqlConnection OpiConnection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=z7AEwer79;Database=OPIgym;");
            NpgsqlCommand TableConnection = new NpgsqlCommand();
            OpiConnection.Open();
            TableConnection.Connection = OpiConnection;
            TableConnection.CommandType = CommandType.Text;
            TableConnection.CommandText = "select * from coach";
            NpgsqlDataReader db = TableConnection.ExecuteReader();
            if (db.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(db);
                dataGridView1.DataSource = dt;
            }
            TableConnection.Dispose();
            OpiConnection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NpgsqlConnection OpiConnection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=z7AEwer79;Database=OPIgym;");
            NpgsqlCommand TableConnection = new NpgsqlCommand();
            OpiConnection.Open();
            TableConnection.Connection = OpiConnection;
            TableConnection.CommandType = CommandType.Text;
            TableConnection.CommandText = "select * from students";
            NpgsqlDataReader db = TableConnection.ExecuteReader();
            if (db.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(db);
                dataGridView1.DataSource = dt;
            }
            TableConnection.Dispose();
            OpiConnection.Close();
        }

        private void textSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            NpgsqlConnection OpiConnection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=z7AEwer79;Database=OPIgym;");
            NpgsqlCommand TableConnection = new NpgsqlCommand();
            OpiConnection.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select * from coach", OpiConnection);
            DataTable dt = new DataTable("coach");
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dt.DefaultView.RowFilter = String.Format("name_coach like '%" + textSearch.Text + "%'");
            TableConnection.Dispose();
            OpiConnection.Close();
        }

        private void textSeach2_KeyPress(object sender, KeyPressEventArgs e)
        {
            NpgsqlConnection OpiConnection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=z7AEwer79;Database=OPIgym;");
            NpgsqlCommand TableConnection = new NpgsqlCommand();
            OpiConnection.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select * from students", OpiConnection);
            DataTable dt = new DataTable("students");
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dt.DefaultView.RowFilter = String.Format("name_students like '%" + textSeach2.Text + "%'");

            TableConnection.Dispose();
            OpiConnection.Close();
        }

        private void textSearch_Click(object sender, EventArgs e)
        {
            textSeach2.Text = "";
        }

        private void textSeach2_Click(object sender, EventArgs e)
        {
            textSearch.Text = "";
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            //NpgsqlConnection OpiConnection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=z7AEwer79;Database=OPIgym;");
            //NpgsqlCommand TableConnection = new NpgsqlCommand();
            //OpiConnection.Open();
            
            //DataRow row = ds.Tables[0].NewRow(); // добавляем новую строку в DataTable
            //ds.Tables[0].Rows.Add(row);
            //TableConnection.Dispose();
            //OpiConnection.Close();
        }

        private void textSearch_KeyDown(object sender, KeyEventArgs e)
        {
            //NpgsqlConnection OpiConnection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=z7AEwer79;Database=OPIgym;");
            //NpgsqlCommand TableConnection = new NpgsqlCommand();
            //OpiConnection.Open();
            //TableConnection.CommandText = "SELECT name_coach, phone_coach from coach inner join students on coach.coach_id = students.fk_students_coach";
            //NpgsqlDataAdapter da = new NpgsqlDataAdapter("select * from students", OpiConnection);
            //DataTable dt = new DataTable("coach");
            //da.Fill(dt);
            //label4.Text = dt.Rows[0].Field<string>("name_coach");
            //label5.Text = dt.Rows[0].Field<string>("phone_coach");

        }
    }
}
