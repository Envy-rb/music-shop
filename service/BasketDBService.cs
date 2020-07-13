using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.service
{
    class BasketDBService
    {
        private static string ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=resource\database\productDB\ProductDB.mdb";

        public static void executeQuery(string CommandText)
        {
            OleDbConnection connection = new OleDbConnection(ConnectionString);

            connection.Open();
            OleDbCommand command = connection.CreateCommand();
            command.CommandText = CommandText;
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static void addProduct(int id)
        {
            string query;

            query = string.Format("INSERT INTO Basket(productId) VALUES ({0})", id);
            executeQuery(query);
        }

        public static void removeProduct(int id)
        {
            string query;

            query = string.Format("DELETE * FROM Basket WHERE Basket.id = {0}", id);
            executeQuery(query);
        }

        public static DataSet getProducts()
        {
            string query;

            query = string.Format("SELECT Basket.id, Product.* FROM Product INNER JOIN Basket ON Product.id = Basket.productId;");
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, ConnectionString);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            return ds;
        }

        public static double getPrice()
        {
            string query;
            double result;

            query = string.Format("SELECT Sum(Product.price) FROM Product INNER JOIN Basket ON Product.id = Basket.productId;");
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, ConnectionString);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            double.TryParse(ds.Tables[0].Rows[0][0].ToString(), out result);
            return result;
        }

        public static void clearDB()
        {
            string query;

            query = "DELETE * FROM Basket";
            executeQuery(query);
        }
    }
}
