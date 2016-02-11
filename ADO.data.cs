using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.IO;
using System.Data.SqlClient;
using System.Data;




namespace ConsoleApplication1
{

    class Program
    {


        static void Main(string[] args)
        {


            string strCon = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\C#\ConsoleApplication1\ConsoleApplication1\test.mdf;Integrated Security=True";
            string strSql = "select * from Student";
            SqlConnection con = new SqlConnection(strCon);
            con.Open();

            SqlDataAdapter dadapter = new SqlDataAdapter();
            dadapter.SelectCommand = new SqlCommand(strSql, con);
            DataSet dset = new DataSet();
            dadapter.Fill(dset);
            con.Close();

            // this.dataGrid1.DataSource = dset;
            foreach(DataTable table in dset.Tables)
            {
                foreach(DataRow row in table.Rows)
                {
                    foreach(DataColumn column in table.Columns)
                    {
                        object item1 = row["Name"];
                        object item2 = row["Age"];
                        object item3 = row["Sex"];
                        // read column and item
                        Console.WriteLine(item1.ToString() + "\t" + item2.ToString() + "\t" + item3.ToString());
                    }
                }
            }
            Console.ReadKey();

        }


    }

}







