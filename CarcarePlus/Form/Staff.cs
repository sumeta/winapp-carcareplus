using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data.SqlClient;

namespace CarcarePlus
{
    public partial class Staff : Form
    {
        private int rowIndex = 0;
        private int id = 0;

        public Staff()
        {
            InitializeComponent();
        }

        private void Staff_Load(object sender, EventArgs e)
        {
            //var con = new SQLiteConnection("Data Source=./db.db;Version=3;New=False;Compress=True;");
            //con.Open();
            var db = new Db();
            var con = db.connect();

            //string stm = "SELECT * FROM staff";

            //var cmd = new SQLiteCommand(stm, con);
            //SQLiteDataReader rdr = cmd.ExecuteReader();

            //Console.WriteLine("abc");

            //while (rdr.Read())
            //{
            //    Console.WriteLine($"{rdr.GetInt32(0)} {rdr.GetString(1)} {rdr.GetString(2)}");
            //}


            SQLiteCommand comm = new SQLiteCommand("select * from staff", con);
            using (SQLiteDataReader read = comm.ExecuteReader())
            {
                while (read.Read())
                {
                    dataGridView1.Rows.Add(new object[] {
                        //read.GetValue(0),  // U can use column index
                        read.GetValue(read.GetOrdinal("Id")),  // Or column name like this
                        read.GetValue(read.GetOrdinal("Name")),
                        read.GetValue(read.GetOrdinal("Tel"))
                });
                }
            }



        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowIndex = dataGridView1.CurrentRow.Index;
            var rId = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
            id = Int32.Parse(rId);

            if (dataGridView1.CurrentCell.ColumnIndex >= 0  && e.RowIndex != -1)
            {
                if (dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.Value != null)
                {
                    textBox1.Text = dataGridView1.CurrentCell.Value.ToString();
                    textBox2.Text = dataGridView1.CurrentRow.Cells["Tel"].Value.ToString();
                }
            }
        }


        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            MessageBox.Show(dataGridView1.CurrentCell.Value.ToString());

        }




        private void label1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("xxxx");

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void s(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            var db = new Db();
            var con = db.connect();
            var cmd = new SQLiteCommand(con);
            var stm = "UPDATE staff SET tel = :tel , name= :name WHERE id = :id";
            cmd.Parameters.Add("name", DbType.String).Value = textBox1.Text;
            cmd.Parameters.Add("tel", DbType.String).Value = textBox2.Text;
            cmd.Parameters.Add("id", DbType.Int32).Value = id;
            cmd.CommandText = stm;
            cmd.ExecuteNonQuery();
            
            dataGridView1.Rows[rowIndex].Cells["StaffName"].Value = textBox1.Text.ToString();
            dataGridView1.Rows[rowIndex].Cells["Tel"].Value = textBox2.Text.ToString();

            MessageBox.Show("Save Success : " + textBox1.Text,"OK");


        }

        private void dataGridView1_CellClick(object sender, EventArgs e)
        {
            rowIndex = dataGridView1.CurrentRow.Index;
            var rId = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
            id = Int32.Parse(rId);

            if (dataGridView1.CurrentCell.ColumnIndex >= 0)
            {
                if (dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.Value != null)
                {
                    textBox1.Text = dataGridView1.CurrentCell.Value.ToString();
                    textBox2.Text = dataGridView1.CurrentRow.Cells["Tel"].Value.ToString();
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
