using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace DataAccess
{
    public class SqliteConnection
    {

        private string strConnection = string.Empty;
        public SqliteConnection()
        {

            string sqliteDatabase = "C:\\Users\\admin\\Desktop\\Ombori\\WebApi\\DataAccess\\bin\\Release\\OmboriDB.db";
            strConnection = String.Format("Data Source={0}", sqliteDatabase);
        }

        public DataTable QueryToDataTable(string strQuery)
        {
           
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(strConnection))
                {
                    // DataSet ds = new DataSet("category");
                    DataTable dt = new DataTable();

                    SQLiteDataAdapter adapter = new SQLiteDataAdapter();

                    connection.Open();

                    SQLiteCommand command = new SQLiteCommand(strQuery, connection);

                    adapter.SelectCommand = command;

                    adapter.Fill(dt);

                    return dt;
                }
            }
            catch (Exception ex)
            {
                return null; 
            }

        }


        public void ExecuteNonQuery(string strQuery)
        {
            using (SQLiteConnection connection = new SQLiteConnection(strConnection))
            {
                try
                {
                    SQLiteCommand command = new SQLiteCommand(strQuery, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                   
                }
            }

        }
    }
}
