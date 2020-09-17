using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace CarcarePlus
{
    class Db
    {

     
        public SQLiteConnection connect()
        {
            var con = new SQLiteConnection("Data Source=./db.db;Version=3;New=False;Compress=True;");
            con.Open();

            return con;
        }
    }
}
