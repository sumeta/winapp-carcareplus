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

    
    public partial class Payment : Form
    {
        int id = 0;

        public Payment()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.Value != null)
            {
                var rId = dataGridView1.CurrentRow.Cells["idx"].Value.ToString();
                id = Int32.Parse(rId);
            }
        }

        private void Payment_Load(object sender, EventArgs e)
        {
            var db = new Db();
            var con = db.connect();

            SQLiteCommand comm = new SQLiteCommand("select * from servicehdr where PayStatus='N' AND Status = 'N' ", con);
            using (SQLiteDataReader read = comm.ExecuteReader())
            {
                while (read.Read())
                {
                    dataGridView1.Rows.Add(new object[] {
                        read.GetValue(0),
                        //read.GetValue(read.GetOrdinal("Id")),  // Or column name like this
                        read.GetValue(read.GetOrdinal("InTime")),
                        read.GetValue(read.GetOrdinal("CarName")),
                        read.GetValue(read.GetOrdinal("CusName")),
                        read.GetValue(read.GetOrdinal("Service")),
                        read.GetValue(read.GetOrdinal("TotalPrice"))
                });
                }
            }

        }

        private void BtnPay_Click(object sender, EventArgs e)
        {

            if(id == 0)
            {
                MessageBox.Show("เลือกรายการก่อน");
                return;
            }

            var confirmResult = MessageBox.Show("คูณแน่ใจหรือว่าต้องการลบข้อมูล ?","ยืนยันการลบข้อมูล",MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.No)
            {
                return;
            }

            var db = new Db();
            var con = db.connect();
            var cmd = new SQLiteCommand(con);
            var stm = "UPDATE servicehdr SET Status = 'D' WHERE id = :id";
            cmd.Parameters.Add("id", DbType.Int32).Value = id;
            cmd.CommandText = stm;
            cmd.ExecuteNonQuery();

            var rowIndex = dataGridView1.CurrentRow.Index;
            dataGridView1.Rows.RemoveAt(rowIndex);


        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                Close();
                new PaymentDetail(id).ShowDialog();
            }
        }
    }
}
