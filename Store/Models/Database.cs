using Store.DataBaseModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models
{
    //Уже не нужнен
    public class Database
    {
        private string _connectionString;

        //private SqlDataAdapter adapter;
        //private DataSet ds;

        public void Update()
        {
            db.SubmitChanges();
            
            //string sql = "SELECT * FROM Products";
            //using (SqlConnection connection = new SqlConnection(_connectionString))
            //{
            //    connection.Open();
            //    // Создаем объект DataAdapter
            //    SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            //    SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            //    adapter.UpdateCommand = builder.GetUpdateCommand();
            //    adapter.DeleteCommand = builder.GetDeleteCommand();

            //    adapter.Update(ds);
            //}
        }

        public Table<Product> GetProducts()
        {
            return db.GetTable<Product>();
            //string sql = "SELECT * FROM Products";
            //using (SqlConnection connection = new SqlConnection(_connectionString))
            //{
            //    connection.Open();
            //    // Создаем объект DataAdapter
            //    SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            //    SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            //    adapter.UpdateCommand = builder.GetUpdateCommand();
            //    // Создаем объект Dataset
            //    ds = new DataSet();
            //    // Заполняем Dataset
            //    adapter.Fill(ds);
            //    return ds.Tables[0];
            //}
        }

        DataContext db;

        public Database(string connectionString)
        {
            //_connectionString = connectionString;
            db = new DataContext(_connectionString);
        }
    }
}
