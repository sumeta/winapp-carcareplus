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
    public partial class PaymentDetail : Form
    {
        int id;
        public PaymentDetail(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void PaymentDetail_Load(object sender, EventArgs e)
        {
            var db = new Db();
            var con = db.connect();

            SQLiteCommand comm = new SQLiteCommand("select * from servicehdr where Id=:id", con);
            comm.Parameters.Add("id", DbType.Int32).Value = id;

            using (SQLiteDataReader read = comm.ExecuteReader())
            {
                while (read.Read())
                {
                    label3.Text = read.GetValue(read.GetOrdinal("CarName")).ToString();
                    label5.Text = read.GetValue(read.GetOrdinal("CusName")).ToString();
                    label7.Text = read.GetValue(read.GetOrdinal("Service")).ToString();
                    label8.Text = read.GetValue(read.GetOrdinal("InTime")).ToString();
                    label10.Text = read.GetValue(read.GetOrdinal("TotalPrice")).ToString();
                    richTextBox1.Text = read.GetValue(read.GetOrdinal("Note")).ToString();


                }
            }


        }

        private void BtnPay_Click(object sender, EventArgs e)
        {

            var confirmResult = MessageBox.Show("คุณต้องการชำระเงินใช่หรือไม่ ?", "ยืนยันข้อมูล", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.No)
            {
                return;
            }

            var db = new Db();
            var con = db.connect();
            var cmd = new SQLiteCommand(con);
            var stm = "UPDATE servicehdr SET Note=:note , PayStatus = 'Y',PayTime = datetime('now') WHERE id = :id";
            cmd.Parameters.Add("id", DbType.Int32).Value = id;
            cmd.Parameters.Add("note", DbType.String).Value = richTextBox1.Text;
            cmd.CommandText = stm;
            cmd.ExecuteNonQuery();

            Close();

            new Payment().ShowDialog();

        }
    }
}
