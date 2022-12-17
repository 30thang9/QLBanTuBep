using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL.system
{
    internal class DBConfig
    {
        private string STRING_CONNECT = "Data Source=DESKTOP-752UMUF\\SQLEXPRESS;Initial Catalog=QLTuBep;Integrated Security=True";
        private SqlDataAdapter sqlDataAdapter;
        private SqlCommand sqlCommand;

        public DataTable table(string query)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(STRING_CONNECT))
            {
                sqlConnection.Open();
                sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
                sqlDataAdapter.Fill(dataTable);//nap du lieu vao bang
                sqlConnection.Close();
            }
            return dataTable;
        }

        public void Excute(string query) // update, insert, delete
        {
            using (SqlConnection sqlConnection = new SqlConnection(STRING_CONNECT))
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.ExecuteNonQuery(); //thực thi câu truy vấn
                sqlConnection.Close();
            }
        }


        public bool Check(string query)
        {
            DataTable table = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(STRING_CONNECT))
            {
                sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
                sqlDataAdapter.Fill(table);
                if (table.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        public string getValues(string query)
        {
            string ma = "";
            using (SqlConnection sqlConnection = new SqlConnection(STRING_CONNECT))
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    ma = reader.GetValue(0).ToString();
                }
                reader.Close();
            }
            return ma;
        }
    }
}
