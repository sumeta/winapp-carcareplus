using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Windows.Forms;

namespace CarcarePlus
{
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Customer_Load(object sender, EventArgs e)
        {
            load_data();
        }


        private void load_data()
        {
            var db = new Db();
            var con = db.connect();

            SQLiteCommand comm = new SQLiteCommand("select * from customer", con);
            using (SQLiteDataReader read = comm.ExecuteReader())
            {
                dataGridView1.Rows.Clear();
                while (read.Read())
                {
                    dataGridView1.Rows.Add(new object[] {
                        read.GetValue(read.GetOrdinal("code")),
                        read.GetValue(read.GetOrdinal("firstname")),
                        read.GetValue(read.GetOrdinal("lastname")),
                        read.GetValue(read.GetOrdinal("tel"))
                    });
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new CustomerEdit().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new CustomerEdit().ShowDialog();
        }
    }
}
