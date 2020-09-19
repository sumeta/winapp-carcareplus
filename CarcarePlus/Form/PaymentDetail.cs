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

                }
            }


        }
    }
}
