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

            if(textBox1.Text.Length == 0)
            {
                MessageBox.Show("กรุณาระบุทะเบียนรถ");
                return;
            }
            if (textBox2.Text.Length == 0)
            {
                MessageBox.Show("กรุณาระบุชื่อลูกค้า");
                return;
            }
            if (comboBox1.Text.Length == 0)
            {
                MessageBox.Show("กรุณาระบุขนาด");
                return;
            }
            if (textBox5.Text.Length == 0)
            {
                MessageBox.Show("กรุณาระบุราคา");
                return;
            }

            float f;
            if (!float.TryParse(textBox5.Text, out f))
            {
                MessageBox.Show("กรุณาระบุราคาเป็นตัวเลข");
                return;
            }


            var db = new Db();
            var con = db.connect();
            var cmd = new SQLiteCommand(con);
            var stm = "INSERT INTO servicehdr(InTime,CarName, CusName, CusSize,Service, TotalPrice,Note) VALUES(datetime('now'),:name, :cusnam, :size,:service, :price,:note)";
            cmd.Parameters.Add("name", DbType.String).Value = textBox1.Text;
            cmd.Parameters.Add("cusnam", DbType.String).Value = textBox2.Text;
            cmd.Parameters.Add("service", DbType.String).Value = textBox3.Text;
            cmd.Parameters.Add("size", DbType.String).Value = comboBox1.Text;
            cmd.Parameters.Add("price", DbType.String).Value = textBox5.Text;
            cmd.Parameters.Add("note", DbType.String).Value = richTextBox1.Text;
            cmd.CommandText = stm;
            cmd.ExecuteNonQuery();

            MessageBox.Show("บันทึกข้อมูลสำเร็จ","Success");

            Close();

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void CarIn_Load(object sender, EventArgs e)
        {
            List<string> employees = new List<string>();

            var db = new Db();
            var con = db.connect();

            SQLiteCommand comm = new SQLiteCommand("select * from carsize", con);
            using (SQLiteDataReader read = comm.ExecuteReader())
            {
                while (read.Read())
                {
                    employees.Add(read.GetValue(read.GetOrdinal("Size")).ToString());
                }
            }

            comboBox1.Items.AddRange(employees.ToArray());
        }
    }
}
