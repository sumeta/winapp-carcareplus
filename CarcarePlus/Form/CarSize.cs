using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace CarcarePlus
{
    public partial class CarSize : Form
    {

        int id;
        bool add = true;
        public CarSize()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            add = false;
            id = int.Parse(dataGridView1.CurrentRow.Cells["Id"].Value.ToString());
            textBox1.Text = dataGridView1.CurrentRow.Cells["Size"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["Comment"].Value.ToString();
        }

        private void CarSize_Load(object sender, EventArgs e)
        {
            load_data();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            add = true;
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length == 0)
            {
                MessageBox.Show("ระบุขนาด");
                return;
            }

            // Database
            var db = new Db();
            var con = db.connect();
            var cmd = new SQLiteCommand(con);
            var stm = "";
            if (add)
            {
                stm = "INSERT INTO carsize(Size,Comment) VALUES(:size,:comment)";
            }
            else
            {
                stm = "UPDATE carsize SET Size = :size,Comment = :comment WHERE Id = :id ";
                cmd.Parameters.Add("id", DbType.String).Value = id;
            }
            cmd.Parameters.Add("size", DbType.String).Value = textBox1.Text;
            cmd.Parameters.Add("comment", DbType.String).Value = textBox2.Text;
            cmd.CommandText = stm;
            cmd.ExecuteNonQuery();

            load_data();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("คูณแน่ใจหรือว่าต้องการลบข้อมูล ?", "ยืนยันการลบข้อมูล", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.No)
            {
                return;
            }

            if (dataGridView1.CurrentRow != null)
            {

                int id = int.Parse(dataGridView1.CurrentRow.Cells["Id"].Value.ToString());

                // Database
                var db = new Db();
                var con = db.connect();
                var cmd = new SQLiteCommand(con);
                var stm = "DELETE FROM carsize WHERE Id=:id";
                cmd.Parameters.Add("Id", DbType.Int32).Value = id;
                cmd.CommandText = stm;
                cmd.ExecuteNonQuery();

                load_data();
            }

        }

        private void load_data()
        {
            var db = new Db();
            var con = db.connect();

            SQLiteCommand comm = new SQLiteCommand("select * from carsize", con);
            using (SQLiteDataReader read = comm.ExecuteReader())
            {
                dataGridView1.Rows.Clear();
                while (read.Read())
                {
                    dataGridView1.Rows.Add(new object[] {
                        read.GetValue(read.GetOrdinal("Id")),
                        read.GetValue(read.GetOrdinal("Size")),
                        read.GetValue(read.GetOrdinal("Comment"))
                    });
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            add = false;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            id = int.Parse(dataGridView1.CurrentRow.Cells["Id"].Value.ToString());
            textBox1.Text = dataGridView1.CurrentRow.Cells["Size"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["Comment"].Value.ToString();
        }
    }
}
