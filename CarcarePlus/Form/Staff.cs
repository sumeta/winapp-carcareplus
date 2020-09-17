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

            string stm = "SELECT * FROM staff";

            var cmd = new SQLiteCommand(stm, con);
            SQLiteDataReader rdr = cmd.ExecuteReader();

            Console.WriteLine("abc");

            while (rdr.Read())
            {
                Console.WriteLine($"{rdr.GetInt32(0)} {rdr.GetString(1)} {rdr.GetString(2)}");
            }


            SQLiteCommand comm = new SQLiteCommand("Select * From staff", con);
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
            MessageBox.Show("OK");
        }
    }
}
