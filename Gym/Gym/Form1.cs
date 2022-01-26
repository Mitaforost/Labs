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
        public bool students = true;
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

        private void saveButton_Click(object sender, EventArgs e)
        {
            NpgsqlConnection connectString = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=z7AEwer79;Database=OPIgym;");
            if (students == true)
            {
                string sql_st = "SELECT * FROM students";
                connectString.Open();
                NpgsqlDataAdapter adapter_st = new NpgsqlDataAdapter(sql_st, connectString);
                NpgsqlCommandBuilder cmdBuilder_st = new NpgsqlCommandBuilder(adapter_st);
                adapter_st.UpdateCommand = cmdBuilder_st.GetUpdateCommand();
                adapter_st.Update((DataTable)dataGridView1.DataSource);
                connectString.Close();
            }
            else
            {
                string sql_ch = "SELECT * FROM coach";
                connectString.Open();
                NpgsqlDataAdapter adapter_ch = new NpgsqlDataAdapter(sql_ch, connectString);
                NpgsqlCommandBuilder cmdBuilder_ch = new NpgsqlCommandBuilder(adapter_ch);
                adapter_ch.UpdateCommand = cmdBuilder_ch.GetUpdateCommand();
                adapter_ch.Update((DataTable)dataGridView1.DataSource);
                connectString.Close();
            }
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
            DataRow row = ds.Tables[0].NewRow();
            ds.Tables[0].Rows.Add(row);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textSeach2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            NpgsqlConnection connectString = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=z7AEwer79;Database=OPIgym;");
            NpgsqlCommand TableConnection = new NpgsqlCommand();
            connectString.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select * from students JOIN coach ON students.fk_students_coach = coach.coach_id", connectString);
            DataTable dt = new DataTable("students");
            DataTable dt2 = new DataTable("coach");
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            da.Fill(dt2);
            dataGridView1.DataSource = dt2;
            dt.DefaultView.RowFilter = String.Format("phone_coach like '%" + textBox1.Text + "%'");
            dt2.DefaultView.RowFilter = String.Format("phone_students like '%" + textBox1.Text + "%'");

            TableConnection.Dispose();
            connectString.Close();
        }
    }
}
