using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CarcarePlus
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            int countItem = 0;
            double sumPrice = 0.00;
            var db = new Db();
            var con = db.connect();

            SQLiteCommand comm = new SQLiteCommand("select * from servicehdr where Status = 'N' ", con);
            using (SQLiteDataReader read = comm.ExecuteReader())
            {
                while (read.Read())
                {
                    dataGridView1.Rows.Add(new object[] {
                        //read.GetValue(0),  // U can use column index
                        //read.GetValue(read.GetOrdinal("Id")),  // Or column name like this
                        read.GetValue(read.GetOrdinal("InTime")),
                        read.GetValue(read.GetOrdinal("CarName")),
                        read.GetValue(read.GetOrdinal("CusName")),
                        read.GetValue(read.GetOrdinal("Service")),
                        read.GetValue(read.GetOrdinal("TotalPrice")),
                        read.GetValue(read.GetOrdinal("PayTime"))
                    });

                    countItem++;
                    sumPrice += float.Parse(read.GetValue(read.GetOrdinal("TotalPrice")).ToString());
                }
            }

            label2.Text = String.Format("{0:n0}", countItem);
            label4.Text = String.Format("{0:n}", sumPrice);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
