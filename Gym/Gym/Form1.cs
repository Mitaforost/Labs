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
        NpgsqlDataAdapter adapter;
        NpgsqlCommandBuilder commandBuilder;
        DataTable dt;
        string connectionString = @"Server=localhost;Port=5432;User Id=postgres;Password=z7AEwer79;Database=OPIgym;";
        string npg = "SELECT * FROM coach, students";
        public Form1()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = true;
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                adapter = new NpgsqlDataAdapter(npg, connection);

                ds = new DataSet();
                adapter.Fill(ds);


            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            NpgsqlConnection connectString = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=z7AEwer79;Database=OPIgym;");
            NpgsqlCommand TableConnection = new NpgsqlCommand();
            connectString.Open();
            TableConnection.Connection = connectString;
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
            connectString.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NpgsqlConnection connectString = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=z7AEwer79;Database=OPIgym;");
            NpgsqlCommand TableConnection = new NpgsqlCommand();
            connectString.Open();
            TableConnection.Connection = connectString;
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
            connectString.Close();
        }

        private void textSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            NpgsqlConnection connectString = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=z7AEwer79;Database=OPIgym;");
            NpgsqlCommand TableConnection = new NpgsqlCommand();
            connectString.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select * from coach JOIN students ON coach.coach_id = students.fk_students_coach", connectString);
            DataTable dt = new DataTable("coach");
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dt.DefaultView.RowFilter = String.Format("name_coach like '%" + textSearch.Text + "%'");
            TableConnection.Dispose();
            connectString.Close();
        }

        private void textSeach2_KeyPress(object sender, KeyPressEventArgs e)
        {
            NpgsqlConnection connectString = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=z7AEwer79;Database=OPIgym;");
            NpgsqlCommand TableConnection = new NpgsqlCommand();
            connectString.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select * from students JOIN coach ON students.fk_students_coach = coach.coach_id", connectString);
            DataTable dt = new DataTable("students");
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dt.DefaultView.RowFilter = String.Format("name_students like '%" + textSeach2.Text + "%'");

            TableConnection.Dispose();
            connectString.Close();
        }

        private void textSearch_Click(object sender, EventArgs e)
        {
            textSeach2.Text = "";
        }

        private void textSeach2_Click(object sender, EventArgs e)
        {
            textSearch.Text = "";
        }

        private void textSearch_KeyDown(object sender, KeyEventArgs e)
        {

        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            //NpgsqlConnection connect = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=z7AEwer79;Database=OPIgym;");
            //connect.Open();
            //adapter = new NpgsqlDataAdapter(npg, connect);
            //commandBuilder = new NpgsqlCommandBuilder(adapter);
            //adapter.Update(ds);
            DataTable table = new DataTable("students");
            commandBuilder = new NpgsqlCommandBuilder(adapter);
            adapter.Update(table);
        }
        private void iDelete()
        {
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.RemoveAt(item.Index);
            }
        }
        private void deleteButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(row);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NpgsqlConnection connectString = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=z7AEwer79;Database=OPIgym;");
            NpgsqlCommand TableConnection = new NpgsqlCommand();
            connectString.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("SELECT * FROM coach JOIN students ON coach.coach_id = students.fk_students_coach", connectString);
            DataTable dt = new DataTable("coach, students");
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            TableConnection.Dispose();
            connectString.Close();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            DataRow row = ds.Tables[0].NewRow(); // добавляем новую строку в DataTable
            ds.Tables[0].Rows.Add(row);
        }
    }
}
