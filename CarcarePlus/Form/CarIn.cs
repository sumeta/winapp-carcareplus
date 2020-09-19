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
    public partial class CarIn : Form
    {
        public CarIn()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var db = new Db();
            var con = db.connect();
            var cmd = new SQLiteCommand(con);
            var stm = "INSERT INTO servicehdr(CarName, CusName, CusSize, TotalPrice,DateTime) VALUES(:name, :cusnam, :size, :price,datetime('now'))";
            cmd.Parameters.Add("name", DbType.String).Value = textBox1.Text;
            cmd.Parameters.Add("cusnam", DbType.String).Value = textBox2.Text;
            cmd.Parameters.Add("size", DbType.String).Value = textBox4.Text;
            cmd.Parameters.Add("price", DbType.String).Value = textBox5.Text;
            cmd.CommandText = stm;
            cmd.ExecuteNonQuery();


            MessageBox.Show("OK","Success");

        }
    }
}
